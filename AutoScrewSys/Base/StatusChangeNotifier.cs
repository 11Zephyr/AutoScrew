using AutoScrewSys.VariableName;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoScrewSys.Base
{
    public static class StatusChangeNotifier
    {
        // 保存上一次的状态
        private static int lastStateBits = -1;
        private static int lastTighten = -1;
        private static int lastLoosen = -1;
        private static int torqueMode = -1;
        private static int lastFree = -1;
        private static bool isFirst = true;

        /// <summary>
        /// 仅当状态发生变化时触发事件
        /// </summary>
        public static void CheckAndNotifyStatusChange(Action<int, int, int, int, int> statusChangedCallback)
        {
            int stateBits = AddrName.Default.StateBits;
            int tighten = AddrName.Default.TightenAction;
            int loosen = AddrName.Default.LoosenAction;
            int free = AddrName.Default.FreeAction;
            int _torqueMode = AddrName.Default.TorqueMode;

            if (isFirst || stateBits != lastStateBits || tighten != lastTighten || loosen != lastLoosen || free != lastFree ||_torqueMode != torqueMode)
            {
                statusChangedCallback?.Invoke(stateBits, tighten, loosen, free, _torqueMode);

                lastStateBits = stateBits;
                lastTighten = tighten;
                lastLoosen = loosen;
                torqueMode = _torqueMode;
                lastFree = free;
                isFirst = false;
            }
        }
    }

}
