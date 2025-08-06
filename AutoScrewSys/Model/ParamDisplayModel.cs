using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoScrewSys.Model
{
    public class ParamDisplayModel
    {
       
        public string ParamName { get; set; }      // 第 0 列
        public int Value { get; set; }     // 第 1 列：从 Modbus 读取的值
        public string Range { get; set; }     // 第 2 列
        public string Unit { get; set; }      // 第 3 列
        public string Remark { get; set; }    // 第 4 列
    }
    public class ParamInfo
    {
        public string Name { get; set; }
        public string Range { get; set; }
        public string Unit { get; set; }
        public string Remark { get; set; }

       // public string IsProportion { get; set; }
    }

}
