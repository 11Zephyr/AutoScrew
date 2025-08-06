using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoScrewSys.Base
{
    public static class LocalizationHelper
    {
        public static void ApplyLanguage(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                string value = Properties.Resources.ResourceManager.GetString(control.Name);
                if (!string.IsNullOrEmpty(value))
                {
                    control.Text = value;
                }

                // 递归子控件
                if (control.HasChildren)
                    ApplyLanguage(control.Controls);
            }
        }

        public static void SetCulture(string cultureCode)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(cultureCode);
        }
    }

}
