using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caiquan
{
    class RanName
    {
        //public string Iget()
        //{
        //    //这个函数用于获取一个随机图片路径
        //    string Iget;
        //    Random ran = new Random();
        //    int will = ran.Next(1, 11);
        //    string lj = "accets\\";
        //    Iget = lj + will.ToString();
        //    return Iget;
        //    will = ran.Next(1, 11);
        //}

        public string gets(string path,int ran)
        {
            RanName rn = new RanName();
            //完整路径
            string okay = path + "\\" + "accets\\" + ran.ToString() +  ".JPG";
            //返回绝对路径
            return okay;

        }


    }
}