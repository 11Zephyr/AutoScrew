using AutoScrewSys.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                LogHelper.WriteLog(LangService.Instance.T("权限设为永久，停止计时器"), LogType.Run);
            }
            else
            {
                _timer.Interval = (int)interval.Value.TotalMilliseconds;
                _timer.Stop();
                _timer.Start();
                LogHelper.WriteLog($"{LangService.Instance.T("权限计时器重启，周期")}:{timeSetting}", LogType.Run);
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
            Settings.Default.UserLevel = LangService.Instance.T("未登录");
            LogHelper.WriteLog(LangService.Instance.T("权限自动注销"), LogType.Run);
        }

        private TimeSpan? ParseTimeSetting(string timeSetting)
        {
            if (string.IsNullOrWhiteSpace(timeSetting))
                return null;  // 认为永久

            // 尝试用正则提取数字
            var match = Regex.Match(timeSetting, @"\d+");
            if (!match.Success)
                return null;  // 认为永久

            int number = int.Parse(match.Value);

            // 这里假设数字代表分钟，返回对应TimeSpan
            return TimeSpan.FromMinutes(number);
        }
    }

}
