using AutoScrewSys.VariableName;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoScrewSys.Base
{
    public static class SettingsUpdater
    {
        public static void Set(string key, object value)
        {
            if (UIThread.Context == null)
                throw new InvalidOperationException("UIThread.Context 尚未初始化");

            UIThread.Context.Post(_ =>
            {
                var settings = AddrName.Default;
                if (settings.Properties[key] != null)
                {
                    settings[key] = Convert.ChangeType(value, settings.Properties[key].PropertyType);
                }
            }, null);
        }
    }
    public static class UIThread
    {
        public static SynchronizationContext Context;
    }

}
