using System;
using System.IO;
using System.Data;
using System.Windows;
using System.Threading;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;

namespace U2.MultiRig;

public abstract class BaseThread
{
	private Thread _thread;
	protected BaseThread()
	{
		_thread = new Thread(new ThreadStart(this.Execute));
	}

	protected BaseThread(bool b)
	{
		if (b)
		{
			_thread = new Thread(new ThreadStart(this.Execute));
		}
	}

	// Thread methods / properties
	public void Start()
	{
		_thread.Start();
	}
	public void Join()
	{
		_thread.Join();
	}
	public bool IsAlive
	{
		get
		{
			return _thread.IsAlive;
		}
	}

	// Override in base class
	public abstract void Execute();

	public ThreadPriority Priority
	{
		get
		{
			return _thread.Priority;
		}
		set
		{
			_thread.Priority = value;
		}
	}
}
public enum TStopBits
{
	sbOne, sbOne_5, sbTwo
}

public enum TParity
{
	ptNone, ptOdd, ptEven, ptMark, ptSpace
}

public enum TFlowControl
{
	fcLow, fcHigh, fcHandShake
}

public enum TRxBlockMode
{
	rbChar, rbBlockSize, rbTerminator
}

public struct _DCB
{
	public int DCBlength;
	public int BaudRate;
	public int Flags;
	public int wReserved;
	public int XonLim;
	public int XoffLim;
	public byte ByteSize;
	public byte Parity;
	public byte StopBits;
	public char XonChar;
	public char XoffChar;
	public char ErrorChar;
	public char EofChar;
	public char EvtChar;
	public int wReserved1;
}


public partial class TAlCommPort
{
	internal IntPtr FPortHandle = new IntPtr();
	internal _DCB FDcb = new _DCB();
	internal TCommTimeouts FOldTimeouts = new TCommTimeouts();
	internal TPortThread FThread = new TPortThread();
	internal TOverLapped WrOverlapped = new TOverLapped();
	internal TOverLapped RdOverLapped = new TOverLapped();
	internal TNotifyEvent FOnReceived = new TNotifyEvent();
	internal TNotifyEvent FOnError = new TNotifyEvent();
	internal TNotifyEvent FOnSent = new TNotifyEvent();
	internal bool FLastDtrBit = false;
	internal bool FLastRtsBit = false;
	internal TFlowControl FRtsMode;
	internal TFlowControl FDtrMode;
	internal TNotifyEvent FOnCtsDsr = new TNotifyEvent();



	private void SetBaudRate(int Value)
	{
		FDcb.BaudRate = Value;
	}


	private void SetDataBits(int Value)
	{
		FDcb.ByteSize = (byte)Math.Max(5, Math.Min(8, Value));
	}


	private void SetParity(TParity Value)
	{
		FDcb.Parity = (byte)Convert.ToInt32(Value);
	}


	private void SetStopBits(TStopBits Value)
	{
		FDcb.StopBits = (byte)Convert.ToInt32(Value);
	}

	////////////////////////////////////////////////////////////////////////////////
	//                                 get/set
	////////////////////////////////////////////////////////////////////////////////
	private int GetBaudRate()
	{
		int getBaudRate_result = 0;
		getBaudRate_result = FDcb.BaudRate;
		return getBaudRate_result;
	}

	private int GetDataBits()
	{
		int getDataBits_result = 0;
		getDataBits_result = FDcb.ByteSize;
		return getDataBits_result;
	}

	private TParity GetParity()
	{
		TParity getParity_result = new TParity();
		getParity_result = ((TParity)FDcb.Parity);
		return getParity_result;
	}
	
	private TStopBits GetStopBits()
	{
		TStopBits getStopBits_result = new TStopBits();
		getStopBits_result = ((TStopBits)FDcb.StopBits);
		return getStopBits_result;
	}

	////////////////////////////////////////////////////////////////////////////////
	//                             open/close
	////////////////////////////////////////////////////////////////////////////////
	private void SetOpen(bool Value)
	{
		if (Value == Open)
		{
			return;
		}

		if (Value)
		{
			OpenPort();
		}
		else
		{
			ClosePort();
		}
	}

	private void OpenPort()
	{
		string PortName = string.Empty;
		//open port
		PortName = ((string)MissedLogic.AnsiString(String.Format("\\\\\\\\.\\\\COM{0:d}", Port)));
		FPortHandle = ((THandle)MissedLogic.CreateFileA(PortName.ToString(), MissedLogic.GENERIC_READ || MissedLogic.GENERIC_WRITE, 0, null, MissedLogic.OPEN_EXISTING, MissedLogic.FILE_FLAG_OVERLAPPED, 0));

		if (FPortHandle == (IntPtr)MissedLogic.INVALID_HANDLE_VALUE)
		{
			return;
		}

		try
		{
			//set port params
			if (!MissedLogic.SetupComm(FPortHandle, AlComPrtUnit.BUF_SIZE, AlComPrtUnit.BUF_SIZE))
			{
				throw new AbortException();
			}

			if (!MissedLogic.SetCommState(FPortHandle, FDcb))
			{
				throw new AbortException();
			}

			if (!MissedLogic.GetCommTimeouts(FPortHandle, FOldTimeouts))
			{
				throw new AbortException();
			}

			if (!MissedLogic.SetCommTimeouts(FPortHandle, AlComPrtUnit.NewTimeouts))
			{
				throw new AbortException();
			}

			if (!MissedLogic.SetCommMask(FPortHandle, MissedLogic.EV_TXEMPTY || MissedLogic.EV_RXCHAR || MissedLogic.EV_ERR || MissedLogic.EV_CTS || MissedLogic.EV_DSR || MissedLogic.EV_RLSD))
			{
				throw new AbortException();
			}

			//start sending/receiving
			FThread = new TPortThread(this);
		}
		//could not configure port, close it
		catch (Exception ex)
{
MissedLogic.CloseHandle(FPortHandle);
			FPortHandle = ((THandle)MissedLogic.INVALID_HANDLE_VALUE);
		}
	}




	private void ClosePort()
	{
		PurgeRx();
		PurgeTx();

		if (FThread != null)
		{
			FThread.Stop();
		}

		MissedLogic.SetCommTimeouts(FPortHandle, FOldTimeouts);
MissedLogic.CloseHandle(FPortHandle);
		FPortHandle = ((THandle)MissedLogic.INVALID_HANDLE_VALUE);
	}




	public void DataFromPort()
	{
		uint OldCnt = 0;
		uint Cnt = 0;
		bool Fire = false;
		int Errors = 0;
		TComStat ComStat = new TComStat();
		//read rx count
		MissedLogic.ClearCommError(FPortHandle, Errors, ComStat);
		Cnt = ComStat.cbInQue;

		if (Cnt == 0)
		{
			return;
		}

		//read bytes
		OldCnt = RxBuffer.Length;
		RxBuffer = RxBuffer.Substring(0, OldCnt + Cnt);
		RdOverLapped = new TOverLapped();
		MissedLogic.ReadFile(FPortHandle, RxBuffer[OldCnt + 1 - 1], Cnt, Cnt, RdOverLapped);

		//fire rx event according to RxBlockMode
		switch (RxBlockMode)
		{
			case TRxBlockMode.rbBlockSize:
				Fire = RxBuffer.Length >= RxBlockSize;
				break;

			case TRxBlockMode.rbTerminator:
				Fire = (RxBuffer.IndexOf(RxBlockTerminator) + 1) > 0;
				break;

			default:
				Fire = true;
				break;
		}

		//purge buffer
		if (Fire)
		{
			FireRxEvent();
			RxBuffer = string.Empty;
		}
	}






	////////////////////////////////////////////////////////////////////////////////
	//                             fire events
	////////////////////////////////////////////////////////////////////////////////
	public void FireErrEvent()
	{
		if (FOnError != null)
		{
			FOnError(this);
		}
	}



	public void FireTxEvent()
	{
		if (FOnSent != null)
		{
			FOnSent(this);
		}
	}



	private void FireRxEvent()
	{
		if (FOnReceived != null)
		{
			FOnReceived(this);
		}
	}



	public void FireCtsDsrEvent()
	{
		if (FOnCtsDsr != null)
		{
			FOnCtsDsr(this);
		}
	}


	private bool GetOpen()
	{
		bool getOpen_result = false;
		getOpen_result = FPortHandle != (IntPtr)MissedLogic.INVALID_HANDLE_VALUE;
		return getOpen_result;
	}







	////////////////////////////////////////////////////////////////////////////////
	//                             control bits
	////////////////////////////////////////////////////////////////////////////////
	private bool GetCtsBit()
	{
		bool getCtsBit_result = false;
		int ModemStat = 0;
		MissedLogic.GetCommModemStatus(FPortHandle, ModemStat);
		getCtsBit_result = (ModemStat & MissedLogic.MS_CTS_ON) != 0;
		return getCtsBit_result;
	}


	private bool GetDsrBit()
	{
		bool getDsrBit_result = false;
		int ModemStat = 0;
		MissedLogic.GetCommModemStatus(FPortHandle, ModemStat);
		getDsrBit_result = (ModemStat & MissedLogic.MS_DSR_ON) != 0;
		return getDsrBit_result;
	}


	private bool GetDtrBit()
	{
		bool getDtrBit_result = false;
		getDtrBit_result = FLastDtrBit;
		return getDtrBit_result;
	}


	private bool GetRtsBit()
	{
		bool getRtsBit_result = false;
		getRtsBit_result = FLastRtsBit;
		return getRtsBit_result;
	}


	private bool GetRlsdBit()
	{
		bool getRlsdBit_result = false;
		int ModemStat = 0;
		MissedLogic.GetCommModemStatus(FPortHandle, ModemStat);
		getRlsdBit_result = (ModemStat & MissedLogic.MS_RLSD_ON) != 0;
		return getRlsdBit_result;
	}



	private void SetDtrBit(bool Value)
	{
		if (FDtrMode == TFlowControl.fcHandShake)
		{
			return;
		}

		if (Value)
		{
			MissedLogic.EscapeCommFunction(FPortHandle, MissedLogic.SETDTR);
		}
		else
		{
			MissedLogic.EscapeCommFunction(FPortHandle, MissedLogic.CLRDTR);
		}

		FLastDtrBit = Value;
	}


	private void SetRtsBit(bool Value)
	{
		if (FRtsMode == TFlowControl.fcHandShake)
		{
			return;
		}

		if (Value)
		{
			MissedLogic.EscapeCommFunction(FPortHandle, MissedLogic.SETRTS);
		}
		else
		{
			MissedLogic.EscapeCommFunction(FPortHandle, MissedLogic.CLRRTS);
		}

		FLastRtsBit = Value;
	}



	private void SetDtrMode(TFlowControl Value)
	{
		FDtrMode = Value;
		FDcb.Flags = AlComPrtUnit.DTRFLAGS[(int)FDtrMode] | AlComPrtUnit.RTSFLAGS[(int)FRtsMode] | AlComPrtUnit.OTHERFLAGS;
	}


	private void SetRtsMode(TFlowControl Value)
	{
		FRtsMode = Value;
		FDcb.Flags = AlComPrtUnit.DTRFLAGS[(int)FDtrMode] | AlComPrtUnit.RTSFLAGS[(int)FRtsMode] | AlComPrtUnit.OTHERFLAGS;
	}
	public int Port = 0;
	public string RxBuffer = string.Empty;
	public long TimeStamp = 0;
	public TRxBlockMode RxBlockMode;
	public int RxBlockSize = 0;
	public string RxBlockTerminator = string.Empty;









	/* TAlCommPort */

	////////////////////////////////////////////////////////////////////////////////
	//                                 system
	////////////////////////////////////////////////////////////////////////////////
	public TAlCommPort()
	{
		//fill in DCB
		FDcb = new TDCB();
		FDcb.DCBlength = Marshal.SizeOf(FDcb);
		FDcb.XonLim = AlComPrtUnit.BUF_SIZE / 2;
		FDcb.XoffLim = DelphiFunctions.MulDiv(AlComPrtUnit.BUF_SIZE, 3, 4);
		FDcb.XonChar = '\x0011';  //$11
		FDcb.XoffChar = '\x0013'; //$13
								  //set default comm paraams
		Port = 1;
		BaudRate = 19200;
		DataBits = 8;
		StopBits = TStopBits.sbOne;
		Parity = TParity.ptNone;
		FDtrMode = TFlowControl.fcLow;
RtsMode = TFlowControl.fcLow;
		FPortHandle = ((THandle)MissedLogic.INVALID_HANDLE_VALUE);
	}



	private bool disposed = false;
	protected void Dispose(bool disposing)
	{
		if (!this.disposed)
		{
			if (disposing)
			{
				Open = false;
			}
		}

		disposed = true;
	}







	////////////////////////////////////////////////////////////////////////////////
	//                             read/write
	////////////////////////////////////////////////////////////////////////////////
	public void PurgeRx()
	{
		MissedLogic.PurgeComm(FPortHandle, MissedLogic.PURGE_RXCLEAR || MissedLogic.PURGE_RXABORT);
		RxBuffer = string.Empty;
	}



	public void PurgeTx()
	{
		MissedLogic.PurgeComm(FPortHandle, MissedLogic.PURGE_TXCLEAR || MissedLogic.PURGE_TXABORT);
	}



	public void Send(string Msg)
	{
		int Cnt = 0;

		if (Msg == string.Empty)
		{
			return;
		}

		WrOverlapped = new TOverLapped();
		MissedLogic.WriteFile(FPortHandle, Msg[0], Msg.Length, Cnt, WrOverlapped);

		switch ((int)External.GetTickCount())
		{
			case MissedLogic.ERROR_SUCCESS:
				FireTxEvent();
				break;

			case MissedLogic.ERROR_IO_PENDING:
				return;

			default:
				FireErrEvent();
				break;
		}
	}





	public int TxQueue()
	{
		int txQueue_result = 0;
		int Errors = 0;
		TComStat ComStat = new TComStat();
		MissedLogic.ClearCommError(FPortHandle, Errors, ComStat);
		txQueue_result = ComStat.cbOutQue;
		return txQueue_result;
	}
	public int BaudRate
	{
		get
		{
			return GetBaudRate();
		}
		set
		{
			SetBaudRate(value);
		}
	}
	public int DataBits
	{
		get
		{
			return GetDataBits();
		}
		set
		{
			SetDataBits(value);
		}
	}
	public TStopBits StopBits
	{
		get
		{
			return GetStopBits();
		}
		set
		{
			SetStopBits(value);
		}
	}
	public TParity Parity
	{
		get
		{
			return GetParity();
		}
		set
		{
			SetParity(value);
		}
	}
	public TFlowControl DtrMode
	{
		get
		{
			return FDtrMode;
		}
		set
		{
			SetDtrMode(value);
		}
	}
	public TFlowControl RtsMode
	{
		get
		{
			return FRtsMode;
		}
		set
		{
			SetRtsMode(value);
		}
	}
	public bool Open
	{
		get
		{
			return GetOpen();
		}
		set
		{
			SetOpen(value);
		}
	}
	public bool RtsBit
	{
		get
		{
			return GetRtsBit();
		}
		set
		{
			SetRtsBit(value);
		}
	}
	public bool DtrBit
	{
		get
		{
			return GetDtrBit();
		}
		set
		{
			SetDtrBit(value);
		}
	}
	public bool CtsBit
	{
		get
		{
			return GetCtsBit();
		}
	}
	public bool DsrBit
	{
		get
		{
			return GetDsrBit();
		}
	}
	public bool RlsdBit
	{
		get
		{
			return GetRlsdBit();
		}
	}
	public TNotifyEvent OnError
	{
		get
		{
			return FOnError;
		}
		set
		{
			FOnError = value;
		}
	}
	public TNotifyEvent OnSent
	{
		get
		{
			return FOnSent;
		}
		set
		{
			FOnSent = value;
		}
	}
	public TNotifyEvent OnReceived
	{
		get
		{
			return FOnReceived;
		}
		set
		{
			FOnReceived = value;
		}
	}
	public TNotifyEvent OnCtsDsr
	{
		get
		{
			return FOnCtsDsr;
		}
		set
		{
			FOnCtsDsr = value;
		}
	}
}

public partial class TPortThread : BaseThread
{
	public TPortThread() : base()
	{
	}
	internal TAlCommPort FPapa = new TAlCommPort();
	internal IntPtr[] FWaitEvents = new IntPtr[2];
	internal TOverLapped WtOverlapped = new TOverLapped(); //overlapped struct for WaitCommEvent



	/* TPortThread */

	private TPortThread(TAlCommPort Papa) : base(true)
	{
		FPapa = Papa;
		//events
		FWaitEvents[0] = External.CreateEvent((IntPtr)null, true, false, null);
		FWaitEvents[1] = External.CreateEvent((IntPtr)null, true, false, null);
		//overlapped struct
		WtOverlapped = new TOverLapped();
		WtOverlapped.hEvent = FWaitEvents[1];
		//do not replace with Start, does not work
		MissedLogic.Resume();
	}



	public void Stop()
	{
		MissedLogic.SetEvent(FWaitEvents[0]);
		MissedLogic.WaitFor();
		FPapa.FThread = null;
		MissedLogic = null;
	}



	protected override void Execute()
	{
		int Occurred = 0;
		MissedLogic.Priority = MissedLogic.tpTimeCritical;

		while (!MissedLogic.Terminated)
		{
			MissedLogic.WaitCommEvent(FPapa.FPortHandle, Occurred, WtOverlapped);

			//wait for events
			switch (MissedLogic.WaitForMultipleObjects(2, FWaitEvents, false, MissedLogic.INFINITE))
			{
				case MissedLogic.WAIT_OBJECT_0:
					{
						MissedLogic.CloseHandle(FWaitEvents[0]);
						MissedLogic.CloseHandle(FWaitEvents[1]);
						MissedLogic.Terminate();
					}
					break;

				case MissedLogic.WAIT_OBJECT_0 + 1:
					{
						MissedLogic.QueryPerformanceCounter(FPapa.TimeStamp);

						//handle the event
						try
						{
							if ((Occurred & MissedLogic.EV_ERR) > 0)
							{
								MissedLogic.Synchronize(FPapa.FireErrEvent());
							}

							if ((Occurred & MissedLogic.EV_TXEMPTY) > 0)
							{
								MissedLogic.Synchronize(FPapa.FireTxEvent());
							}

							if ((Occurred & MissedLogic.EV_RXCHAR) > 0)
							{
								MissedLogic.Synchronize(FPapa.DataFromPort());
							}

							if ((Occurred & (MissedLogic.EV_CTS || MissedLogic.EV_DSR || MissedLogic.EV_RLSD)) > 0)
							{
								MissedLogic.Synchronize(FPapa.FireCtsDsrEvent());
							}
						}
						catch (Exception ex)
						{
							Application.HandleException(this);
						}
					}
					break;
			}
		}
	}
}


public partial class AlComPrtUnit
{
	public static readonly int BUF_SIZE = 1024;

	public static readonly TCommTimeouts NewTimeouts;


	/* TPortThread */











	////////////////////////////////////////////////////////////////////////////////
	//                              control mode
	////////////////////////////////////////////////////////////////////////////////

	//flow control flags

	// 1                    <- LSB
	// 0
	// X  obey CTS
	// 0
	//////////////
	// X  DTR
	// X  DTR
	// 0
	// 0
	//////////////
	// 0
	// 0
	// 0
	// 0
	//////////////
	// X  RTS
	// X  RTS
	// 0
	// 0                    <- MSB


	public static readonly int[] DTRFLAGS = new int[] { 0x0000, 0x0010, 0x0024 };
	public static readonly int[] RTSFLAGS = new int[] { 0x0000, 0x1000, 0x2004 };
	public static readonly int OTHERFLAGS = 0x0001;
}
