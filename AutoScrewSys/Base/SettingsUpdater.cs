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
        /// <summary>
        /// 强制设置属性（始终更新，无论值是否改变）
        /// </summary>
        public static void Set(SettingsBase cfg, string key, object value)
        {
            if (UIThread.Context == null)
                throw new InvalidOperationException("UIThread.Context 尚未初始化");

            UIThread.Context.Post(_ =>
            {
                if (cfg.Properties[key] != null)
                {
                    cfg[key] = Convert.ChangeType(value, cfg.Properties[key].PropertyType);
                }
            }, null);
        }

        /// <summary>
        /// 仅当值发生变化时才更新，避免不必要的 UI 刷新
        /// </summary>
        public static void SetIfChanged(SettingsBase cfg, string key, object newValue)
        {
            if (cfg.Properties[key] == null)
                return;

            var oldValue = cfg[key];

            if (!Equals(oldValue, newValue))
            {
                Set(cfg, key, newValue);
            }
        }
    }


    public static class UIThread
    {
        public static SynchronizationContext Context;
    }

}
