using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;

namespace U2.MultiRig;

public enum TRigCtlStatus
{
	stNotConfigured, stDisabled, stPortBusy, stNotResponding, stOnLine
}

public abstract class CustomRig
{
	internal bool FEnabled = false;
	internal bool FOnline = false;
	internal IntPtr FCritSect = new IntPtr();
	internal RigCommands FRigCommands = new RigCommands();
	internal DateTime FNextStatusTime;
	internal DateTime FDeadLineTime;

	////////////////////////////////////////////////////////////////////////////////
	//                                 Comm port
	////////////////////////////////////////////////////////////////////////////////
	private void SetEnabled(bool Value)
	{
		if (FEnabled == Value)
		{
			return;
		}

		//check for valid RigCommands
		if (Value && (RigCommands == null))
		{
			return;
		}

		if (Value)
		{
			Start();
		}
		else
		{
			Stop();
		}

		MissedLogic.ComNotifyStatus(RigNumber);
		LastWrittenMode = TPenMode.pmNone;
	}







	////////////////////////////////////////////////////////////////////////////////
	//                                 status
	////////////////////////////////////////////////////////////////////////////////
	private TRigCtlStatus GetStatus()
	{
		TRigCtlStatus getStatus_result = new TRigCtlStatus();
		Lock();

		try
		{
			if (RigCommands == null)
			{
				getStatus_result = TRigCtlStatus.stNotConfigured;
			}
			else if (!FEnabled)
			{
				getStatus_result = TRigCtlStatus.stDisabled;
			}
			else if (!ComPort.Open)
			{
				getStatus_result = TRigCtlStatus.stPortBusy;
			}
			else if (!FOnline)
			{
				getStatus_result = TRigCtlStatus.stNotResponding;
			}
			else
			{
				getStatus_result = TRigCtlStatus.stOnLine;
			}
		}
		finally
		{
			UnLock();
		}

		return getStatus_result;
	}




	private void RecvEvent(object Sender)
	{
		TByteArray Data = new TByteArray();
		Lock();

		try
		{
			Data = null;

			if (ComPort.RxBuffer != string.Empty)
			{
				Data = ((TByteArray)MissedLogic.StrToBytes(ComPort.RxBuffer));
			}

			ComPort.PurgeRx();

			//some COM ports do not send EV_TXEMPTY

			if (FQueue.Phase == MissedLogic.phSending)
			{
				FQueue.Phase = MissedLogic.phReceiving;
				MainForm.Log("RIG{0} {1} bytes in TX buffer, accepting reply", new string[] { Convert.ToString(RigNumber), ComPort.TxQueue });
			}

			if (FQueue.Phase == MissedLogic.phReceiving)
			{
				MainForm.Log("RIG{0} reply received: {1}", new string[] { Convert.ToString(RigNumber), ((int)MissedLogic.BytesToHex(Data)) });
			}
			else
			{
				MainForm.Log("RIG{0} {!}unexpected data received: {1}", new string[] { Convert.ToString(RigNumber), ((int)MissedLogic.BytesToHex(Data)) });
			}

			//are we in the right state?
			if ((!ComPort.Open) || (FQueue.Phase != MissedLogic.phReceiving) || (FQueue.Count == 0))
			{
				return;
			}

			//process data
			try
			{
				// ISPIRER
				//with FQueue.CurrentCmd do
				switch (FQueue.CurrentCmd.Kind)
				{
					case FQueue.CurrentCmd.ckInit:
						ProcessInitReply(FQueue.CurrentCmd.Number, Data);
						break;

					case FQueue.CurrentCmd.ckWrite:
						ProcessWriteReply(FQueue.CurrentCmd.Param, Data);
						break;

					case FQueue.CurrentCmd.ckStatus:
						ProcessStatusReply(FQueue.CurrentCmd.Number, Data);
						break;

					case FQueue.CurrentCmd.ckCustom:
						ProcessCustomReply(FQueue.CurrentCmd.CustSender, FQueue.CurrentCmd.Code, Data);
						break;
				}
			}
			catch (Exception E)
			{
				MainForm.Log("RIG% {!}Processing reply: {1}", new string[] { Convert.ToString(RigNumber), E.Message });
			}

			//we are receiving data, therefore we are online
			if (!FOnline)
			{
				FOnline = true;
				MissedLogic.ComNotifyStatus(RigNumber);
			}

			//send next command if queue not empty
			FQueue.Remove(0);
			FQueue.Phase = MissedLogic.phIdle;
			FDeadLineTime = CustRigUnit.NEVER;
			CheckQueue();
		}
		finally
		{
			UnLock();
		}
	}



	private void SentEvent(object Sender)
	{
		MainForm.Log("RIG{0} data sent, {1} bytes in TX buffer", new string[] { Convert.ToString(RigNumber), ComPort.TxQueue });

		if (ComPort.TxQueue > 0)
		{
			return;
		}

		Lock();

		try
		{
			if ((!ComPort.Open) || (FQueue.Phase != MissedLogic.phSending) || (FQueue.Count == 0))
			{
				return;
			}

			if (FQueue.CurrentCmd.NeedsReply)
			{
				FQueue.Phase = MissedLogic.phReceiving;
				FDeadLineTime = DateTime.Now + CustRigUnit.DinMS * TimeoutMs;
			}
			else
			{
				FQueue.Remove(0);
				FQueue.Phase = MissedLogic.phIdle;
				FDeadLineTime = CustRigUnit.NEVER;
				CheckQueue();
			}
		}
		finally
		{
			UnLock();
		}
	}



	private void CtsDsrEvent(object Sender)
	{
		string[] BoolStr = new string[] { "OFF", "ON" };
		MainForm.Log("RIG{0} ctrl bits: CTS={1} DSR={2} RLS={3}", new string[] { Convert.ToString(RigNumber), BoolStr[ComPort.CtsBit], BoolStr[ComPort.DsrBit],
					 BoolStr[ComPort.RlsdBit]
																			   });
	}



	private void SetFreq(int Value)
{
if (Enabled)
{
			AddWriteCommand(TPenMode.pmFreq, Value);
		}
	}



	private void SetFreqA(int Value)
	{
		MainForm.Log("Entered SetFreqA");

		if (Enabled && (Value != FFreqA))
{
			AddWriteCommand(TPenMode.pmFreqA, Value);
		}

		MainForm.Log("Exiting SetFreqA");
	}



	private void SetFreqB(int Value)
	{
		if (Enabled && (Value != FFreqB))
{
			AddWriteCommand(TPenMode.pmFreqB, Value);
		}
	}


	private void SetRitOffset(int Value)
	{
		if (Enabled && (Value != FRitOffset))
{
			AddWriteCommand(TPenMode.pmRitOffset, Value);
		}
	}


	private void SetPitch(int Value)
	{
		if (!Enabled)
		{
			return;
}

		AddWriteCommand(TPenMode.pmPitch, Value);

//remember the pitch that we set if we cannot read it back from the rig
		if (!(RigCommands.ReadableParams.Contains(TPenMode.pmPitch)))
		{
			FPitch = Value;
		}
	}


	private void SetVfo(TRigParam Value)
	{
		if (Enabled && (VfoParams.Contains(Value)) && (Value != FVfo))
		{
			AddWriteCommand(Value);
		}
	}


	private void SetSplit(TRigParam Value)
	{
		if (!(Enabled && (SplitParams.Contains(Value))))
		{
			return;
		}

		if ((RigCommands.WriteableParams.Contains(Value)) && (Value != Split))
		{
			AddWriteCommand(Value);
}
		else if (Value == TPenMode.pmSplitOn)
{
			if (Vfo == TPenMode.pmVfoAA)
			{
				Vfo = TPenMode.pmVfoAB;
			}
			else if (Vfo == TPenMode.pmVfoBB)
			{
				Vfo = TPenMode.pmVfoBA;
			}
		}
		else if (Vfo == TPenMode.pmVfoAB)
		{
			Vfo = TPenMode.pmVfoAA;
		}
		else if (Vfo == TPenMode.pmVfoBA)
		{
			Vfo = TPenMode.pmVfoBB;
		}
	}


	private void SetRit(TRigParam Value)
	{
		if (Enabled && (RitOnParams.Contains(Value)) && (Value != FRit))
		{
			AddWriteCommand(Value);
		}
	}



	private void SetXit(TRigParam Value)
	{
		if (Enabled && (XitOnParams.Contains(Value)) && (Value != Xit))
		{
			AddWriteCommand(Value);
		}
	}


	private void SetTx(TRigParam Value)
	{
		if (Enabled && (TxParams.Contains(Value)))
		{
			AddWriteCommand(Value);
		}
	}


	private void SetMode(TRigParam Value)
	{
		if (Enabled && (ModeParams.Contains(Value)))
		{
			AddWriteCommand(Value);
		}
	}








	////////////////////////////////////////////////////////////////////////////////
	//                               set param
	////////////////////////////////////////////////////////////////////////////////
	private void SetRigCommands(TRigCommands Value)
	{
		FRigCommands = Value;
		MissedLogic.ComNotifyRigType(RigNumber);
	}







	private TRigParam GetSplit()
	{
		TRigParam getSplit_result = new TRigParam();
		getSplit_result = FSplit;

		if (getSplit_result != TPenMode.pmNone)
		{
			return getSplit_result;
		}
if (new[] { TPenMode.pmVfoAA, TPenMode.pmVfoBB }.Contains(Vfo))
{
getSplit_result = TPenMode.pmSplitOff;
}
		else if (new[] { TPenMode.pmVfoAB, TPenMode.pmVfoBA }.Contains(Vfo))
{
getSplit_result = TPenMode.pmSplitOn;
}
return getSplit_result;
	}
	protected TCommandQueue FQueue = new TCommandQueue();
	protected int FFreq = 0;
	protected int FFreqA = 0;
	protected int FFreqB = 0;
	protected int FRitOffset = 0;
	protected int FPitch = 0;
	protected TRigParam FVfo = new TRigParam();
	protected TRigParam FSplit = new TRigParam();
	protected TRigParam FRit = new TRigParam();
	protected TRigParam FXit = new TRigParam();
	protected TRigParam FTx = new TRigParam();
	protected TRigParam FMode = new TRigParam();

	//these commands are implemented in the descendant class,
	//just to keep them in a separate file


	protected abstract void AddCommands(TRigCommandArray ACmds, TCommandKind AKind);



	protected abstract void ProcessInitReply(int ANumber, TByteArray AData);


	protected abstract void ProcessStatusReply(int ANumber, TByteArray AData);


	protected abstract void ProcessWriteReply(TRigParam AParam, TByteArray AData);


	protected abstract void ProcessCustomReply(object ASender, TByteArray ACode, TByteArray AData);
	public int RigNumber = 0;
	public int PollMs = 0;
	public int TimeoutMs = 0;
	public TAlCommPort ComPort = new TAlCommPort();
	public RigParameter LastWrittenMode = RigParameter.None;






	/* TCustomRig */

	////////////////////////////////////////////////////////////////////////////////
	//                                 system
	////////////////////////////////////////////////////////////////////////////////
	public TCustomRig()
	{
		FCritSect = new IntPtr();
		FQueue = new TCommandQueue();
		ComPort = new TAlCommPort();
		ComPort.OnReceived = RecvEvent();
		ComPort.OnSent = SentEvent();
		ComPort.OnCtsDsr = CtsDsrEvent();
	}



	private bool disposed = false;
	protected void Dispose(bool disposing)
	{
		if (!this.disposed)
		{
			if (disposing)
			{
				Stop();
				ComPort = null;
				FQueue = null;
				FCritSect = null;
			}
		}

		disposed = true;
	}



	public abstract void AddWriteCommand(TRigParam AParam, int AValue = 0);


	public abstract void AddCustomCommand(object ASender, TByteArray ACode, int ALen, string AEnd);









	////////////////////////////////////////////////////////////////////////////////
	//                                  queue
	////////////////////////////////////////////////////////////////////////////////
	public void Lock()
	{
		External.EnterCriticalSection(ref FCritSect);
	}



	public void UnLock()
	{
		External.LeaveCriticalSection(ref FCritSect);
	}



	public void Start()
	{
		if (RigCommands == null)
		{
			return;
		}

		MainForm.Log("Starting RIG{0}", new string[] { Convert.ToString(RigNumber) });
		Lock();

		try
		{
			if (FEnabled)
			{
				return;
			}

			FEnabled = true;
			FQueue.Clear();
			FQueue.Phase = MissedLogic.phIdle;
			FDeadLineTime = CustRigUnit.NEVER;
			AddCommands(RigCommands.InitCmd, MissedLogic.ckInit);
			AddCommands(RigCommands.StatusCmd, MissedLogic.ckStatus);

			try
			{
				ComPort.Open = true;
			}
			catch (Exception ex1)
			{
			}
		}
		finally
		{
			UnLock();
		}

		if (ComPort.Open)
		{
			CheckQueue();
		}
		else
		{
			MainForm.Log("RIG{0} {!} Unable to open port", new string[] { Convert.ToString(RigNumber) });
		}

		//    else Timer.Enabled := true;
	}



	public void Stop()
	{
		if (!FEnabled)
		{
			return;
		}

		MainForm.Log("Stopping RIG{0}", new string[] { Convert.ToString(RigNumber) });
		Lock();

		try
		{
			FEnabled = false;
			FOnline = false;
			FQueue.Clear();
			FQueue.Phase = MissedLogic.phIdle;
			ComPort.Open = false;
		}
		finally
		{
			UnLock();
		}
	}



	public void TimerTick()
	{
		Lock();

		try
		{
			if (!FEnabled)
			{
				return;
			}

			//try to open port
			if (!ComPort.Open)
			{
				try
				{
					ComPort.Open = true;
				}
				catch (Exception ex1)
				{
				}
			}

			//refresh params
			if (ComPort.Open && (DateTime.Now > FNextStatusTime))
			{
				if (FQueue.HasStatusCommands)
				{
					MainForm.Log("RIG{0} Status commands already in queue", new string[] { Convert.ToString(RigNumber) });
				}
				else
				{
					MainForm.Log("RIG{0} Adding status commands to queue", new string[] { Convert.ToString(RigNumber) });
					AddCommands(RigCommands.StatusCmd, MissedLogic.ckStatus);
				}

				FNextStatusTime = DateTime.Now + CustRigUnit.DinMS * PollMs;
			}

			//on-line timeout occurred
			if (DateTime.Now > FDeadLineTime)
			{
				//switch off-line
				if (FOnline)
				{
					FOnline = false;
					MissedLogic.ComNotifyStatus(RigNumber);
					LastWrittenMode = TPenMode.pmNone;
}

//cancel pending operation
				switch (FQueue.Phase)
				{
					case MissedLogic.phSending:
						{
							MainForm.Log("RIG{0} {!}send timeout, {1} bytes still in TX buffer", new string[] { Convert.ToString(RigNumber), ComPort.TxQueue });
							//do not send the remaining part
							ComPort.PurgeTx();
							//send the same cmd again
							FQueue.Phase = MissedLogic.phIdle;
							FDeadLineTime = CustRigUnit.NEVER;
						}
						break;

					case MissedLogic.phReceiving:
						{
							MainForm.Log("RIG{0} {!}recv timeout. RX Buffer: \"{1}\"", new string[] { Convert.ToString(RigNumber), ((int)MissedLogic.StrToHex(ComPort.RxBuffer)) });
							//waste partial reply
							ComPort.PurgeRx();
							ComPort.RxBlockMode = MissedLogic.rbChar;
							//consider current cmd unreplied
							FQueue.Remove(0);
							//allow next cmd
							FQueue.Phase = MissedLogic.phIdle;
							FDeadLineTime = CustRigUnit.NEVER;
						}
						break;
				}
			}
		}
		finally
		{
			UnLock();
		}

		CheckQueue();
	}



	public void CheckQueue()
	{
		string S = string.Empty;
		Lock();

		if (ComPort.Open && (FQueue.Phase == MissedLogic.phIdle) && (FQueue.Count > 0))
		{
			try
			{
				if (ComPort.RxBuffer != string.Empty)
				{
					MainForm.Log("RIG{0} {!}unexpected bytes in RX buffer: {1}", new string[] { Convert.ToString(RigNumber), ((int)MissedLogic.StrToHex(ComPort.RxBuffer)) });
					ComPort.PurgeRx();
				}

				//prepare port for receiving reply
				// ISPIRER
				//with FQueue[0] do
				{
					ComPort.RxBlockSize = FQueue[0].ReplyLength;
					ComPort.RxBlockTerminator = FQueue[0].ReplyEnd;

					if (FQueue[0].ReplyEnd != string.Empty)
					{
						ComPort.RxBlockMode = FQueue[0].rbTerminator;
					}
					else if (FQueue[0].ReplyLength > 0)
					{
						ComPort.RxBlockMode = FQueue[0].rbBlockSize;
					}
					else
					{
						ComPort.RxBlockMode = FQueue[0].rbChar;
					}
				}

				//log
				switch (FQueue[0].Kind)
				{
					case MissedLogic.ckInit:
						S = "init";
						break;

					case MissedLogic.ckWrite:
						S = FRigCommands.ParamToStr(FQueue[0].Param);
						break;

					case MissedLogic.ckStatus:
						S = "status";
						break;

					case MissedLogic.ckCustom:
						S = "custom";
						break;
				}

				MainForm.Log("RIG{0} sending {1} command: {2}", new string[] { Convert.ToString(RigNumber), S, ((string)MissedLogic.BytesToHex(FQueue[0].Code)) });
				//send command
				FQueue.Phase = MissedLogic.phSending;
				FDeadLineTime = DateTime.Now + CustRigUnit.DinMS * TimeoutMs;
				// ISPIRER
				//with FQueue[0] do
				ComPort.Send(FQueue[0].BytesToStr(FQueue[0].Code));
				///*!*/ debug
				MainForm.Log("RIG{0} ComPort.Send called, {1} bytes in TX buffer", new string[] { Convert.ToString(RigNumber), ComPort.TxQueue });
			}
			finally
			{
				UnLock();
			}
		}
	}


	public void ForceVfo(TRigParam Value)
	{
		if (Enabled)
		{
			AddWriteCommand(Value);
		}
	}




	public string GetStatusStr()
	{
		string getStatusStr_result = string.Empty;
		string[] StatusStr = new string[] { "Rig is not configured", "Rig is disabled", "Port is not available", "Rig is not responding", "On-line" };
		getStatusStr_result = StatusStr[GetStatus()];
		return getStatusStr_result;
	}
	public TRigCommands RigCommands
	{
		get
		{
			return FRigCommands;
		}
		set
		{
			SetRigCommands(value);
		}
	}
	public bool Enabled
	{
		get
		{
			return FEnabled;
		}
		set
		{
			SetEnabled(value);
		}
	}
	public TRigCtlStatus Status
	{
		get
		{
			return GetStatus();
		}
	}
	public int Freq
	{
		get
		{
			return FFreq;
		}
		set
		{
			SetFreq(value);
		}
	}
	public int FreqA
	{
		get
		{
			return FFreqA;
		}
		set
		{
			SetFreqA(value);
		}
	}
	public int FreqB
	{
		get
		{
			return FFreqB;
		}
		set
		{
			SetFreqB(value);
		}
	}
	public int Pitch
	{
		get
		{
			return FPitch;
		}
		set
		{
			SetPitch(value);
		}
	}
	public int RitOffset
	{
		get
		{
			return FRitOffset;
		}
		set
		{
			SetRitOffset(value);
		}
	}
	public TRigParam Vfo
	{
		get
		{
			return FVfo;
		}
		set
		{
			SetVfo(value);
		}
	}
	public TRigParam Split
	{
		get
		{
			return GetSplit();
		}
		set
		{
			SetSplit(value);
		}
	}
	public TRigParam Rit
	{
		get
		{
			return FRit;
		}
		set
		{
			SetRit(value);
		}
	}
	public TRigParam Xit
	{
		get
		{
			return FXit;
		}
		set
		{
			SetXit(value);
		}
	}
	public TRigParam Tx
	{
		get
		{
			return FTx;
		}
		set
		{
			SetTx(value);
		}
	}
	public TRigParam Mode
	{
		get
		{
			return FMode;
		}
		set
		{
			SetMode(value);
		}
	}
}
public partial class CustRigUnit
{
	public static readonly int MAX_TIMEOUT = 6;
	public static readonly int WM_TXQUEUE = 0x0400 + 1;
	public static readonly int WM_COMSTATUS = 0x0400 + 2;
	public static readonly int WM_COMPARAMS = 0x0400 + 3;
	public static readonly int WM_COMCUSTOM = 0x0400 + 4;
	public static readonly int NEVER = 999999;
	public static readonly double DinMS = 1 / 86400000;
}
