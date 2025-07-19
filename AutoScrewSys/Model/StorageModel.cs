using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoScrewSys.Model
{
    public class StorageModel
    {
        public string StorageID { get; set; }
        public string StorageName { get; set; }
        public int TaskNumber { get; set; }
        public string Steps { get; set; }
        public int SlaveAddress { get; set; }
        public int StartAddress { get; set; }
        public int Length { get; set; }
    }
}
