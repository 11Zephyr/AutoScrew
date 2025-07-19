using AutoScrewSys.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoScrewSys.Base
{
    public class ModbusAddressConfig
    {
        private static readonly Lazy<ModbusAddressConfig> _instance = new Lazy<ModbusAddressConfig>(() => new ModbusAddressConfig());
        public static ModbusAddressConfig Instance => _instance.Value;

        private JObject _config;

        private ModbusAddressConfig()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ModbusAddr.txt");
            if (!File.Exists(path))
                throw new FileNotFoundException("配置文件未找到: " + path);

            var json = File.ReadAllText(path);
            _config = JObject.Parse(json);
        }

        public ModbusCfgModel GetAddressItem(string category)
        {
            var token = _config[category];
            if (token == null)
                return null;

            return token.ToObject<ModbusCfgModel>();
        }

        public ModbusCfgModel GetAddressItem(string category, string task)
        {
            var token = _config[category]?[task];
            if (token == null)
                return null;

            return token.ToObject<ModbusCfgModel>();
        }
    }

}
