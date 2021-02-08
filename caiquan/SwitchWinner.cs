using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace caiquan
{
    class SwitchWinner
    {
        bool isfinish;
        public List<int> getwin(int whoboss, int[] islife)
        {
            //返回胜利者
            //1->user 2->Victor 3->Utanus 404->无
            List<int> win = new List<int>();
            if (islife.Length == 1)
            {
                //只有一个人存活->没有任何问题
                if (islife[0] == whoboss)
                {
                    //地主单独胜利
                    win.Clear();
                    win.Add(whoboss);
                    return win;
                }

                else
                {
                    //不是地主单独胜利
                    //逻辑：在非地主单独胜利的单独胜利情况下，添加所有人并删除地主
                    win.Clear();
                    win.Add(1);
                    win.Add(2);
                    win.Add(3);
                    //删除地主
                    win.Remove(whoboss);
                    return win;

                }
            }

                if (islife.Length == 2)
                {
                    foreach (int item in islife)
                    {
                        if (item == whoboss)
                        {
                            win.Clear();
                            win.Add(404);
                            return win;
                            isfinish = true;
                        }
                    }

                    if (!isfinish)
                    {
                        win.Clear();
                        win.Add(1);
                        win.Add(2);
                        win.Add(3);
                        win.Remove(whoboss);
                        return win;
                    }
   
            }

            win.Clear();
            win.Add(404);
            return win;
        }           
    }
}
