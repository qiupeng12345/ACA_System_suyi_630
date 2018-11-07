using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACA_BreakCommunication;
using System.Threading;

namespace ACA_Common.Class
{
    /// <summary>
    /// 全局变量类
    /// </summary>
   public  static class Global  //定义全局变量
    {
        //需要对属性设置一下
        public static KVDH1 kv = new KVDH1() //plc地址设置也写死了，只能通过源码改动，有点傻逼
        {
            PLC = DATABUILDERAXLibLB.DBPlcId.DBPLC_DKV7K,
            Peer="192.168.250.60:8500"  //plc地址
        };
        public static ProofTest proof = new ProofTest();  //校对测试工作类
        public static InstantaneousTest intest = new InstantaneousTest();//瞬时测试工作类
        public static WholeTest wh1 = new WholeTest(); //整机测试工作类1
        public static WholeTest wh2 = new WholeTest(); //整机测试工作类2
        public static WholeTest wh3 = new WholeTest(); //整机测试工作类3
        
        public  static bool workState = false; //工作状态标志位
        /// <summary>
        /// 校对测试参数
        /// </summary>
        public static int delayTime;//校对延时时间
        public static int baudRate;//通信波特率
        public const int currentMax = 300;  //电流输出最大值
        public const int voltageMax = 295;//电压输出最大值
        public const int residualCurrentMax = 10000;//剩余电流输出最大值
        public static int proofJudge=0;   //校对人工判断（0为尚未判断，1为合格，2为不合格）
        public static int erroCount = 3; //错误计数
        public static int currentProofNum; //电流校对档位
        public static int voltageProofNum; //电压校对档位
        public static int residualCurrentProofNum; //剩余电流校对档位
        public static int presetCurrentValue1; //电流校对预设电流1
        public static int presetCurrentValue2;
        public static int presetCurrentValue3;
        public static int presetCurrentValue4;
        public static int presetCurrentValue5;
        public static int presetVoltageValue1; //电压校对预设电流1
        public static int presetVoltageValue2;
        public static int presetVoltageValue3;
        public static int presetVoltageValue4;
        public static int presetVoltageValue5;
        public static int closeSwitchVoltage;
        public static int presetResidualCurrentValue1;//剩余电流预设电流1
        public static int presetResidualCurrentValue2;
        public static int presetResidualCurrentValue3;
        public static int presetResidualCurrentValue4;
        public static int presetResidualCurrentValue5;
        public static int proofCurrentErrorRange; //电流校对误差范围
        public static int checkCurrentErrorRange; //电流检测误差范围
        public static int proofVoltageErrorRange;//电压校对误差范围
        public static int checkVoltageErrorRange;//电压校对误差范围
        public static int proofResidualCurrentErrorRange;//剩余电流校对误差范围
        public static int checkResidualCurrentErrorRange;//剩余电流校对误差范围
        public static int currentCheck;  //电流校验设定输出值
        public static int voltageCheck; //电压校验设定输出值
        public static int residualCurrentCheck;//剩余电流检验设定输出值
        public static int currentZero; //电流校对零位值
        public static int residualCurrentZero; //剩余电流校对零位值
        public static int currentProofNum_model1; //电流校对档位
        public static int voltageProofNum_model1; //电压校对档位
        public static int residualCurrentProofNum_model1; //剩余电流校对档位
        public static int presetCurrentValue1_model1; //电流校对预设电流1
        public static int presetCurrentValue2_model1;
        public static int presetCurrentValue3_model1;
        public static int presetCurrentValue4_model1;
        public static int presetCurrentValue5_model1;
        public static int presetVoltageValue1_model1; //电压校对预设电流1
        public static int presetVoltageValue2_model1;
        public static int presetVoltageValue3_model1;
        public static int presetVoltageValue4_model1;
        public static int presetVoltageValue5_model1;
        public static int presetResidualCurrentValue1_model1;//剩余电流预设电流1
        public static int presetResidualCurrentValue2_model1;
        public static int presetResidualCurrentValue3_model1;
        public static int presetResidualCurrentValue4_model1;
        public static int presetResidualCurrentValue5_model1;
        public static int proofCurrentErrorRange_model1; //电流校对误差范围
        public static int checkCurrentErrorRange_model1; //电流检测误差范围
        public static int proofVoltageErrorRange_model1;//电压校对误差范围
        public static int checkVoltageErrorRange_model1;//电压校对误差范围
        public static int proofResidualCurrentErrorRange_model1;//剩余电流校对误差范围
        public static int checkResidualCurrentErrorRange_model1;//剩余电流校对误差范围
        public static int currentCheck_model1;  //电流校验设定输出值
        public static int voltageCheck_model1; //电压校验设定输出值
        public static int residualCurrentCheck_model1;//剩余电流检验设定输出值
        public static int currentZero_model1; //电流校对零位值
        public static int residualCurrentZero_model1; //剩余电流校对零位值
        public static int currentProofNum_model2; //电流校对档位
        public static int voltageProofNum_model2; //电压校对档位
        public static int residualCurrentProofNum_model2; //剩余电流校对档位
        public static int presetCurrentValue1_model2; //电流校对预设电流1
        public static int presetCurrentValue2_model2;
        public static int presetCurrentValue3_model2;
        public static int presetCurrentValue4_model2;
        public static int presetCurrentValue5_model2;
        public static int presetVoltageValue1_model2; //电压校对预设电流1
        public static int presetVoltageValue2_model2;
        public static int presetVoltageValue3_model2;
        public static int presetVoltageValue4_model2;
        public static int presetVoltageValue5_model2;
        public static int presetResidualCurrentValue1_model2;//剩余电流预设电流1
        public static int presetResidualCurrentValue2_model2;
        public static int presetResidualCurrentValue3_model2;
        public static int presetResidualCurrentValue4_model2;
        public static int presetResidualCurrentValue5_model2;
        public static int proofCurrentErrorRange_model2; //电流校对误差范围
        public static int checkCurrentErrorRange_model2; //电流检测误差范围
        public static int proofVoltageErrorRange_model2;//电压校对误差范围
        public static int checkVoltageErrorRange_model2;//电压校对误差范围
        public static int proofResidualCurrentErrorRange_model2;//剩余电流校对误差范围
        public static int checkResidualCurrentErrorRange_model2;//剩余电流校对误差范围
        public static int currentCheck_model2;  //电流校验设定输出值
        public static int voltageCheck_model2; //电压校验设定输出值
        public static int residualCurrentCheck_model2;//剩余电流检验设定输出值
        public static int currentZero_model2; //电流校对零位值
        public static int residualCurrentZero_model2; //剩余电流校对零位值
        public static int meachineTestNum;//机械磨合次数
        public static int residualTime;
        /// <summary>
        /// //用户功能选择
        /// </summary>
        public static bool model1Select;  //型号1
        public static bool model2Select;  //型号2
        public static bool scan;  //扫码功能
        public static bool autoCommunication; //自动通信
        public static bool manualCommunication; //手动通信
        public static bool meachineAge; //机械寿命
        public static bool manualJudge; //人工判断
        public static bool closeDoor; //门禁
        public static bool autoLine;  //自动上料
        public static bool manualLine; //手动上料
        public static bool defence;  //挡停下降
        public static bool openLine; //分闸进线
        public static bool closeLine;//合闸进线
        //****************功能选择***********************//
        public static bool doCurrent1;  //电流校对1执行
        public static bool doCurrent2;
        public static bool doCurrent3;
        public static bool doCurrent4;
        public static bool doCurrent5;
        public static bool doVoltage1; //电压校对1执行
        public static bool doVoltage2;
        public static bool doVoltage3;
        public static bool doVoltage4;
        public static bool doVoltage5;
        public static bool doResidualCurrent1; //剩余电流校对1执行
        public static bool doResidualCurrent2;
        public static bool doResidualCurrent3;
        public static bool doResidualCurrent4;
        public static bool doResidualCurrent5;



        //***************************************************************//
        ///////瞬时电流测试参数//////////////
        public const int instaniousMax=9000;//瞬时输出最大值
        public static int insJudge = 0; //瞬时校对判断
        public static int lowTimesCurrent;  //低倍输出电流值
        public static int lowTimesTime;    //低倍输出时间
        public static int highTimesCurrent; //高倍输出电流值
        public static int highTimesTime; //高倍输出时间
        public static int outPutCurrent; //瞬时校对输出电流值（10倍）
        public static int outPutTime; //瞬时校对输出时间
        public static int errorRange; //校对误差范围
        public static int lowTimesCurrent_model1;  //低倍输出电流值型号1参数
        public static int lowTimesTime_model1;    //低倍输出时间型号1参数
        public static int highTimesCurrent_model1; //高倍输出电流值型号1参数
        public static int highTimesTime_model1; //高倍输出时间型号1参数
        public static int outPutCurrent_model1; //瞬时校对输出电流值（10倍）型号1参数
        public static int outPutTime_model1; //瞬时校对输出时间型号1参数
        public static int errorRange_model1; //校对误差范围型号1参数
        public static int lowTimesCurrent_model2;  //低倍输出电流值型号2参数
        public static int lowTimesTime_model2;    //低倍输出时间型号2参数
        public static int highTimesCurrent_model2; //高倍输出电流值型号2参数
        public static int highTimesTime_model2; //高倍输出时间型号2参数
        public static int outPutCurrent_model2; //瞬时校对输出电流值（20倍）型号2参数
        public static int outPutTime_model2; //瞬时校对输出时间型号2参数
        public static int errorRange_model2; //校对误差范围型号2参数
        //**************功能选择************///
        public static bool doOutPut1;  //做第一个相位瞬时校对
        public static bool doOutPut2;
        public static bool doOutPut3;
        public static bool doLow;
        public static bool doHigh;
        //////整机测试/////////
        public static int overVoltageMax = 295;
        public static int wholeJudge=0;//整机测试判断
        public static int actionTest1Current;  //测试1电流值
        public static int actionTest1Time;  //测试1时间
        public static int actionTest2StartCurrent; //测试2起始电流
        public static int actionTest2Time;  //测试2输出时间
        public static int actionTest2EndCurrent;//测试2终止电流
        public static int actionTest3Current;
        public static int actionTest3Time;
        public static int overVoltageValue; //过压电压值
        public static int overVoltageTime; //过压时间
        public static int underVoltageValue; //欠压电压值
        public static int underVoltageTime; //欠压时间
        public static int lowVoltageValue; //低压电压值
        public static int closeSwitchTimeUp;
        public static int VoltageErroRange;
        public static int actionTest1Current_model1;  //测试1电流值
        public static int actionTest1Time_model1;  //测试1时间
        public static int actionTest2StartCurrent_model1; //测试2起始电流
        public static int actionTest2Time_model1;  //测试2输出时间
        public static int actionTest2EndCurrent_model1;//测试2终止电流
        public static int actionTest3Current_model1;
        public static int actionTest3Time_model1;
        public static int overVoltageValue_model1; //过压电压值
        public static int overVoltageTime_model1; //过压时间
        public static int underVoltageValue_model1; //欠压电压值
        public static int underVoltageTime_model1; //欠压时间
        public static int lowVoltageValue_model1; //低压电压值
        public static int closeSwitchTimeUp_model1;
        public static int VoltageErroRange_model1;
        public static int actionTest1Current_model2;  //测试1电流值
        public static int actionTest1Time_model2;  //测试1时间
        public static int actionTest2StartCurrent_model2; //测试2起始电流
        public static int actionTest2Time_model2;  //测试2输出时间
        public static int actionTest2EndCurrent_model2;//测试2终止电流
        public static int actionTest3Current_model2;
        public static int actionTest3Time_model2;
        public static int overVoltageValue_model2; //过压电压值
        public static int overVoltageTime_model2; //过压时间
        public static int underVoltageValue_model2; //欠压电压值
        public static int underVoltageTime_model2; //欠压时间
        public static int lowVoltageValue_model2; //低压电压值
        public static int closeSwitchTimeUp_model2;
        public static int VoltageErroRange_model2;

        //*********功能选择******************/////
        public static bool doActionTest1;  //测试功能选择
        public static bool doActionTest2;
        public static bool doActionTest3;
        public static bool doOverVoltage;
        public static bool dounderVoltage;
        public static bool doLowVoltage;
        public static bool doZeroPhase;
        public static bool doLosePhase;
        public static bool useStation1; //工位是否使用标志位
        public static bool useStation2;
        public static bool useStation3;
        public static bool useStation4;
        public static bool useStation5;
        public static bool useStation6;
        public static int stationJudge1=0;  //整机测试人工判断
        public static int stationJudge2=0;
        public static int stationJudge3=0;
        public static bool finallyJudge = false;
    }
}
