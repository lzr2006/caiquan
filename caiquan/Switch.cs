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

        #region 核心算法-->已经废弃 

        //本类已废弃

        public int getwin(int user,int computer1,int computer2)
        //传入值1代表剪刀，2代表石头，3代表布
        //返回值规范:0->平局 1->Victor单独胜利 2->Utanus单独胜利 3->Victor与user同时胜利 4->Utanus与user同时胜利 5->Victor与Utanus同时胜利 6->user单独胜利

        {

            if (user == computer1) {
                //用户与Victor平局
                if (computer1 == computer2)
                {
                    //全部平局
                    return 0; //0代表平局
                }
                if (computer1 == 3 && computer2 == 1)
                {
                    return 2; 
                }
                if (computer1 == 1 && computer2 == 3)
                {
                    return 3; 
                }
                if (user == 1 && computer2 == 3) {
                    return 3;
                }
                if (user == 3 && computer1 == 1) {
                    return 2;
                }
                if (computer2 > user) {
                    return 3;
                }
                if (user < computer1) {
                    return 2;
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
                //用户与Utanus平局
                if (computer1 == computer2)
                {
                    //全部平局
                    return 0; //0代表平局
                }
                if (computer1 == 3 && computer2 == 1)
                {
                    //Utanus与user同时胜利
                    return 1;
                }
                if (computer1 == 1 && computer2 == 3)
                {
                    return 4;
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

            if (computer1 == 1 && computer2 == 3) {
                //必定有Victor不失败
                if (user == 1) {
                    return 3;
                }
                if (user == 2)
                {
                    return 0;
                }
                if (user == 3) {
                    return 1;
                }
            }

            if (computer1 == 3 && computer2 == 1) {
                //必定有Utanus不失败

                if (user == 1) {
                    return 4;
                }
                if (user == 2)
                {
                    return 0;
                }
                if (user == 3)
                {
                    return 2;
                }

            }

            if (computer1 > computer2) 
            {
                //必定有Victor不失败
                if (user == 1)
                {
                    return 3;
                }
                if (user == 2)
                {
                    return 0;
                }
                if (user == 3)
                {
                    return 1;
                }
           }

            if (computer1 < computer2) 
            {
                //必定有Utanus不失败

                if (user == 1)
                {
                    return 4;
                }
                if (user == 2)
                {
                    return 0;
                }
                if (user == 3)
                {
                    return 2;
                }

            }

            if (computer1 == computer2)
            {
                if (user == 1 && computer1 == 3) {
                    return 6;
                }
                if (user == 3 && computer1 == 1)
                {
                    return 5;
                }
                if (user > computer1) {
                    return 6;
                }
                if (user > computer1) {
                    return 5;
                }
            }


            return 0; //暂无法判断

        }

        #endregion
    }
}
