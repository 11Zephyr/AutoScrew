using AutoScrewSys.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoScrewSys.Base
{
    public class AutoLogoutManager
    {
        private Timer _timer;
        public AutoLogoutManager()
        {
            _timer = new Timer();
            _timer.Tick += Timer_Tick;
        }

        /// <summary>
        /// 读取 Settings.Default.LoggedOutTime，根据值启动或停止计时器
        /// </summary>
        public void ApplySettings()
        {
            string timeSetting = Settings.Default.LoggedOutTime;
            TimeSpan? interval = ParseTimeSetting(timeSetting);

            if (interval == null)
            {
                // 设为永久，停止计时器，权限持续有效
                _timer.Stop();
                LogHelper.WriteLog("权限设为永久，停止计时器", LogType.Run);
            }
            else
            {
                _timer.Interval = (int)interval.Value.TotalMilliseconds;
                _timer.Stop();
                _timer.Start();
                LogHelper.WriteLog($"权限计时器重启，周期：{timeSetting}", LogType.Run);
            }
        }

        /// <summary>
        /// 手动停止计时器
        /// </summary>
        public void Stop()
        {
            _timer.Stop();
            LogHelper.WriteLog("权限计时器停止", LogType.Run);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Settings.Default.Login = 0;
            Settings.Default.UserLevel = "未登录";
            LogHelper.WriteLog("权限自动注销", LogType.Run);
        }

        private TimeSpan? ParseTimeSetting(string timeSetting)
        {
            switch (timeSetting.Trim())
            {
                case "1分钟": return TimeSpan.FromMinutes(1);
                case "3分钟": return TimeSpan.FromMinutes(3);
                case "5分钟": return TimeSpan.FromMinutes(5);
                case "10分钟": return TimeSpan.FromMinutes(10);
                case "30分钟": return TimeSpan.FromMinutes(30);
                case "1小时": return TimeSpan.FromHours(1);
                case "永久": return null;
                default: return null;
            }
        }
    }

}
