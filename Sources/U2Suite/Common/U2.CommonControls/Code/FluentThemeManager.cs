using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Themes.Fluent;
using Avalonia.ThemeManager;

namespace U2.Common;

public class FluentThemeManager : IThemeManager
{
	private static readonly FluentTheme s_fluent = new();

	public void Switch(int index)
	{
		if (Application.Current is null)
		{
			return;
		}

		Application.Current.RequestedThemeVariant = index switch
		{
			0 => ThemeVariant.Light,
			1 => ThemeVariant.Dark,
			_ => Application.Current.RequestedThemeVariant
		};
	}

	public void Initialize(Application application)
	{
		application.Styles.Insert(0, s_fluent);
	}
}
