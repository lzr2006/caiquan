using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caiquan
{
    class Core
    {
        #region 核心算法
        public int winner(int computer1, int computer2, int user)

        #region 全是bug没救了，只能叠bug负负得正
        {
            //传入值1代表剪刀，2代表石头，3代表布
            //返回值规范:0->平局 1->Victor单独胜利 2->Utanus单独胜利 3->Victor与user同时胜利 4->Utanus与user同时胜利 5->Victor与Utanus同时胜利 6->user单独胜利

            #endregion

            if (computer1 == computer2)
            {
                if (computer1 == 1 && user == 3)
                {
                    //computer1,computer2
                    return 5;
                }
                if (computer1 == 3 && user == 1)
                {
                    //user
                    return 6;
                }
                if (computer1 > user)
                {
                    //computer1,computer2
                    return 5;
                }
                if (computer1 < user)
                {
                    //user
                    return 6;
                }
                else
                {
                    //none
                    return 0;
                }
            }

            if (computer1 == 1 && computer2 == 3)
            {
                if (user == computer1)
                {
                    //computer1,user
                    return 4;
                }
                if (user == computer2)
                {
                    //computer1
                    return 1;
                }
                else
                {
                    return 0;
                    //none
                }
            }

            if (computer1 == 3 && computer2 == 1)
            {
                if (user == computer2)
                {
                    //computer2,user
                    return 4;
                }
                if (user == computer1)
                {
                    //computer2
                    return 2;
                }
                else
                {
                    //none
                    return 0;
                }
            }

            if (computer1 > computer2)
            {
                //Victor不失败
                if (user == computer1)
                {
                    //computer1,user
                    return 3;
                }
                if (user == computer2)
                {
                    //computer1
                    return 1;
                }
                else
                {
                    //none
                    return 0;
                }
            }

            if (computer1 < computer2)
            {
                if (user == computer2)
                {
                    //computer2,user
                    return 4;
                }
                if (user == computer1)
                {
                    //computer2
                    return 2;
                }
                else
                {
                    //none
                    return 0;
                }
            }


            else
            {
                //none
                return 0;
            }



        }

        #endregion
    }

}
