using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace DataConvert
{
    public class ConvertData
    {
        /// <summary>
        /// 字符串转为16进制字节数组
        /// </summary>
        /// <param name="hexString">输入的字符串</param>
        /// <returns>返回字节数组</returns>
        public  static byte[] strToHex(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i=0;i<returnBytes.Length;i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }
        
        /// <summary>
        /// 读取文件,并返回字符串
        /// </summary>
        /// <param name="path">路径</param>
        public static string[]  readData(string path)
        {
           // string returnstring = "";
            string[] separator = { "AA", "55" };
            string tempString = "";

            //使用文件流读取
            FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader sr = new StreamReader(file);
            sr.BaseStream.Seek(0, SeekOrigin.Begin);//从头开始读
            //直至文件末尾
            while (!sr.EndOfStream)
            {
                tempString = sr.ReadLine().Trim();//从头读到尾
            }
            sr.Close();//关闭流
            //对tempString进行处理保存成字符串数组 每次从AA读到55
            string[] strSp = tempString.Split(separator, StringSplitOptions.RemoveEmptyEntries  );
            return strSp ;
        }

        

    }
}
