namespace U2.WebApp;

public class CallInfoControl : VisualControl
{
	public CallInfoControl(string name, CisCallInfo callInfo) 
		: base(name, "CallInfo")
	{
		CallInfo = callInfo;
	}

	public CisCallInfo CallInfo { get; }
}
