using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoScrewSys.Base
{
    public class SerialPortTaskQueue
    {
        private readonly SemaphoreSlim _lock = new SemaphoreSlim(1, 1);

        public async Task<T> EnqueueAsync<T>(Func<Task<T>> func)
        {
            await _lock.WaitAsync();
            try
            {
                return await func();
            }
            finally
            {
                _lock.Release();
            }
        }

        public async Task EnqueueAsync(Func<Task> func)
        {
            await _lock.WaitAsync();
            try
            {
                await func();
            }
            finally
            {
                _lock.Release();
            }
        }
    }

}
