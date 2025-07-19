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

        //public override string ToString()
        //{
        //    return $"{Description}, Slave: {SlaveAddress}, Start: {StartAddress}, Length: {Length}";
        //}
    }
}
