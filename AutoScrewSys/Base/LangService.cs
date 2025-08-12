using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoScrewSys.Base
{

    public sealed class LangService
    {
        private static readonly Lazy<LangService> _instance =
            new Lazy<LangService>(() => new LangService());

        public static LangService Instance => _instance.Value;

        private Dictionary<string, string> _dict = new Dictionary<string, string>();
        private int _languageIndex = 0; // 默认中文模式

        private LangService() { }

        /// <summary>
        /// 从程序运行根目录加载 lang.txt
        /// </summary>
        public void Load()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "lang.txt");

            if (!File.Exists(filePath))
                throw new FileNotFoundException("语言文件未找到: " + filePath);

            _dict.Clear();
            foreach (var line in File.ReadAllLines(filePath))
            {
                var trimmed = line.Trim();
                if (string.IsNullOrEmpty(trimmed) || trimmed.StartsWith("#")) continue;

                var parts = trimmed.Split(new[] { '=' }, 2);
                if (parts.Length == 2)
                {
                    _dict[parts[0].Trim()] = parts[1].Trim();
                }
            }
        }

        /// <summary>
        /// 设置语言模式
        /// </summary>
        public void SetEnglishMode(int languageIndex)
        {
            _languageIndex = languageIndex;
        }

        /// <summary>
        /// 获取翻译
        /// </summary>
        public string T(string text)
        {
            if (_languageIndex == 0)
                return text; // 中文模式直接返回原文

            return _dict.ContainsKey(text) ? _dict[text] : text;
        }
    }
}
