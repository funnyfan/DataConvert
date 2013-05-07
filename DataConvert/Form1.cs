using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;//注意加载

namespace DataConvert
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btn_save_Click(object sender, EventArgs e)
        {
            string path = txb_path.Text.Trim().ToString();//读取路径
            string[] tempString=ConvertData.readData(path);
            string[] Result = new string[50000000];
            byte[] temp;
            int count = 0;
            //判断tempString的每个的长度，如果小于72则不参与运算
            for (int i = 0; i < tempString.Count(); i++)
            {

                if (tempString[i].Length == 133)
                {
                    temp = ConvertData.strToHex(tempString[i]);
                    for (int j = 0; j < 44; j = j + 4)
                    {
                        Result[count ] += BitConverter.ToSingle(temp, j).ToString("f4") + " ";//每个数据以空格相间
                    }
                    //Result[count] += "\n";//加换行符
                   count++;
                }
            }
            
            //将数据保存
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "文本文件(*.txt)|*.txt";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sf.FileName, true);
                //写入内容
                for (int i=0;i<count;i++)
                {
                    sw.WriteLine(Result[i]);
                }
                sw.Close();
            }
            MessageBox.Show("数据保存成功");
            
        }

        //选择文件打开
        private void btn_open_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Txt document(*.txt)|*.txt|All FileStream(*.*)|*.*";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string dataPathName = ofd.FileName;
                txb_path.Text = dataPathName;
            }
            else
                MessageBox.Show("无法打开");
        }
    }
}
