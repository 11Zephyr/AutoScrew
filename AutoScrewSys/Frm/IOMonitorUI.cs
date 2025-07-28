using AutoScrewSys.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoScrewSys.Frm
{
    public partial class IOMonitorUI : UserControl, IRefreshable
    {
        private Thread _refreshThread;
        private bool _isRunning;
        public IOMonitorUI()
        {
            InitializeComponent();
        }

        public void StartRefreshing()
        {
            if (_refreshThread != null && _refreshThread.IsAlive)
                return;

            _isRunning = true;
            _refreshThread = new Thread(() =>
            {
                while (_isRunning)
                {
                    Thread.Sleep(5);
                    Invoke(new Action(() =>
                    {
                      
                    }));
                }
            });
            _refreshThread.IsBackground = true;
            _refreshThread.Start();
        }

        public void StopRefreshing()
        {
            _isRunning = false;
            if (_refreshThread != null && _refreshThread.IsAlive)
            {
                _refreshThread.Join(200); // 可选：等待线程结束
            }
            _refreshThread = null;
        }
    }
}
