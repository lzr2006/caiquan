using System;
using System.IO;
using System.Text;
using caiquan;

namespace caiqian
{
    class Save
    {

        public void saved(int user_blood,int computer1_blood,int computer2_blood,int user_money,int computer1_money,int computer2_money,int user_count,int computer1_count,int computer2_count,string local)
        {

            char[] bt = { Convert.ToChar(user_blood), Convert.ToChar(computer1_blood), Convert.ToChar(computer2_blood), Convert.ToChar(computer1_money), Convert.ToChar(computer2_money), Convert.ToChar(user_count), Convert.ToChar(computer1_count), Convert.ToChar(computer2_count) };
            string[] st = { user_blood.ToString(), computer1_blood.ToString(), computer2_blood.ToString(), user_money.ToString(), computer1_money.ToString(), computer2_money.ToString(),user_count.ToString(),computer1_count.ToString(),computer2_count.ToString()};
            string path = local + "\\temp\\temp.txt";
            //FileStream fs = new FileStream(path,FileMode.Create);
            StreamWriter sw = new StreamWriter(path, false, Encoding.GetEncoding("utf-8"));
            //System.Windows.Forms.MessageBox.Show(bt[1].ToString() );
            //char[]转string
            //for (int i = 0; i < bt.Length; i++)
            //{
            //    str += string.Format("{0}", bt[i]);
            //}
            int i = 0;
            foreach (var item in st)
            {
                sw.WriteLine(st[i]);
                i++;
            }
            
            sw.Flush();
            sw.Close();
            System.Windows.Forms.MessageBox.Show("存储开始");

            //输出路径并存储
            string path2 = "D:\\config_cq.txt";
            StreamWriter localer = new StreamWriter(path2, false, Encoding.GetEncoding("utf-8"));
            localer.Write(local);
            localer.Flush();
            localer.Close();

            //在Python中删除源文件
        }

      
    }

}