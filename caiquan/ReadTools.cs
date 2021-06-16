using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace caiquan
{
    
    class ReadTools
    {
        #region 定义字段
        List<string> temp = new List<string>();
        List<string> tools = new List<string>();
        Dictionary<string, string> back_tools = new Dictionary<string, string>();
        #endregion
        /// <summary>
        /// 自动读取道具
        /// </summary>
        /// <param name="path">道具文件路径</param>
        /// <returns>道具字典</returns>
        public Dictionary<string,string> Get_tools(string path) {

            #region 读

            StreamReader rd = new StreamReader(path);

            for (int i = 0; i < 4; i++)
            {
                temp.Add(rd.ReadLine());
            }
            rd.Close();
            foreach (var item in temp)
            {
                //分割字符串
                string[] split1 = item.Split(':');
                tools.Add(split1[1]);
            }
            #endregion

            #region 添加到返回字典
            back_tools.Add("Name", tools[0]);
            back_tools.Add("Accets", tools[1]);
            back_tools.Add("Says",tools[2]);
            back_tools.Add("Effects",tools[3]);
            #endregion
            return back_tools;
        }

    }
}
