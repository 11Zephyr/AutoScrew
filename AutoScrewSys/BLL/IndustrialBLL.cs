using AutoScrewSys.Modbus;
using AutoScrewSys.Model;
using AutoScrewSys.Properties;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoScrewSys.BLL
{
    public class IndustrialBLL
    {
        /// <summary>
        /// 初始化串口信息
        /// </summary>
        /// <returns></returns>
        public DataResult<ModbusSerialInfo> InitSerialInfo()
        {
            DataResult<ModbusSerialInfo> result = new DataResult<ModbusSerialInfo>();
            result.State = false;

            try
            {
                ModbusSerialInfo SerialInfo = new ModbusSerialInfo();
                SerialInfo.PortName = Settings.Default.cbxPort;
                SerialInfo.BaudRate = int.Parse(Settings.Default.cbxBaudRate);
                SerialInfo.DataBit = int.Parse(Settings.Default.cbxDataBits);
                SerialInfo.Parity = (System.IO.Ports.Parity)Enum.Parse(typeof(System.IO.Ports.Parity), Settings.Default.cbxParity, true);
                SerialInfo.StopBits = (System.IO.Ports.StopBits)Enum.Parse(typeof(System.IO.Ports.StopBits), Settings.Default.cbxStopBits, true);

                result.State = true;
                result.Data = SerialInfo;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }

            return result;
        }
        /// <summary>
        /// 存储到数据库使用该方式
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public DataResult<List<StorageModel>> InitStorageArea(string filePath)
        {
            DataResult<List<StorageModel>> result = new DataResult<List<StorageModel>>();
            List<StorageModel> storageModels = new List<StorageModel>();
            result.State = false;

            try
            {
                if (!File.Exists(filePath)) return result;

                using (var workbook = new XLWorkbook(filePath))
                {
                    var worksheet = workbook.Worksheet(1);
                    var rows = worksheet.RangeUsed().RowsUsed().Skip(1);

                    foreach (var row in rows)
                    {
                        if (row.Cell(1).IsEmpty() || row.Cell(2).IsEmpty())
                            continue; // 跳过必填列为空的行

                        var model = new StorageModel
                        {
                            StorageID = row.Cell(1).GetString().Trim(),
                            StorageName = row.Cell(2).GetString().Trim(),
                            TaskNumber = int.TryParse(row.Cell(3).GetString().Trim(), out var taskNum) ? taskNum : 0,
                            Steps = row.Cell(4).GetString().Trim(),
                            SlaveAddress = int.TryParse(row.Cell(5).GetString().Trim(), out var slave) ? slave : 0,
                            StartAddress = int.TryParse(row.Cell(6).GetString().Trim(), out var startAddr) ? startAddr : 0,
                            Length = int.TryParse(row.Cell(7).GetString().Trim(), out var len) ? len : 0
                        };

                        storageModels.Add(model);
                    }
                }

                result.Data = storageModels;
                result.State = true;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
