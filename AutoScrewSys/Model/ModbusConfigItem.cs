using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoScrewSys.Model
{
    public class ModbusCfgModel
    {
        public string Description { get; set; }
        public int SlaveAddress { get; set; }
        public int StartAddress { get; set; }
        public int Length { get; set; }
        /// <summary>
        /// 比例
        /// </summary>
        public float Proportion { get; set; } = 1f;
       
    }
}
