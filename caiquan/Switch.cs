using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using caiquan;

namespace caiquan
{
    class Switch
    {

        public int getwin(int user,int computer1,int computer2)
        //传入值1代表剪刀，2代表石头，3代表布
        //返回值规范:0->平局 1->Victor单独胜利 2->Utanus单独胜利 3->Victor与user同时胜利 4->Utanus与user同时胜利 5->Victor与Utanus同时胜利 6->user单独胜利

        {

            if (user == computer1) {
                //用户与Utanus平局
                if (computer1 == computer2)
                {
                    //全部平局
                    return 0; //0代表平局
                }
                if (computer1 == 3 && computer2 == 1)
                {
                    return 3; //3代表Victor与user同时胜利
                }
                if (computer1 == 1 && computer2 == 3)
                {
                    return 2; //2代表Utanus单独胜利
                }
                else
                {
                    if (computer1 > computer2)
                    {
                        return 1; //1代表Victor单独胜利
                    }

                    if (computer1 < computer2)
                    {
                        return 2;//2代表Utanus单独胜利
                    }
                    
                }
            }

            if (user == computer2)
            {
                //用户与Victor平局
                if (computer1 == computer2)
                {
                    //全部平局
                    return 0; //0代表平局
                }
                if (computer1 == 3 && computer2 == 1)
                {
                    //Victor单独胜利
                    return 1; //1代表Victor单独胜利
                }
                if (computer1 == 1 && computer2 == 3)
                {
                    return 2; //2代表Utanus单独胜利
                }
                else
                {
                    if (computer1 > computer2)
                    {
                        return 1; //1代表Victor单独胜利
                    }

                    if (computer1 < computer2)
                    {
                        return 2;//2代表Utanus单独胜利
                    }

                }
            }

            return 1199; //暂无法判断

        }
    }
}
