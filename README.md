#本文档只适用于Demo1(V2.0版本)#

首先，感谢大家能试玩这款小游戏。


接下来，让我们开始你的旅程。



###一.进入游戏###

**1.1启动**


前往https://toysworld.lanzous.com/in17alfbgtc 下载Demo1E1包。
体验更好的头像前往https://toysworld.lanzous.com/iJZVWlfsipc 下载Demo1E2包。

打开程序包，有一个exe文件，打开运行即可。

程序可能会依赖.Net Framework框架，根据弹出来的向导安装即可。

**注意:绝对不能把exe拿出来运行！**



**1.2进入主界面**


打开程序时，会弹出`获得进入资格`窗口。

每赢电脑一次，可以获得一点`能力值`，每输给电脑一次会减少一点`能力值`，凑齐3点`能力值`后，启动按钮亮起，点击即可进入主程序。



###二.当前规则说明###

**2.1 攻击**


攻击和实体游戏基本一致，但是电脑玩家阵亡后继续战斗，但是攻击变为0。

角色系统将在3.0大版本(预计在春节后)推出，希望大家能继续支持。

当前Demo的攻击力始终为1，攻击递增功能也将在3.0大版本更新后退出。


**2.2 血量**


当前Demo中，我们通过将字段赋值的方法将血量始终限定为5。同2.1节一样，血量递增功能将在3.0推出。


**2.3 失败**


当任意玩家的血量小于等于0时，判定为失败。

电脑玩家失败后继续参加战斗，但没有任何攻击力。我们直接将其`count`字段赋值为0。

玩家失败后，结束所有线程，程序结束。想要再次游玩，需重新获得进入资格(与电脑战斗获得`能力值`)。

在3.0版本中，我们会对这一块内容进行优化，失败后继续游戏 而电脑玩家能力值提升。


**2.4 拓展包**

支持游戏头像自定义。

源文件在`\accets\`文件夹下，可以自行替换。

###三.其它###

**3.1 源码**


源码全部开源


**3.2 法律效益 **


严厉打击未经许可的转载与倒卖，一旦发现，严肃处理。


**3.3 专属授权版 **


如果您拿到了授权版，可以在允许的范围内发放给他人。


**如果您是普通玩家，那么文档到这里就结束了，感谢您的信任与支持。**





###四.开发者文档###

**4.1 权利 **


你必须在拿到我们的许可后才可以进行开发与改装。否则追究法律责任。


**4.2 开发基本信息**


本程序全部使用C#进行开发，C#窗体程序依赖于.Net Framework框架。开发时，只需打开根目录下的sln文件，即可顺利进行开发。


**4.3 各类的用途**
类名| 用途|备注
Form1.cs|获得资格窗口|成功后加载game.cs
game.cs|主游戏窗口|所有功能的调用
switch.cs|核心算法(旧)|已经废弃
core.cs|核心算法(新)|整个写反了😂解析时只能反着调用
blood.cs|血量控制|已废弃(原因是跨类传参时传不上)

**********
##春节要来了，预祝大家阖家欢乐，身体健康，万事如意！##

