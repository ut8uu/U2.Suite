using System;
using System.Collections.Generic;
using System.Text;
using MaterialThemeCore;
using MaterialThemeCore.MaterialControls;

namespace U2.Core
{
    public static class MaterialThemeUtilities
    {
        public static MaterialTheme CreateMaterialThemeInstance(MaterialThemeForm form)
        {
            var materialTheme = MaterialTheme.Instance;
            materialTheme.AddFormToManage(form);
            materialTheme.Theme = MaterialTheme.Themes.LIGHT;
            materialTheme.MaterialColor = new MaterialColor(
                Primary.BlueGrey800,
                Primary.BlueGrey900,
                Primary.BlueGrey500,
                Accent.LightBlue200,
                TextShade.WHITE);

            return materialTheme;
        }
    }
}
