using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Linq;
using DynamicData;
using U2.MultiRig;

namespace U2.MultiRig;



//adds command generation and interpretation to the base class

public partial class TRig : TCustomRig
{
	public TRig()
	{
	}
	//value to bytes








	////////////////////////////////////////////////////////////////////////////////
	//                                format
	////////////////////////////////////////////////////////////////////////////////
	private TByteArray FormatValue(int AValue, TParamValue AInfo)
	{
		TByteArray formatValue_result = new TByteArray();
		int Value = 0;
		Value = Convert.ToInt32(Math.Round(Convert.ToDouble(AValue * AInfo.Mult + AInfo.Add), MidpointRounding.AwayFromZero));
		formatValue_result = null;
		Array.Resize(ref formatValue_result, AInfo.Len);

		if ((new[] { MissedLogic.vfBcdLU, MissedLogic.vfBcdBU }.Contains(AInfo.Format)) && (Value < 0))
		{
			MainForm.Log("RIG{0}: {!}user passed invalid value: {1}", new string[] { MissedLogic.RigNumber, Convert.ToString(AValue) });
			return formatValue_result;
		}

		switch (AInfo.Format)
		{
			case MissedLogic.vfText:
				ToText(formatValue_result, Value);
				break;

			case MissedLogic.vfBinL:
				ToBinL(formatValue_result, Value);
				break;

			case MissedLogic.vfBinB:
				ToBinB(formatValue_result, Value);
				break;

			case MissedLogic.vfBcdLU:
				ToBcdLU(formatValue_result, Value);
				break;

			case MissedLogic.vfBcdLS:
				ToBcdLS(formatValue_result, Value);
				break;

			case MissedLogic.vfBcdBU:
				ToBcdBU(formatValue_result, Value);
				break;

			case MissedLogic.vfBcdBS:
				ToBcdBS(formatValue_result, Value);
				break;

			case MissedLogic.vfYaesu:
				ToYaesu(formatValue_result, Value);
				break;

			case MissedLogic.vfDPIcom:
				ToDPIcom(formatValue_result, Value);
				break;

			case MissedLogic.vfTextUD:
				ToTextUD(formatValue_result, Value);
				break;

			case MissedLogic.vfFloat:
				ToFloat(formatValue_result, Value);
				break;
		}

		return formatValue_result;
	}



	//ASCII codes of digits
	private void ToText(TByteArray Arr, int Value)
	{
		int Len = 0;
		string S = string.Empty;
		Len = Arr.Length;

		if (Value < 0)
		{
			Len--;
		}

		S = String.Format("%%.0{0:d}d", Len);
		S = String.Format(S, Value);
		MissedLogic.Move(S[0], Arr[0], S.Length);
		//  S := StringOfChar('0', Length(Arr)) + IntToStr(Value);
		//  Move(S[Length(S)-Length(Arr)+1], Arr[0], Length(Arr));
	}



	//BCD big endian signed
	private void ToBcdBS(TByteArray Arr, int Value)
	{
		ToBcdBU(Arr, Math.Abs(Value));

		if (Value < 0)
		{
			Arr[0] = 0xFF;
		}
	}



	//BCD big endian unsigned
	private void ToBcdBU(TByteArray Arr, int Value)
	{
		TByteArray Chars = new TByteArray();
		int i = 0;
		Array.Resize(ref Chars, Arr.Length * 2);
		ToText(Chars, Value);

		for (i = 0; i <= Arr.Length - 1; i++)
		{
			Arr[i] = ((Chars[i * 2] - Convert.ToInt32("0")) << 4) || (Chars[i * 2 + 1] - Convert.ToInt32("0"));
		}
	}



	//BCD little endian signed; sign in high byte (00 or FF)
	private void ToBcdLS(TByteArray Arr, int Value)
	{
		ToBcdLU(Arr, Math.Abs(Value));

		if (Value < 0)
		{
			Arr[Arr.Length - 1] = 0xFF;
		}
	}



	//BCD little endian unsigned
	private void ToBcdLU(TByteArray Arr, int Value)
	{
		ToBcdBU(Arr, Value);
		MissedLogic.BytesReverse(Arr);
	}



	//integer, big endian
	private void ToBinB(TByteArray Arr, int Value)
	{
		ToBinL(Arr, Value);
		MissedLogic.BytesReverse(Arr);
	}



	//integer, little endian
	private void ToBinL(TByteArray Arr, int Value)
	{
		MissedLogic.Move(Value, Arr[0], Math.Min(Arr.Length, Marshal.SizeOf(Value)));
	}
	// Added by RA6UAZ for Icom Marine Radio NMEA Command


	// Added by RA6UAZ for Icom Marine Radio NMEA Command
	private void ToDPIcom(TByteArray Arr, int Value)
	{
		string S = string.Empty;
		float F = 0;
		/*   {$IFNDEF VER200}*/
		CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
		F = Value / 1000000;
		S = new string('0', Arr.Length) + Convert.ToString(F);
		MissedLogic.Move(S[S.Length - Arr.Length + 1 - 1], Arr[0], Arr.Length);
	}



	//16 bits. high bit of the 1-st byte is sign,
	//the rest is integer, absolute value, big endian (not complementary!)
	private void ToYaesu(TByteArray Arr, int Value)
	{
		ToBinB(Arr, Math.Abs(Value));

		if (Value < 0)
		{
			Arr[0] = Arr[0] | 0x80;
		}
	}
	//bytes to value









	////////////////////////////////////////////////////////////////////////////////
	//                                unformat
	////////////////////////////////////////////////////////////////////////////////
	private int UnformatValue(TByteArray AData, TParamValue AInfo)
	{
		int unformatValue_result = 0;
		AData = AData.SafeSubstring(AInfo.Start - 1, AInfo.Len);

		if ((AData == null) || (AData.Length != AInfo.Len))
		{
			MainForm.Log("RIG{0}: {!}reply too short", new string[] { MissedLogic.RigNumber });
			throw new AbortException();
		}

		switch (AInfo.Format)
		{
			case MissedLogic.vfText:
				unformatValue_result = FromText(AData);
				break;

			case MissedLogic.vfBinL:
				unformatValue_result = FromBinL(AData);
				break;

			case MissedLogic.vfBinB:
				unformatValue_result = FromBinB(AData);
				break;

			case MissedLogic.vfBcdLU:
				unformatValue_result = FromBcdLU(AData);
				break;

			case MissedLogic.vfBcdLS:
				unformatValue_result = FromBcdLS(AData);
				break;

			case MissedLogic.vfBcdBU:
				unformatValue_result = FromBcdBU(AData);
				break;

			case MissedLogic.vfBcdBS:
				unformatValue_result = FromBcdBS(AData);
				break;

			case MissedLogic.vfDPIcom:
				unformatValue_result = FromDPIcom(AData);
				break;

			case MissedLogic.vfFloat:
				unformatValue_result = FromFloat(AData);
				break;

			default:
				unformatValue_result = FromYaesu(AData);
				break;
		}

		unformatValue_result = Convert.ToInt32(Math.Round(Convert.ToDouble(unformatValue_result * AInfo.Mult + AInfo.Add), MidpointRounding.AwayFromZero));
		return unformatValue_result;
	}









////////////////////////////////////////////////////////////////////////////////
//                           interpret reply
////////////////////////////////////////////////////////////////////////////////
	private bool ValidateReply(TByteArray AData, TBitMask AMask)
	{
		bool validateReply_result = false;

		if (AMask.Mask == null)
		{
			validateReply_result = true;
		}
		else if (AData.Length != AMask.Mask.Length)
		{
			validateReply_result = false;
		}
		else if (AData.Length != AMask.Flags.Length)
		{
			validateReply_result = false;
		}
		else
		{
			validateReply_result = ((bool)MissedLogic.BytesEqual(MissedLogic.BytesAnd(AData, AMask.Mask), AMask.Flags));
		}

		if (!validateReply_result)
		{
			MainForm.Log("{!}RIG{0} reply validation failed", new string[] { MissedLogic.RigNumber });
		}

		return validateReply_result;
	}



	private void ToTextUD(TByteArray Arr, int Value)
	{
		string S = string.Empty;
		S = new string('0', Arr.Length) + Convert.ToString(Math.Abs(Value));

		if (Value >= 0)
		{
			Arr[0] = Convert.ToInt32("U");
		}
		else
		{
			Arr[0] = Convert.ToInt32("D");
		}

		MissedLogic.Move(S[S.Length - Arr.Length + 2 - 1], Arr[1], Arr.Length - 1);
	}


	private void ToFloat(TByteArray Arr, int Value)
	{
		string S = string.Empty;
		/*   {$IFNDEF VER200}*/
		CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
		S = String.Format("%.2f", Arr.Length, Value);
		MissedLogic.Move(S[0], Arr[0], Arr.Length);
	}
	protected TRigParamSet ChangedParams = new TRigParamSet();

	//add commands to the queue




	/* TRig */

	////////////////////////////////////////////////////////////////////////////////
	//                          add command to queue
	////////////////////////////////////////////////////////////////////////////////
	protected override void AddCommands(TRigCommandArray ACmds, TCommandKind AKind)
	{
		int i = 0;
		MissedLogic.Lock();

		try
		{
			for (i = 0; i <= ACmds.Length - 1; i++)
			{
				// ISPIRER
				//with FQueue.Add do
				MissedLogic.Code = ACmds[i].Code;
				MissedLogic.Number = i;
				MissedLogic.ReplyLength = ACmds[i].ReplyLength;
				MissedLogic.ReplyEnd = MissedLogic.BytesToStr(ACmds[i].ReplyEnd);
				MissedLogic.Kind = AKind;
			}
		}
		finally
		{
			MissedLogic.Unlock();
		}
	}
	//interpret reply



	protected override void ProcessInitReply(int ANumber, TByteArray AData)
	{
		ValidateReply(AData, RigCommands.InitCmd[ANumber].Validation);
	}



	protected override void ProcessStatusReply(int ANumber, TByteArray AData)
	{
		int i = 0;
		PRigCommand Cmd = new PRigCommand();
		//validate reply
		Cmd = RigCommands.StatusCmd[ANumber];

		if (!ValidateReply(AData, Cmd.Validation))
		{
			return;
		}

		//extract numeric values
		for (i = 0; i <= Cmd.Values.Length - 1; i++)
		{
			try
			{
				StoreParam(Cmd.Values[i].Param, UnformatValue(AData, Cmd.Values[i]));
			}
			catch (Exception ex)
			{
			}
		}

		//extract bit flags
		for (i = 0; i <= Cmd.Flags.Length - 1; i++)
		{
			if ((AData.Length != Cmd.Flags[i].Mask.Length) || (AData.Length != Cmd.Flags[i].Flags.Length))
			{
				MainForm.Log("{!}RIG{0}: incorrect reply length", new string[] { MissedLogic.RigNumber });
			}
			else if (MissedLogic.BytesEqual(MissedLogic.BytesAnd(AData, Cmd.Flags[i].Mask), Cmd.Flags[i].Flags))
			{
				StoreParam(Cmd.Flags[i].Param);
			}
		}

		//tell clients
		if (ChangedParams != new string[] { })
		{
			MissedLogic.ComNotifyParams(MissedLogic.RigNumber, MissedLogic.ParamsToInt(ChangedParams));
		}
		ChangedParams = new string[] { };
	}



	protected override void ProcessWriteReply(TRigParam AParam, TByteArray AData)
	{
		ValidateReply(AData, RigCommands.WriteCmd[AParam].Validation);
	}



	protected override void ProcessCustomReply(object ASender, TByteArray ACode, TByteArray AData)
	{
		MissedLogic.Lock();

		try
		{
			MissedLogic.TOmniRigX(ASender).CustCommand = ACode;
			MissedLogic.TOmniRigX(ASender).CustReply = AData;
		}
		finally
		{
			MissedLogic.Unlock();
		}

		MissedLogic.ComNotifyCustom(MissedLogic.RigNumber, ASender);
	}
	//add command to the queue



	public override void AddWriteCommand(TRigParam AParam, int AValue = 0)
	{
		TRigCommand Cmd = new TRigCommand();
		TByteArray NewCode = new TByteArray();
		TByteArray FmtValue = new TByteArray();
		MainForm.Log("RIG{0} Generating Write command for {1}", new string[] { MissedLogic.RigNumber, RigCommands.ParamToStr(AParam) });

		//is cmd supported?
		if (MissedLogic.RigCommands == null)
		{
			return;
		}

		Cmd = RigCommands.WriteCmd[AParam];

		if (Cmd.Code == null)
		{
			MainForm.Log("RIG{0} {!}Write command not supported for {1}", new string[] { MissedLogic.RigNumber, RigCommands.ParamToStr(AParam) });
			return;
		}

		//generate cmd
		NewCode = Cmd.Code;
		FmtValue = null;

		if (Cmd.Value.Format != MissedLogic.vfNone)
		{
			try
			{
				FmtValue = FormatValue(AValue, Cmd.Value);

				if (Cmd.Value.Start + Cmd.Value.Len > NewCode.Length)
				{
					throw new Exception("{!}Value too long");
				}

				MissedLogic.Move(FmtValue[0], NewCode[Cmd.Value.Start], Cmd.Value.Len);
			}
			catch (Exception E)
			{
				MainForm.Log("RIG% {!}Generating command: {1}", new string[] { RigNumber, E.Message });
			}
		}

		//add to queue
		MissedLogic.Lock();

		try
		{
			// ISPIRER
			//with FQueue.AddBeforeStatusCommands do
			MissedLogic.Code = string.Copy(NewCode,);
			Param = AParam;
			MissedLogic.Kind = MissedLogic.ckWrite;
			MissedLogic.ReplyLength = Cmd.ReplyLength;
			MissedLogic.ReplyEnd = MissedLogic.BytesToStr(Cmd.ReplyEnd);
		}
		finally
		{
			MissedLogic.Unlock();
		}

		//reminder to check queue
		External.PostMessage(MainForm.Handle, MissedLogic.WM_TXQUEUE, (IntPtr)MissedLogic.RigNumber, (IntPtr)0);
	}



	public override void AddCustomCommand(object ASender, TByteArray ACode, int ALen, string AEnd)
	{
		if (ACode == null)
		{
			return;
		}

		MissedLogic.Lock();

		try
		{
			// ISPIRER
			//with FQueue.Add do
			MissedLogic.Code = ACode;
			MissedLogic.Kind = MissedLogic.ckCustom;
			MissedLogic.CustSender = ASender;
			MissedLogic.ReplyLength = ALen;
			MissedLogic.ReplyEnd = AEnd;
		}
		finally
		{
			MissedLogic.Unlock();
		}

		External.PostMessage(MainForm.Handle, MissedLogic.WM_TXQUEUE, (IntPtr)MissedLogic.RigNumber, (IntPtr)0);
	}

	private int FromBcdBS(TByteArray AData)
	{
		int fromBcdBS_result = 0;

		if (AData[0] == 0)
		{
			fromBcdBS_result = 1;
		}
		else
		{
			fromBcdBS_result = -1;
		}

		AData[0] = 0;
		fromBcdBS_result = fromBcdBS_result * FromBcdBU(AData);
		return fromBcdBS_result;
	}



	private int FromBcdBU(TByteArray AData)
	{
		int fromBcdBU_result = 0;
		string S = string.Empty;
		int i = 0;
		S = S.Substring(0, AData.Length * 2);

		for (i = 0; i <= AData.Length - 1; i++)
		{
			S = S.Remove(i * 2 + 1 - 1, 1).Insert(i * 2 + 1 - 1, ((string)MissedLogic.AnsiChar(Convert.ToInt32("0") + ((AData[i] >> 4) & 0x0F))));
			S = S.Remove(i * 2 + 2 - 1, 1).Insert(i * 2 + 2 - 1, ((string)MissedLogic.AnsiChar(Convert.ToInt32("0") + (AData[i] & 0x0F))));
		}

		try
		{
			fromBcdBU_result = Convert.ToInt32(S);
		}
		catch (Exception ex)
		{
			MainForm.Log("RIG{0}: {!}invalid BCD value", new string[] { MissedLogic.RigNumber });
			throw;
		}

		return fromBcdBU_result;
	}



	private int FromBcdLS(TByteArray AData)
	{
		int fromBcdLS_result = 0;
		MissedLogic.BytesReverse(AData);
		fromBcdLS_result = FromBcdBS(AData);
		return fromBcdLS_result;
	}



	private int FromBcdLU(TByteArray AData)
	{
		int fromBcdLU_result = 0;
		MissedLogic.BytesReverse(AData);
		fromBcdLU_result = FromBcdBU(AData);
		return fromBcdLU_result;
	}



	private int FromBinB(TByteArray AData)
	{
		int fromBinB_result = 0;
		MissedLogic.BytesReverse(AData);
		fromBinB_result = FromBinL(AData);
		return fromBinB_result;
	}



	private int FromBinL(TByteArray AData)
	{
		int fromBinL_result = 0;
		int B = 0;

		//propagate sign if AData is less than 4 bytes
		if ((AData[AData.Length - 1] & 0x80) == 0x80)
		{
			B = -1;
		}
		else
		{
			B = 0;
		}

		//copy data
		MissedLogic.Move(AData[0], B, Math.Min(AData.Length, Marshal.SizeOf(B)));
		fromBinL_result = B;
		return fromBinL_result;
	}




	/* TRig */


	private int FromText(TByteArray AData)
	{
		int fromText_result = 0;
		string S = string.Empty;
		S = S.Substring(0, AData.Length);

		try
		{
			MissedLogic.Move(AData[0], S[0], S.Length);
			fromText_result = Convert.ToInt32(S);
		}
		catch (Exception ex)
		{
			MainForm.Log("RIG{0}: {!}invalid reply", new string[] { MissedLogic.RigNumber });
			throw;
		}

		return fromText_result;
	}
	// Added by RA6UAZ for Icom Marine Radio NMEA Command


	// Added by RA6UAZ for Icom Marine Radio NMEA Command
	private int FromDPIcom(TByteArray AData)
	{
		int fromDPIcom_result = 0;
		string S = string.Empty;
		int i = 0;

		try
		{
			/*     {$IFNDEF VER200}*/
			CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
			S = S.Substring(0, AData.Length);
			MissedLogic.Move(AData[0], S[0], S.Length);

			for (i = 1; i <= S.Length; i++)
			{
				if (!(new Range<char>('0', '9').Union(new[] { '.', ' ' }).Contains(S[i - 1])))
				{
					S = S.Substring(0, i - 1);
					break;
				}
			}

			fromDPIcom_result = Convert.ToInt32(Math.Round(Convert.ToDouble(1E6 * Convert.ToDouble(S.Trim())), MidpointRounding.AwayFromZero));
		}
		catch (Exception ex)
		{
			MainForm.Log("RIG{0}: {!}invalid reply", new string[] { MissedLogic.RigNumber });
			throw;
		}

		return fromDPIcom_result;
	}



	//16 bits. high bit of the 1-st byte is sign,
	//the rest is integer, absolute value, big endian (not complementary!)
	private int FromYaesu(TByteArray AData)
	{
		int fromYaesu_result = 0;

		if ((AData[0] & 0x80) == 0)
		{
			fromYaesu_result = 1;
		}
		else
		{
			fromYaesu_result = -1;
		}

		AData[0] = AData[0] & 0x7F;
		fromYaesu_result = fromYaesu_result * FromBinB(AData);
		return fromYaesu_result;
	}







	////////////////////////////////////////////////////////////////////////////////
	//                         store extracted param
	////////////////////////////////////////////////////////////////////////////////
	private void StoreParam(TRigParam Param)
	{
		PRigParam PParam = new PRigParam();

		if (VfoParams.Contains(Param))
		{
			PParam = ((PRigParam)MissedLogic.FVfo);
		}
		else if (SplitParams.Contains(Param))
		{
			PParam = ((PRigParam)MissedLogic.FSplit);
		}
		else if (RitOnParams.Contains(Param))
		{
			PParam = ((PRigParam)MissedLogic.FRit);
		}
		else if (XitOnParams.Contains(Param))
		{
			PParam = ((PRigParam)MissedLogic.FXit);
		}
		else if (TxParams.Contains(Param))
		{
			PParam = ((PRigParam)MissedLogic.FTx);
		}
		else if (ModeParams.Contains(Param))
		{
			PParam = ((PRigParam)MissedLogic.FMode);
		}
		else
		{
			return;
		}

		if (Param == PParam)
		{
			return;
		}

		PParam = Param;
		ChangedParams.Include(Param);

		//unsolved problem:
		//there is no command to read the mode of the other VFO,
		//its change goes undetected.
		if ((ModeParams.Contains(Param)) && (Param != ((TRigParam)MissedLogic.LastWrittenMode)))
{
			MissedLogic.LastWrittenMode = TPenMode.pmNone;
		}

		MainForm.Log("RIG{0} status changed: {1} enabled", new string[] { MissedLogic.RigNumber, RigCommands.ParamToStr(Param) });
	}



	private void StoreParam(TRigParam Param, int Value)
	{
		PInteger PValue = new PInteger();
switch (Param)
{
			case TPenMode.pmFreqA:
				PValue = ((PInteger)MissedLogic.FFreqA);
break;

			case TPenMode.pmFreqB:
				PValue = ((PInteger)MissedLogic.FFreqB);
break;

			case TPenMode.pmFreq:
				PValue = ((PInteger)MissedLogic.FFreq);
				break;

			case TPenMode.pmPitch:
				PValue = ((PInteger)MissedLogic.FPitch);
				break;

			case TPenMode.pmRitOffset:
				PValue = ((PInteger)MissedLogic.FRitOffset);
				break;

			default:
				return;
		}

		if (Value == PValue)
		{
			return;
		}

		PValue = Value;
		ChangedParams.Include(Param);
		MainForm.Log("RIG{0} status changed: {1} = {2}", new string[] { MissedLogic.RigNumber, RigCommands.ParamToStr(Param), Convert.ToString(Value) });
	}



	private int FromFloat(TByteArray AData)
	{
		int fromFloat_result = 0;
		string S = string.Empty;

		try
		{
			S = S.Substring(0, AData.Length);
			MissedLogic.Move(AData[0], S[0], S.Length);
			/*     {$IFNDEF VER200}*/
			CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator = ".";
			fromFloat_result = Convert.ToInt32(Math.Round(Convert.ToDouble(Convert.ToDouble(S.Trim())), MidpointRounding.AwayFromZero));
		}
		catch (Exception ex)
		{
			MainForm.Log("RIG{0}: {!}invalid reply", new string[] { MissedLogic.RigNumber });
			throw;
		}

		return fromFloat_result;
	}
	protected TRigParamSet ChangedParams = new TRigParamSet();

}
