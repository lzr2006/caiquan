using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace caiquan
{
    class Blood
    {
        #region 此模块已废弃
        //血量控制类
        //public bool ishaveblood = false;
        public int Computer1_blood;

        //public int Computer1_blood //Victor血量
        //{
        //    get
        //    {
        //        return computer1_blood;
        //    }

        //    set
        //    {
        //        computer1_blood = value;
        //    }

        //}
        public int Computer2_blood;

        //public int Computer2_blood //Utanus血量
        //{
        //    get
        //    {
        //        return computer2_blood;
        //    }

        //    set
        //    {
        //        computer2_blood = value;
        //    }
        //}

        public int User_blood; //玩家血量

        //public int User_blood
        //{
        //    get
        //    {
        //        return user_blood;
        //    }

        //    set
        //    {
        //        user_blood = value;
        //    }
        //}

        public void BloodReduction(int count,int userid)
        {
            //减血函数
            //count:1->user 2->Victor 3->Utanus

            if (userid == 1)
            {
                User_blood = User_blood - count;
            }
            if (userid == 2 )
            {
                Computer1_blood = Computer1_blood - count;
            }
            if (userid == 3)
            {
                Computer2_blood = Computer2_blood - count;
            }
        }

        public int getblood(int userid) //获取当前血量
        {
            //if (!ishaveblood)
            //{
            //    start();
            //}
            //start();
            if (userid == 1)
            {
                return User_blood;
            }
            if (userid == 2)
            {
                return Computer1_blood;
            }
            if (userid == 3)
            {
                return Computer2_blood;
            }
            return 0;
        }

        //public void start()
        //{
        //    User_blood = 5;
        //    Computer1_blood = 5;
        //    Computer2_blood = 5; //赋初值
        //    MessageBox.Show(User_blood.ToString());
        //}

        #endregion
    }
}
