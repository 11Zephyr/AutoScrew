using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoScrewSys.Base
{
    public enum LogType
    {
        Run,
        Fault,
        Error
    }
    public static class LogHelper
    {
        private static RichTextBox _logBox;
        private static Color _fontColor = Color.White;
        private static readonly object _lock = new object();

        public static void InitializeLogBox(RichTextBox logBox, Color fontColor)
        {
            _logBox = logBox;
            _fontColor = fontColor;
            _logBox.WordWrap = true;//超出文本框长度自动换行
        }

        public static void WriteLog(string message, LogType type)
        {
            string logTime = DateTime.Now.ToString("HH:mm:ss");
            string logLine = "[" + logTime + "] " + message + Environment.NewLine;

            string folderName = "RunLog";
            if (type == LogType.Fault)
                folderName = "FaultLog";
            else if (type == LogType.Error)
                folderName = "ErrorLog";

            string dirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log", folderName);
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }

            string logFile = Path.Combine(dirPath, DateTime.Now.ToString("yyyyMMdd") + ".txt");

            lock (_lock)
            {
                File.AppendAllText(logFile, logLine);
            }

            if (_logBox != null && !_logBox.IsDisposed)
            {
                _logBox.Invoke((MethodInvoker)delegate
                {
                    int start = _logBox.TextLength;
                    _logBox.AppendText(logLine);
                    _logBox.Select(start, logLine.Length);
                    _logBox.SelectionColor = _fontColor;
                    _logBox.SelectionLength = 0;
                    _logBox.ScrollToCaret();
                });
            }
        }
    }
}
