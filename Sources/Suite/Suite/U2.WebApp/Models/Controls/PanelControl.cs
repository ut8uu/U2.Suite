﻿namespace U2.WebApp;

public sealed class PanelControl : ContainerControl
{
	public PanelControl(string name, List<VisualControl> items) 
		: base(name, "/Views/CommonControls/Panel.cshtml")
	{
		this.Children = items;
	}
}
