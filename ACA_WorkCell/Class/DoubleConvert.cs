using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACA_Common.Class
{
    /// <summary>
    /// 浮点转换工具类
    /// </summary>
  public static class DoubleConvert
    {
        /// <summary>
        /// 高低转换浮点型
        /// </summary>
        /// <param name="inputH">高位</param>
        /// <param name="inputL">低位</param>
        /// <returns></returns>
        public static double Dint_to_Real(uint inputH, uint inputL)
        {
            uint Dint_T;
            string bl;  //字符串转大写？？
            string bl_dm;
            string fh;          //符号 0为正 1负
            string zs;          //整数
            string xs;          //小数
            double xs_hj;
            byte[] xs_js = new byte[24];
            string zssz;        //十六进制结果
            double Single_Data;
            double a;
            double b;
            for (int i = 0; i < 16; i++)
            {
                inputH = inputH * 2;
            }
            Dint_T = inputH + inputL;
            bl = Dint_T.ToString().ToUpper();
            bl_dm = Dec_Bin(Dint_T);
            fh = bl_dm.Substring(0, 1);                         //符号1位
            zs = bl_dm.Substring(1, 8);                         //整数位8位
            xs = bl_dm.Substring(9, 23);                        //小数位23位
            xs_hj = 1;
            //xs_js = Encoding.UTF8.GetBytes(xs);
            for (int i = 0; i < 23; i++)
            {
                xs_js[i] = Convert.ToByte(xs.Substring(i, 1));
                a = Convert.ToDouble(Math.Pow(2, (1 * (i + 1))));
                b = Convert.ToDouble(xs_js[i]) / a;
                xs_hj = xs_hj + Convert.ToSingle(b);
            }
            //二进制转16进制
            zssz = Bin_Hex(zs);
            if (fh == 0.ToString())
            { Single_Data = xs_hj * (Math.Pow(2, (Convert.ToInt16(zssz, 16) - 127))); }
            else
            { Single_Data = xs_hj * (Math.Pow(2, (Convert.ToInt16(zssz, 16) - 127))) * (-1); }
            if (Dint_T == 0)
            {
                return 0;
            }
            else if (Dint_T == 2147483648)
            {
                return -0;
            }
            //else if (Dint_T !=0 && Dint_T != 2147483648)
            else
            {
                return Single_Data;
            }
        }
        /// <summary>
        /// 两个16位整数转32位整数
        /// </summary>
        /// <param name="int1">高位</param>
        /// <param name="int2">低位</param>
        /// <returns></returns>
        public static Int32 TwoInt_Dint(uint int1, uint int2)
        {
            Int32 Dint;
            Dint = Convert.ToInt32(int1 * Math.Pow(2, 16) + int2);
            return Dint;
        }
        /// <summary>
        /// 将浮点数转化成两个无符号的int数
        /// </summary>
        /// <param name="realIntput"></param>
        /// <returns></returns>
        public static uint[] Real_to_2Int(float realIntput = 0)
        {
            uint[] returnUint = new uint[2];
            uint InPutInteger = 0;
            float InputDecimals = 0;
            int idecimals_digit = 0;
            int iTemp_Integer1 = 0;
            int iTemp_Integer2 = 0;
            int iTemp_Integer3 = 0;
            int iTemp_Integer4 = 0;
            uint iTemp_Uinteger1 = 0;
            uint iTemp_Uinteger2 = 0;
            string iInteger_to_Bin = "";
            string String_of_digit = "";
            string String_of_Index = "";
            float iTemp_Single1 = 0;
            string iTemp_String1 = "";
            string iTemp_String2 = "";
            string iTemp_String3 = "";
            string iTemp_String4 = "";

            string OutputStringH = "";
            string OutputStringL = "";
            string OutputString = "";

            double iTemp_single10 = 0;
            int iTemp_Integer10 = 0;
            int iTemp_Integer11 = 0;
            int iTemp_Integer12 = 0;
            int iTemp_Integer13 = 0;
            string iTemp_String10 = "";
            string iTemp_String11 = "";
            double iTemp_single11 = 0.0;
            if (realIntput != 0)
            {
                if (realIntput < 0)
                {
                    if (realIntput >= Convert.ToSingle(Convert.ToUInt32(realIntput * (-1))))
                    {
                        InPutInteger = Convert.ToUInt32(realIntput * (-1));
                    }
                    else
                    {
                        InPutInteger = Convert.ToUInt32(realIntput * -1) - 1;
                    }
                }
                else
                {
                    if (realIntput >= Convert.ToSingle(Convert.ToUInt32(realIntput)))
                    {
                        InPutInteger = Convert.ToUInt32(realIntput);
                    }
                    else
                    {
                        InPutInteger = Convert.ToUInt32(realIntput) - 1;
                    }
                }
                iTemp_Uinteger1 = Convert.ToUInt32(InPutInteger);

                if (InPutInteger == 0)
                {
                    iTemp_single10 = Convert.ToSingle(realIntput);
                    for (int i = 0; i < 100; i++)
                    {
                        iTemp_single10 = iTemp_single10 * 2;
                        iTemp_Integer10 = iTemp_Integer10 + 1;
                        if (iTemp_single10 >= 1.0)
                        {
                            iTemp_single11 = iTemp_single10 - 1.0;
                            break;
                        }
                    }
                    iTemp_Integer11 = 127 - iTemp_Integer10;
                    for (int i = 0; i < 8; i++)
                    {
                        iTemp_String10 = (iTemp_Integer11 % 2.0).ToString();
                        String_of_Index = iTemp_String10 + String_of_Index;
                        iTemp_Integer11 = iTemp_Integer11 / 2;
                    }
                    for (int i = 0; i < 24; i++)
                    {
                        iTemp_single11 = iTemp_single11 * 2.0;
                        if (iTemp_single11 >= 1.0)
                        {
                            iTemp_String11 = iTemp_String11 + "1";
                        }
                        else if (iTemp_single11 < 1.0)
                        {
                            iTemp_String11 = iTemp_String11 + "0";
                        }
                        if (iTemp_single11 >= 1.0)
                        {
                            iTemp_single11 = iTemp_single11 - 1.0;
                        }
                    }
                    iTemp_Integer12 = Convert.ToInt16(iTemp_String11.Substring(24, 1));
                    if (iTemp_Integer12 == 1)
                    {
                        for (int i = 0; i < 23; i++)
                        {
                            iTemp_Integer13 = Convert.ToInt32(iTemp_String11.Substring(i, 1)) * Convert.ToInt32(Math.Pow(2, (23 - i))) + iTemp_Integer13;
                        }
                        iTemp_Integer13 = iTemp_Integer13 + 1;
                        for (int i = 0; i < 23; i++)
                        {
                            iTemp_Integer13 = iTemp_Integer13 % 2;
                            String_of_digit = iTemp_Integer13 + String_of_digit;
                            iTemp_Integer13 = iTemp_Integer13 / 2;
                        }
                    }
                    else if (iTemp_Integer12 == 0)
                    {
                        String_of_digit = iTemp_String11.Substring(1, 23);
                    }
                    if (realIntput >= 0)
                    {
                        OutputString = "0" + String_of_Index + String_of_digit;
                    }
                    else if (realIntput < 0)
                    {
                        OutputString = "1" + String_of_Index + String_of_digit;
                    }
                }
                else if (InPutInteger != 0)
                {
                    for (int i = 0; i < 32; i++)
                    {
                        iTemp_Integer1 = Convert.ToInt32(InPutInteger) % 2;
                        iInteger_to_Bin = iTemp_Integer1 + iInteger_to_Bin;
                        InPutInteger = InPutInteger / 2;
                        idecimals_digit = idecimals_digit + 1;
                        if (InPutInteger == 0)
                        {
                            break;
                        }
                    }

                    if (idecimals_digit > 1)
                    {
                        idecimals_digit = idecimals_digit - 1;
                    }
                    else
                    {
                        idecimals_digit = 0;
                    }
                    iTemp_Integer2 = idecimals_digit + 127;

                    if (idecimals_digit >= 23)
                    {
                        String_of_digit = iInteger_to_Bin.Substring(1, 23);
                    }
                    else if (idecimals_digit < 23)
                    {
                        if (idecimals_digit == 0)
                        {
                            String_of_digit = "";
                        }
                        else
                        {
                            String_of_digit = iInteger_to_Bin.Substring(1, idecimals_digit);
                        }
                    }

                    for (int i = 0; i < 8; i++)
                    {
                        iTemp_Integer3 = iTemp_Integer2 % 2;
                        String_of_Index = iTemp_Integer3 + String_of_Index;
                        iTemp_Integer2 = iTemp_Integer2 / 2;
                    }

                    iTemp_Single1 = Convert.ToSingle(Convert.ToInt32(realIntput));

                    if (iTemp_Single1 > realIntput)
                    {
                        InputDecimals = realIntput + 1 - iTemp_Single1;
                    }
                    else if (iTemp_Single1 <= realIntput)
                    {
                        InputDecimals = realIntput - iTemp_Single1;
                    }

                    if (idecimals_digit >= 23)
                    {
                        if (realIntput >= 0)
                        {
                            OutputString = "0" + String_of_digit;
                        }
                        else if (realIntput < 0)
                        {
                            OutputString = "1" + String_of_digit;
                        }
                    }
                    else if (idecimals_digit < 23)
                    {
                        for (int i = 0; i < (24 - idecimals_digit); i++)
                        {
                            InputDecimals = InputDecimals * 2;
                            if (InputDecimals >= 1)
                            {
                                iTemp_String1 = iTemp_String1 + "1";
                                InputDecimals = InputDecimals - 1;
                            }
                            else if (InputDecimals < 1)
                            {
                                iTemp_String1 = iTemp_String1 + "0";
                            }
                        }
                        iTemp_String2 = iTemp_String1.Substring((23 - idecimals_digit), 1);
                        iTemp_String3 = iTemp_String1.Substring(0, (23 - idecimals_digit));
                        if (Convert.ToInt16(iTemp_String2) == 1)
                        {
                            for (int i = 0; i < (23 - idecimals_digit); i++)
                            {
                                iTemp_Uinteger2 = Convert.ToUInt32(iTemp_String3.Substring(i, 1)) * Convert.ToUInt32(Math.Pow(2, (23 - idecimals_digit - i))) + iTemp_Uinteger2;
                            }
                            iTemp_Uinteger2 = iTemp_Uinteger2 + 1;
                            for (int i = 0; i < (23 - idecimals_digit); i++)
                            {
                                iTemp_Integer4 = Convert.ToInt32(iTemp_Uinteger2 % 2);
                                iTemp_String4 = iTemp_String4 + iTemp_Integer4;
                                iTemp_Uinteger2 = iTemp_Uinteger2 / 2;
                            }
                        }
                        else if (Convert.ToInt16(iTemp_String2) == 0)
                        {
                            iTemp_String4 = iTemp_String3;
                        }
                        OutputString = String_of_Index + String_of_digit + iTemp_String4;
                        if (realIntput >= 0)
                        {
                            OutputString = "0" + OutputString;
                        }
                        else if (realIntput < 0)
                        {
                            OutputString = "1" + OutputString;
                        }
                    }
                }
                OutputStringH = OutputString.Substring(0, 16);
                OutputStringL = OutputString.Substring(16, 16);
                for (int i = 0; i < 16; i++)
                {
                    returnUint[0] = Convert.ToUInt32(OutputStringH.Substring(i, 1)) * Convert.ToUInt32(Math.Pow(2, (16 - (i + 1)))) + returnUint[0];    //高位
                }
                for (int i = 0; i < 16; i++)
                {
                    returnUint[1] = Convert.ToUInt32(OutputStringL.Substring(i, 1)) * Convert.ToUInt32(Math.Pow(2, (16 - (i + 1)))) + returnUint[1];    // 低位
                }
            }
            else if (realIntput == 0)
            {
                returnUint[0] = 0;
                returnUint[1] = 0;
            }
            return returnUint;
        }

        //1202236631
        /// <summary>
        /// 十进制转二进制
        /// </summary>
        /// <param name="inDint_T"></param>输入十进制数
        /// <returns></returns>
        private static string Dec_Bin(uint inDint_T)
        {
            uint j;
            string bl_dm = "";
            for (int i = 0; i < 32; i++)
            {
                j = inDint_T % 2;
                bl_dm = j.ToString() + bl_dm;
                inDint_T = inDint_T / 2;
            }
            return bl_dm;
        }
        private static string Bin_Hex(string strBin)
        {
            string[] bb_h = new string[2];
            string[] bb_hh = new string[2];
            string returnHex = "";
            try
            {
                bb_h[0] = strBin.Substring(0, 4); bb_h[1] = strBin.Substring(4, 4);
                for (int i = 0; i < 2; i++)
                {
                    if (bb_h[i] == "1111")
                    { bb_hh[i] = "F"; }
                    if (bb_h[i] == "1110")
                    { bb_hh[i] = "E"; }
                    if (bb_h[i] == "1101")
                    { bb_hh[i] = "D"; }
                    if (bb_h[i] == "1100")
                    { bb_hh[i] = "C"; }
                    if (bb_h[i] == "1011")
                    { bb_hh[i] = "B"; }
                    if (bb_h[i] == "1010")
                    { bb_hh[i] = "A"; }
                    if (bb_h[i] == "1001")
                    { bb_hh[i] = "9"; }
                    if (bb_h[i] == "1000")
                    { bb_hh[i] = "8"; }
                    if (bb_h[i] == "0111")
                    { bb_hh[i] = "7"; }
                    if (bb_h[i] == "0110")
                    { bb_hh[i] = "6"; }
                    if (bb_h[i] == "0101")
                    { bb_hh[i] = "5"; }
                    if (bb_h[i] == "0100")
                    { bb_hh[i] = "4"; }
                    if (bb_h[i] == "0011")
                    { bb_hh[i] = "3"; }
                    if (bb_h[i] == "0010")
                    { bb_hh[i] = "2"; }
                    if (bb_h[i] == "0001")
                    { bb_hh[i] = "1"; }
                    if (bb_h[i] == "0000")
                    { bb_hh[i] = "0"; }
                }
                returnHex = bb_hh[0] + bb_hh[1];
                return returnHex;
            }
            catch (Exception)
            {
                return returnHex;
            }
        }
    }
}
