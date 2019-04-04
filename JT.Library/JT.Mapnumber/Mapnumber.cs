using System;
namespace JT.Mapnumber {

    /// <summary>
    /// Mapnumber = Sheet designation
    /// 图幅号，图幅编号
    /// 
    /// C#
    /// 
    /// By JackieTang
    ///     2016
    ///        
    /// Reference & Standard:  New mapnumber standard   GB/T 13989-2012.国家基本比例尺地形图分幅和编号 -China  
    ///                        Old mapnumber standard   Not found. Same as national geomatics center of China
    /// 
    /// Illustrate: 'W' after digital means *10,000 in most cases
    /// e.g.    100W = 100*10,000 = 1,000,000    1W = 10,000
    /// 
    /// 1 million row num and column num is same in both NewMapnumber and OldMapnumber.Longitude difference and Latitude difference is same too 
    /// 新旧图幅号100万行列数量一致、所有比例尺经差纬差一致
    /// 
    /// </summary>
    [Obsolete]
    public class Mapnumber {

        #region Defins about mapnumber      图号定义

        #region 1 million mapnumber defines,same in newmapnumber and oldmapnumber   百万图号定义，新旧图号相同

        /// <summary>
        /// 1 million standard row nums
        /// 100万标准行号
        /// </summary>
        public static readonly string[] MAPNUMBER_100W_ROWNUM = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", };
        /// <summary>
        /// 1 million standard column nums
        /// 100万标准列号
        /// </summary>
        public static readonly string[] MAPNUMBER_100W_COLUMNNUM = { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", };

        /// <summary>
        /// Check 1 million mapnumber row num is valid
        /// 检查100万图号行号是否有效
        /// </summary>
        /// <returns>true:valid;false:invalid</returns>
        public bool Check100WRownum(string rownum) {
            if (rownum.Contains(rownum)) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check 1 million mapnumber column num is valid
        /// 检查100万图号列号是否有效
        /// </summary>
        /// <returns>true:valid;false:invalid</returns>
        public bool Check100WColumnnum(string columnnum) {
            if (columnnum.Contains(columnnum)) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Change 1 million mapnumber row digital to string
        /// </summary>
        /// <returns>1 million mapnumber row string number</returns>
        public string Mapnumber100WRowDigitalToString(int mapnumber100WRownum) {
            switch (mapnumber100WRownum) {
                case 1:
                    return "A";
                case 2:
                    return "B";
                case 3:
                    return "C";
                case 4:
                    return "D";
                case 5:
                    return "E";
                case 6:
                    return "F";
                case 7:
                    return "G";
                case 8:
                    return "H";
                case 9:
                    return "I";
                case 10:
                    return "J";
                case 11:
                    return "K";
                case 12:
                    return "L";
                case 13:
                    return "M";
                case 14:
                    return "N";
                case 15:
                    return "O";
                case 16:
                    return "P";
                case 17:
                    return "Q";
                case 18:
                    return "R";
                case 19:
                    return "S";
                case 20:
                    return "T";
                case 21:
                    return "U";
                case 22:
                    return "V";
                default:
                    return "";
            }
        }

        /// <summary>
        /// Change 1 million mapnumber row string number to digital
        /// </summary>
        /// <returns>1 million mapnumber row digital number.This is not standard</returns>
        public int Mapnumber100WRowStringToDigital(string mapnumber100WRowstr) {
            switch (mapnumber100WRowstr) {
                case "A":
                    return 1;
                case "B":
                    return 2;
                case "C":
                    return 3;
                case "D":
                    return 4;
                case "E":
                    return 5;
                case "F":
                    return 6;
                case "G":
                    return 7;
                case "H":
                    return 8;
                case "I":
                    return 9;
                case "J":
                    return 10;
                case "K":
                    return 11;
                case "L":
                    return 12;
                case "M":
                    return 13;
                case "N":
                    return 14;
                case "O":
                    return 15;
                case "P":
                    return 16;
                case "Q":
                    return 17;
                case "R":
                    return 18;
                case "S":
                    return 19;
                case "T":
                    return 20;
                case "U":
                    return 21;
                case "V":
                    return 22;
                default:
                    return -1;
            }
        }

        #endregion

        #region Longitude Difference/Latitude Difference 经差、纬差

        /// <summary>
        /// 1,000,000
        /// 1 million longitude difference
        /// </summary>
        public const decimal MAPNUMBER_100W_LONGITUDE_DIFFERENT = 6M;
        /// <summary>
        /// 1,000,000
        /// 1 million latitude difference
        /// </summary>
        public const decimal MAPNUMBER_100W_LATITUDE_DIFFERENT = 4M;

        /// <summary>
        /// 500,000
        /// 500 thousand longitude difference
        /// </summary>
        public const decimal MAPNUMBER_50W_LONGITUDE_DIFFERENT = 3M;
        /// <summary>
        /// 500,000
        /// 500 thousand latitude difference
        /// </summary>
        public const decimal MAPNUMBER_50W_LATITUDE_DIFFERENT = 2M;

        /// <summary>
        /// 250,000
        /// 250 thousand longitude difference
        /// </summary>
        public const decimal MAPNUMBER_25W_LONGITUDE_DIFFERENT = 3 / 2M;
        /// <summary>
        /// 250,000
        /// 250 thousand latitude difference
        /// </summary>
        public const decimal MAPNUMBER_25W_LATITUDE_DIFFERENT = 1M;

        /// <summary>
        /// 200,000 only oldmapnumber
        /// 200 thousand longitude difference
        /// </summary>
        public const decimal MAPNUMBER_20W_LONGITUDE_DIFFERENT = 1M;
        /// <summary>
        /// 200,000 only oldmapnumber
        /// 200 thousand latitude difference
        /// </summary>
        public const decimal MAPNUMBER_20W_LATITUDE_DIFFERENT = 2 / 3M;

        /// <summary>
        /// 100,000
        /// 100 thousand longitude difference
        /// </summary>
        public const decimal MAPNUMBER_10W_LONGITUDE_DIFFERENT = 1 / 2M;
        /// <summary>
        /// 100,000
        /// 100 thousand latitude difference
        /// </summary>
        public const decimal MAPNUMBER_10W_LATITUDE_DIFFERENT = 1 / 3M;

        /// <summary>
        /// 50,000
        /// 50 thousand longitude difference
        /// </summary>
        public const decimal MAPNUMBER_5W_LONGITUDE_DIFFERENT = 1 / 4M;
        /// <summary>
        /// 50,000
        /// 50 thousand latitude difference
        /// </summary>
        public const decimal MAPNUMBER_5W_LATITUDE_DIFFERENT = 1 / 6M;

        /// <summary>
        /// 25,000
        /// 25 thousand longitude difference
        /// </summary>
        public const decimal MAPNUMBER_2_5W_LONGITUDE_DIFFERENT = 1 / 8M;
        /// <summary>
        /// 25,000
        /// 25 thousand latitude difference
        /// </summary>
        public const decimal MAPNUMBER_2_5W_LATITUDE_DIFFERENT = 1 / 12M;

        /// <summary>
        /// 10,000
        /// 10 thousand longitude difference
        /// </summary>
        public const decimal MAPNUMBER_1W_LONGITUDE_DIFFERENT = 1 / 16M;
        /// <summary>
        /// 10,000
        /// 10 thousand latitude difference
        /// </summary>
        public const decimal MAPNUMBER_1W_LATITUDE_DIFFERENT = 1 / 24M;

        /// <summary>
        /// 5,000
        /// 5 thousand longitude difference
        /// </summary>
        public const decimal MAPNUMBER_5K_LONGITUDE_DIFFERENT = 1 / 32M;
        /// <summary>
        /// 5,000
        /// 5 thousand latitude difference
        /// </summary>
        public const decimal MAPNUMBER_5K_LATITUDE_DIFFERENT = 1 / 48M;

        /// <summary>
        /// 2,000
        /// 2 thousand longitude difference
        /// </summary>
        public const decimal MAPNUMBER_2K_LONGITUDE_DIFFERENT = 1 / 96M;
        /// <summary>
        /// 2,000
        /// 2 thousand latitude difference
        /// </summary>
        public const decimal MAPNUMBER_2K_LATITUDE_DIFFERENT = 1 / 144M;

        /// <summary>
        /// 1,000
        /// 1 thousand longitude difference
        /// </summary>
        public const decimal MAPNUMBER_1K_LONGITUDE_DIFFERENT = 1 / 192M;
        /// <summary>
        /// 1,000
        /// 1 thousand latitude difference
        /// </summary>
        public const decimal MAPNUMBER_1K_LATITUDE_DIFFERENT = 1 / 288M;

        /// <summary>
        /// 500
        /// 500 longitude difference
        /// </summary>
        public const decimal MAPNUMBER_500_LONGITUDE_DIFFERENT = 1 / 384M;
        /// <summary>
        /// 500
        /// 500 latitude difference
        /// </summary>
        public const decimal MAPNUMBER_500_LATITUDE_DIFFERENT = 1 / 576M;

        #endregion

        #region New mapnumber defines   新图幅号定义

        /// <summary>
        /// Newmapnumber all scale strings
        /// 新图号比例尺字符
        /// </summary>
        public static readonly string[] NEWMAPNUMBER_SCALE = { "B", "C", "D", "E", "F", "G", "H", "I", "J", "K" };

        #region New mapnumber max row and column number

        /// <summary>
        /// 500,000
        /// Newmapnumber max row and column number
        /// 新图号最大行列号
        /// </summary>
        private const int NEWMAPNUMBER_50W_MAXNUM = 2;

        /// <summary>
        /// 250,000
        /// Newmapnumber max row and column number
        /// </summary>
        private const int NEWMAPNUMBER_25W_MAXNUM = 4;

        /// <summary>
        /// 100,000
        /// Newmapnumber max row and column number
        /// </summary>
        private const int NEWMAPNUMBER_10W_MAXNUM = 12;

        /// <summary>
        /// 50,000
        /// Newmapnumber max row and column number
        /// </summary>
        private const int NEWMAPNUMBER_5W_MAXNUM = 24;

        /// <summary>
        /// 25,000
        /// Newmapnumber max row and column number
        /// </summary>
        private const int NEWMAPNUMBER_2_5W_MAXNUM = 48;

        /// <summary>
        /// 10,000
        /// Newmapnumber max row and column number
        /// </summary>
        private const int NEWMAPNUMBER_1W_MAXNUM = 96;

        /// <summary>
        /// 5,000
        /// Newmapnumber max row and column number
        /// </summary>
        private const int NEWMAPNUMBER_5K_MAXNUM = 192;

        /// <summary>
        /// 2,000
        /// Newmapnumber max row and column number
        /// </summary>
        private const int NEWMAPNUMBER_2K_MAXNUM = 576;

        /// <summary>
        /// 1,000
        /// Newmapnumber max row and column number
        /// </summary>
        private const int NEWMAPNUMBER_1K_MAXNUM = 1152;

        /// <summary>
        /// 500
        /// Newmapnumber max row and column number
        /// </summary>
        private const int NEWMAPNUMBER_500_MAXNUM = 2304;

        #endregion

        /// <summary>
        /// Newmapnumber all row column num strings
        /// </summary>
        private string[] NewMapnumberGetAllNumByMax(int maxNum) {
            string[] numStr = new string[maxNum];
            if (maxNum < 999) {
                for (int q = 1; q <= maxNum; q++) {
                    numStr[q - 1] = q.ToString("000");
                }
            } else {
                for (int q = 1; q <= maxNum; q++) {
                    numStr[q - 1] = q.ToString("0000");
                }
            }
            return numStr;
        }

        /// <summary>
        /// Newmapnumber all row column num strings
        /// </summary>
        private string[] NewMapnumberGetAllNumByScale(string scaleStr) {
            switch (scaleStr) {
                case "B":
                    return NewMapnumberGetAllNumByMax(NEWMAPNUMBER_50W_MAXNUM);
                case "C":
                    return NewMapnumberGetAllNumByMax(NEWMAPNUMBER_25W_MAXNUM);
                case "D":
                    return NewMapnumberGetAllNumByMax(NEWMAPNUMBER_10W_MAXNUM);
                case "E":
                    return NewMapnumberGetAllNumByMax(NEWMAPNUMBER_5W_MAXNUM);
                case "F":
                    return NewMapnumberGetAllNumByMax(NEWMAPNUMBER_2_5W_MAXNUM);
                case "G":
                    return NewMapnumberGetAllNumByMax(NEWMAPNUMBER_1W_MAXNUM);
                case "H":
                    return NewMapnumberGetAllNumByMax(NEWMAPNUMBER_5K_MAXNUM);
                case "I":
                    return NewMapnumberGetAllNumByMax(NEWMAPNUMBER_2K_MAXNUM);
                case "J":
                    return NewMapnumberGetAllNumByMax(NEWMAPNUMBER_1K_MAXNUM);
                case "K":
                    return NewMapnumberGetAllNumByMax(NEWMAPNUMBER_500_MAXNUM);
                default:
                    return null;
            }
        }

        /// <summary>
        /// Newmapnumber check scale str is valid
        /// </summary>
        /// <param name="scaleStr"></param>
        /// <returns>true:valid;false:invalid</returns>
        private bool NewMapnumberCheckScale(string scaleStr) {
            if (Contains(NEWMAPNUMBER_SCALE, scaleStr)) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Newmapnumber check row column num is valid
        /// </summary>
        /// <returns>true:valid;false:invalid</returns>
        private bool NewMapnumberCheckNum(string scaleStr, string rowNum, string columnNum) {
            try {
                string[] rcNumStr = NewMapnumberGetAllNumByScale(scaleStr);
                if (rcNumStr != null) {
                    if (Contains(rcNumStr, rowNum) && Contains(rcNumStr, columnNum)) {
                        return true;
                    }
                }
                return false;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Newmapnumber get scale denominator number by scale string
        /// </summary>
        /// <param name="scaleStr"></param>
        /// <returns></returns>
        private int NewMapnumberGetScaleDenominatorNumberByScaleStr(string scaleStr) {
            switch (scaleStr) {
                case "":
                    return 1000000;
                case null:
                    return 1000000;
                case "B":
                    return 500000;
                case "C":
                    return 250000;
                case "D":
                    return 100000;
                case "E":
                    return 50000;
                case "F":
                    return 25000;
                case "G":
                    return 10000;
                case "H":
                    return 5000;
                case "I":
                    return 2000;
                case "J":
                    return 1000;
                case "K":
                    return 500;
                default:
                    return -1;
            }
        }

        #endregion

        #region Old mapnumber defines   旧图幅号定义

        #region Old mapnumber max row and column number

        private const int oldMapnumber_50W_RCNum = 2;
        private const int oldMapnumber_25W_RCNum = 4;
        private const int oldMapnumber_20W_RCNum = 6;
        private const int oldMapnumber_10W_RCNum = 12;
        private const int oldMapnumber_5W_RCNum = 2;
        private const int oldMapnumber_2_5W_RCNum = 2;
        private const int oldMapnumber_1W_RCNum = 8;

        #endregion

        private readonly string[] oldMapnumber_ABCD = { "A", "B", "C", "D" };
        private readonly string[] oldMapnumber_abcd = { "a", "b", "c", "d" };
        private readonly string[] oldMapnumber_1234 = { "1", "2", "3", "4" };

        /// <summary>
        /// Get all string by sum
        /// </summary>
        /// <param name="sumNum"></param>
        /// <returns></returns>
        private string[] OldMapnumber_GetAllRCNumStrsByMaxNum(int sumNum) {
            string[] numStr = new string[sumNum];
            if (sumNum < 99) {
                for (int q = 1; q <= sumNum; q++) {
                    numStr[q - 1] = q.ToString("00");
                }
            } else {
                for (int q = 1; q <= sumNum; q++) {
                    numStr[q - 1] = q.ToString("000");
                }
            }
            return numStr;
        }

        private int OldMapnumber_GetSumRCNum(int rcNum) {
            return rcNum * rcNum;
        }

        /// <summary>
        /// Oldmapnumber change 1234 to ABCD
        /// </summary>
        private string OldMapnumber_Change1234ToABCD(int num) {
            switch (num) {
                case 1:
                    return "A";
                case 2:
                    return "B";
                case 3:
                    return "C";
                case 4:
                    return "D";
                default:
                    return null;
            }
        }

        /// <summary>
        /// Oldmapnumber change 1234 to abcd
        /// </summary>
        private string OldMapnumber_Change1234Toabcd(int num) {
            switch (num) {
                case 1:
                    return "a";
                case 2:
                    return "b";
                case 3:
                    return "c";
                case 4:
                    return "d";
                default:
                    return null;
            }
        }

        /// <summary>
        /// Oldmapnumber change ABCD or abcd to 1234
        /// </summary>
        private int OldMapnumber_ChangeABCDTo1234(string ABCD_abcd) {
            switch (ABCD_abcd) {
                case "A":
                case "a":
                    return 1;
                case "B":
                case "b":
                    return 2;
                case "C":
                case "c":
                    return 3;
                case "D":
                case "d":
                    return 4;
                default:
                    return -1;
            }
        }

        #endregion

        #endregion


        #region Check   检查

        #region Check new mapnumber     检查新图号

        /// <summary>
        /// Check new mapnumber
        /// 检查新图幅号
        /// </summary>
        public bool NewMapnumber_Check(string newMapnumber) {
            try {
                if (string.IsNullOrEmpty(newMapnumber)) {
                    return false;
                }
                int length = newMapnumber.Length;

                #region Check length            长度检查
                if (!NewMapnumber_CheckLength(length)) {
                    return false;
                }
                #endregion

                #region Check 1 million         100万检查
                string m100W = newMapnumber.Substring(0, 3);
                if (!NewMapnumber_Check100W(m100W)) {
                    return false;
                }
                if (length == 3) {
                    return true;
                }
                #endregion

                #region Check scale string      检查比例尺代码
                string scaleStr = newMapnumber.Substring(3, 1);
                if (!NewMapnumberCheckScale(scaleStr)) {
                    return false;
                }
                #endregion

                #region Check row and column number     检查行列号
                if (length == 10 && scaleStr != "J" && scaleStr != "K") {
                    string r = newMapnumber.Substring(4, 3);
                    string c = newMapnumber.Substring(7, 3);
                    if (!NewMapnumberCheckNum(scaleStr, r, c)) {
                        return false;
                    }
                } else {
                    string r = newMapnumber.Substring(4, 4);
                    string c = newMapnumber.Substring(8, 4);
                    if (!NewMapnumberCheckNum(scaleStr, r, c)) {
                        return false;
                    }
                }
                #endregion

                return true;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Check newmapnumber length
        /// </summary>
        private bool NewMapnumber_CheckLength(int newMapnumberLength) {
            if (newMapnumberLength == 3 || newMapnumberLength == 10 || newMapnumberLength == 12) {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check newmapnumber 100W(1,000,000)
        /// </summary>
        /// <param name="newMapnumber100W"></param>
        /// <returns></returns>
        private bool NewMapnumber_Check100W(string newMapnumber100W) {
            if (newMapnumber100W.Length == 3) {
                string r = newMapnumber100W.Substring(0, 1);
                string c = newMapnumber100W.Substring(1, 2);
                if (!Check100WRownum(r) || !Check100WColumnnum(c)) {
                    return false;
                }
                return true;
            } else {
                return false;
            }
        }

        #endregion

        #region Chekc old mapnumber     检查旧图号

        /// <summary>
        /// Check old mapnumber
        /// 检查旧图幅号
        /// </summary>
        /// <param name="oldMapnumber"></param>
        /// <returns></returns>
        public bool OldMapnumber_Check(string oldMapnumber) {
            try {
                if (string.IsNullOrEmpty(oldMapnumber)) {
                    return false;
                }
                if (!oldMapnumber.Contains("-")) {
                    return false;
                }
                string[] split = oldMapnumber.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                int length = split.Length;
                if (!OldMapnumber_CheckAfterSplitLength(length)) {
                    return false;
                }
                if (length == 2)//100
                {
                    return OldMapnumber_Check100W(oldMapnumber);
                } else if (length == 3)// 50 25 20 10
                {
                    if (OldMapnumber_Check50W(oldMapnumber) || OldMapnumber_Check25W(oldMapnumber)
                        || OldMapnumber_Check20W(oldMapnumber) || OldMapnumber_Check10W(oldMapnumber)) {
                        return true;
                    } else {
                        return false;
                    }
                } else if (length == 4)// 5 1
                {
                    if (OldMapnumber_Check5W(oldMapnumber) || OldMapnumber_Check1W(oldMapnumber)) {
                        return true;
                    } else {
                        return false;
                    }
                } else if (length == 5)//2.5 0.5
                {
                    if (OldMapnumber_Check2_5W(oldMapnumber) || OldMapnumber_Check0_5W(oldMapnumber)) {
                        return true;
                    } else {
                        return false;
                    }
                } else {
                    return false;
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Check old mapnumber 100W(1,000,000)
        /// 检查100万旧图幅号
        /// </summary>
        /// <param name="oldMapnumber100W"></param>
        /// <returns></returns>
        public bool OldMapnumber_Check100W(string oldMapnumber100W) {
            try {
                if (string.IsNullOrEmpty(oldMapnumber100W)) {
                    return false;
                }

                #region Check necessary -       检查必须的-
                if (!oldMapnumber100W.Contains("-")) {
                    return false;
                }
                #endregion

                string[] split = oldMapnumber100W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                #region Check length    检查长度
                int length = split.Length;
                if (length != 2) {
                    return false;
                }
                #endregion

                #region Check 100W row column num   检查100万行列号
                string r = split[0];
                string c = split[1];
                if (!Check100WRownum(r) || !Check100WColumnnum(c)) {
                    return false;
                }
                #endregion

                return true;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Check old mapnumber 50W(500,000)
        /// 检查50万旧图幅号
        /// </summary>
        /// <param name="oldMapnumber50W"></param>
        /// <returns></returns>
        public bool OldMapnumber_Check50W(string oldMapnumber50W) {
            try {
                if (string.IsNullOrEmpty(oldMapnumber50W)) {
                    return false;
                }

                #region Check necessary -       检查必须的-
                if (!oldMapnumber50W.Contains("-")) {
                    return false;
                }
                #endregion

                string[] split = oldMapnumber50W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                #region Check length    检查长度
                int length = split.Length;
                if (length != 3) {
                    return false;
                }
                #endregion

                #region Check 100W row column num   检查100万行列号
                string r = split[0];
                string c = split[1];
                if (!Check100WRownum(r) || !Check100WColumnnum(c)) {
                    return false;
                }
                #endregion

                #region Check sub row column num    检查子行列号
                string k = split[2];
                if (!Contains(oldMapnumber_ABCD, k)) {
                    return false;
                }
                #endregion

                return true;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Check old mapnumber 25W(250,000)
        /// 检查25万旧图幅号
        /// </summary>
        /// <param name="oldMapnumber25W"></param>
        /// <returns></returns>
        public bool OldMapnumber_Check25W(string oldMapnumber25W) {
            try {
                if (string.IsNullOrEmpty(oldMapnumber25W)) {
                    return false;
                }

                #region Check necessary -[]       检查必须的 - [ ]
                if (!oldMapnumber25W.Contains("-") || !oldMapnumber25W.Contains("[") || !oldMapnumber25W.Contains("]")) {
                    return false;
                }

                #endregion

                string[] split = oldMapnumber25W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                #region Check length    检查长度
                int length = split.Length;
                if (length != 3) {
                    return false;
                }
                #endregion

                #region Check 100W row column num   检查100万行列号
                string r = split[0];
                string c = split[1];
                if (!Check100WRownum(r) || !Check100WColumnnum(c)) {
                    return false;
                }
                #endregion

                #region Check sub row column num    检查子行列号
                string k = split[2];
                string[] subSplit = k.Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
                int len = subSplit.Length;
                if (len != 1) {
                    return false;
                }
                string sub = subSplit[0];
                int sum = OldMapnumber_GetSumRCNum(oldMapnumber_25W_RCNum);
                string[] strs = OldMapnumber_GetAllRCNumStrsByMaxNum(sum);
                if (Contains(strs, sub)) {
                    return true;
                } else {
                    return false;
                }
                #endregion

            } catch {
                throw;
            }
        }

        /// <summary>
        /// Check old mapnumber 20W(200,000)
        /// 检查20万旧图幅号
        /// </summary>
        /// <param name="oldMapnumber20W"></param>
        /// <returns></returns>
        public bool OldMapnumber_Check20W(string oldMapnumber20W) {
            try {
                if (string.IsNullOrEmpty(oldMapnumber20W)) {
                    return false;
                }

                #region Check necessary -()       检查必须的 - ( )
                if (!oldMapnumber20W.Contains("-") || !oldMapnumber20W.Contains("(") || !oldMapnumber20W.Contains(")")) {
                    return false;
                }
                #endregion

                string[] split = oldMapnumber20W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                #region Check length    检查长度
                int length = split.Length;
                if (length != 3) {
                    return false;
                }
                #endregion

                #region Check 100W row column num   检查100万行列号
                string r = split[0];
                string c = split[1];
                if (!Check100WRownum(r) || !Check100WColumnnum(c)) {
                    return false;
                }
                #endregion

                #region Check sub row column num    检查子行列号
                string k = split[2];
                string[] subSplit = k.Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                int len = subSplit.Length;
                if (len != 1) {
                    return false;
                }
                string sub = subSplit[0];
                int sum = OldMapnumber_GetSumRCNum(oldMapnumber_20W_RCNum);
                string[] strs = OldMapnumber_GetAllRCNumStrsByMaxNum(sum);
                if (Contains(strs, sub)) {
                    return true;
                } else {
                    return false;
                }
                #endregion

            } catch {
                throw;
            }
        }

        /// <summary>
        /// Check old mapnumber 10W(100,000)
        /// 检查10万旧图幅号
        /// </summary>
        /// <param name="oldMapnumber10W"></param>
        /// <returns></returns>
        public bool OldMapnumber_Check10W(string oldMapnumber10W) {
            try {
                if (string.IsNullOrEmpty(oldMapnumber10W)) {
                    return false;
                }

                #region Check necessary -       检查必须的 -
                if (!oldMapnumber10W.Contains("-")) {
                    return false;
                }
                #endregion

                string[] split = oldMapnumber10W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                #region Check length    检查长度
                int length = split.Length;
                if (length != 3) {
                    return false;
                }
                #endregion

                #region Check 100W row column num   检查100万行列号
                string r = split[0];
                string c = split[1];
                if (!Check100WRownum(r) || !Check100WColumnnum(c)) {
                    return false;
                }
                #endregion

                #region Check sub row column num    检查子行列号
                string sub = split[2];
                int sum = OldMapnumber_GetSumRCNum(oldMapnumber_10W_RCNum);
                string[] strs = OldMapnumber_GetAllRCNumStrsByMaxNum(sum);
                if (Contains(strs, sub)) {
                    return true;
                } else {
                    return false;
                }
                #endregion

            } catch {
                throw;
            }
        }

        /// <summary>
        /// Check old mapnumber 5W(50,000)
        /// 检查5万旧图幅号
        /// </summary>
        /// <param name="oldMapnumber5W"></param>
        /// <returns></returns>
        public bool OldMapnumber_Check5W(string oldMapnumber5W) {
            try {
                if (string.IsNullOrEmpty(oldMapnumber5W)) {
                    return false;
                }

                #region 检查必须的 -
                if (!oldMapnumber5W.Contains("-")) {
                    return false;
                }
                #endregion

                string[] split = oldMapnumber5W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                #region 检查长度
                int length = split.Length;
                if (length != 4) {
                    return false;
                }
                #endregion

                #region 检查10万图号
                string o10W = split[0] + "-" + split[1] + "-" + split[2];
                if (!OldMapnumber_Check10W(o10W)) {
                    return false;
                }
                #endregion

                #region 检查子行列号
                string k = split[3];
                if (!Contains(oldMapnumber_ABCD, k)) {
                    return false;
                }
                #endregion

                return true;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Check old mapnumber 2.5W(25,000)
        /// 检查2.5万旧图幅号
        /// </summary>
        /// <param name="oldMapnumber2_5W"></param>
        /// <returns></returns>
        public bool OldMapnumber_Check2_5W(string oldMapnumber2_5W) {
            try {
                if (string.IsNullOrEmpty(oldMapnumber2_5W)) {
                    return false;
                }

                #region 检查必须的 -
                if (!oldMapnumber2_5W.Contains("-")) {
                    return false;
                }
                #endregion
                string[] split = oldMapnumber2_5W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                #region 检查长度
                int length = split.Length;
                if (length != 5) {
                    return false;
                }
                #endregion

                #region 检查5万图号
                string o5W = split[0] + "-" + split[1] + "-" + split[2] + "-" + split[3];
                if (!OldMapnumber_Check5W(o5W)) {
                    return false;
                }
                #endregion

                #region 检查子行列号
                string k = split[4];
                if (!Contains(oldMapnumber_1234, k)) {
                    return false;
                }
                #endregion

                return true;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Check old mapnumber 1W(10,000)
        /// 检查1万旧图幅号
        /// </summary>
        /// <param name="oldMapnumber1W"></param>
        /// <returns></returns>
        public bool OldMapnumber_Check1W(string oldMapnumber1W) {
            try {
                if (string.IsNullOrEmpty(oldMapnumber1W)) {
                    return false;
                }

                #region 检查必须的 - ( )
                if (!oldMapnumber1W.Contains("-") || !oldMapnumber1W.Contains("(") || !oldMapnumber1W.Contains(")")) {
                    return false;
                }
                #endregion

                string[] split = oldMapnumber1W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                #region 检查长度
                int length = split.Length;
                if (length != 4) {
                    return false;
                }
                #endregion

                #region 检查10万图号
                string o10W = split[0] + "-" + split[1] + "-" + split[2];
                if (!OldMapnumber_Check10W(o10W)) {
                    return false;
                }
                #endregion

                #region 检查子行列号
                string k = split[3];
                string[] subSplit = k.Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                int len = subSplit.Length;
                if (len != 1) {
                    return false;
                }
                string sub = subSplit[0];
                int sum = OldMapnumber_GetSumRCNum(oldMapnumber_1W_RCNum);
                string[] strs = OldMapnumber_GetAllRCNumStrsByMaxNum(sum);
                if (Contains(strs, sub)) {
                    return true;
                } else {
                    return false;
                }
                #endregion

            } catch {
                throw;
            }
        }

        /// <summary>
        /// Check old mapnumber 5,000
        /// 检查0.5万旧图幅号
        /// </summary>
        /// <param name="oldMapnumber0_5W"></param>
        /// <returns></returns>
        public bool OldMapnumber_Check0_5W(string oldMapnumber0_5W) {
            try {
                if (string.IsNullOrEmpty(oldMapnumber0_5W)) {
                    return false;
                }

                #region 检查必须的 - ( )
                if (!oldMapnumber0_5W.Contains("-") || !oldMapnumber0_5W.Contains("(") || !oldMapnumber0_5W.Contains(")")) {
                    return false;
                }
                #endregion

                string[] split = oldMapnumber0_5W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

                #region 检查长度
                int length = split.Length;
                if (length != 5) {
                    return false;
                }
                #endregion

                #region 检查1万图号
                string o1W = split[0] + "-" + split[1] + "-" + split[2] + "-" + split[3];
                if (!OldMapnumber_Check1W(o1W)) {
                    return false;
                }
                #endregion

                #region 检查子行列号
                string k = split[4];
                if (!Contains(oldMapnumber_abcd, k)) {
                    return false;
                }
                #endregion

                return true;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Check old mapnumber length after split
        /// </summary>
        /// <param name="oldMapnumberLength"></param>
        /// <returns></returns>
        private bool OldMapnumber_CheckAfterSplitLength(int oldMapnumberLength) {
            if (oldMapnumberLength < 2 || oldMapnumberLength > 5) {
                return false;
            }
            return true;
        }

        #endregion

        #endregion


        #region Exchange new/old mapnumber      新旧图幅号转换

        #region Old mapnumber to new mapnumber      旧图号转新图号

        /// <summary>
        /// Old mapnumber to new mapnumber
        /// 旧图幅号转新图幅号
        /// </summary>
        /// <param name="oldMapnumber"></param>
        /// <returns></returns>
        public string OldMapnumberToNewMapnumber(string oldMapnumber) {
            if (!OldMapnumber_Check(oldMapnumber)) {
                return "";
            }
            string result = "";
            result = OldMapnumberToNewMapnumber_100W(oldMapnumber);
            if (!string.IsNullOrEmpty(result)) {
                return result;
            }
            result = OldMapnumberToNewMapnumber_50W(oldMapnumber);
            if (!string.IsNullOrEmpty(result)) {
                return result;
            }
            result = OldMapnumberToNewMapnumber_25W(oldMapnumber);
            if (!string.IsNullOrEmpty(result)) {
                return result;
            }
            result = OldMapnumberToNewMapnumber_10W(oldMapnumber);
            if (!string.IsNullOrEmpty(result)) {
                return result;
            }
            result = OldMapnumberToNewMapnumber_5W(oldMapnumber);
            if (!string.IsNullOrEmpty(result)) {
                return result;
            }
            result = OldMapnumberToNewMapnumber_2_5W(oldMapnumber);
            if (!string.IsNullOrEmpty(result)) {
                return result;
            }
            result = OldMapnumberToNewMapnumber_1W(oldMapnumber);
            if (!string.IsNullOrEmpty(result)) {
                return result;
            }
            result = OldMapnumberToNewMapnumber_0_5W(oldMapnumber);
            if (!string.IsNullOrEmpty(result)) {
                return result;
            }
            return result;
        }

        /// <summary>
        /// Old mapnumber to new mapnumber 100W
        /// 100万旧图幅号转新图幅号
        /// </summary>
        /// <param name="oldMapnumber100W"></param>
        /// <returns></returns>
        public string OldMapnumberToNewMapnumber_100W(string oldMapnumber100W) {
            try {
                if (!OldMapnumber_Check100W(oldMapnumber100W)) {
                    return "";
                }
                string[] temp = oldMapnumber100W.Split('-');
                string new100 = temp[0] + temp[1].PadLeft(2, '0');
                return new100;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Old mapnumber to new mapnumber 50W
        /// 50万旧图幅号转新图幅号
        /// </summary>
        /// <param name="oldMapnumber50W"></param>
        /// <returns></returns>
        public string OldMapnumberToNewMapnumber_50W(string oldMapnumber50W) {
            try {
                if (!OldMapnumber_Check50W(oldMapnumber50W)) {
                    return "";
                }
                string[] temp = oldMapnumber50W.Split('-');
                string new100 = temp[0] + temp[1].PadLeft(2, '0');
                int x = OldMapnumber_ChangeABCDTo1234(temp[2]);
                if (x <= 0) {
                    return "";
                }
                int new50R = OldToNew50W_R(x);
                int new50C = OldToNew50W_C(x);
                return new100 + "B" + new50R.ToString().PadLeft(3, '0') + new50C.ToString().PadLeft(3, '0');
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Old mapnumber to new mapnumber 25W
        /// 25万旧图幅号转新图幅号
        /// </summary>
        /// <param name="oldMapnumber25W"></param>
        /// <returns></returns>
        public string OldMapnumberToNewMapnumber_25W(string oldMapnumber25W) {
            try {
                if (!OldMapnumber_Check25W(oldMapnumber25W)) {
                    return "";
                }
                string[] temp = oldMapnumber25W.Split('-');
                string new100 = temp[0] + temp[1].PadLeft(2, '0');
                string sub25W = temp[2];
                string[] subTemp = sub25W.Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);
                int x = int.Parse(subTemp[0]);
                int new25R = OldToNew25W_R(x);
                int new25C = OldToNew25W_C(x);
                return new100 + "C" + new25R.ToString().PadLeft(3, '0') + new25C.ToString().PadLeft(3, '0');
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Old mapnumber to new mapnumber 10W
        /// 10万旧图幅号转新图幅号
        /// </summary>
        /// <param name="oldMapnumber10W"></param>
        /// <returns></returns>
        public string OldMapnumberToNewMapnumber_10W(string oldMapnumber10W) {
            try {
                if (!OldMapnumber_Check10W(oldMapnumber10W)) {
                    return "";
                }
                string[] temp = oldMapnumber10W.Split('-');
                string new100 = temp[0] + temp[1].PadLeft(2, '0');
                string sub10W = temp[2];
                int x = int.Parse(sub10W);
                int new10R = OldToNew10W_R(x);
                int new10C = OldToNew10W_C(x);
                return new100 + "D" + new10R.ToString().PadLeft(3, '0') + new10C.ToString().PadLeft(3, '0');
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Old mapnumber to new mapnumber 5W
        /// 5万旧图幅号转新图幅号
        /// </summary>
        /// <param name="oldMapnumber5W"></param>
        /// <returns></returns>
        public string OldMapnumberToNewMapnumber_5W(string oldMapnumber5W) {
            try {
                if (!OldMapnumber_Check5W(oldMapnumber5W)) {
                    return "";
                }
                string[] temp = oldMapnumber5W.Split('-');
                string new100 = temp[0] + temp[1].PadLeft(2, '0');
                string sub10W = temp[2];
                int x = int.Parse(sub10W);
                int new10R = OldToNew10W_R(x);
                int new10C = OldToNew10W_C(x);
                int sub5W = OldMapnumber_ChangeABCDTo1234(temp[3]);
                int new5R = OldToNew5W_R(sub5W, new10R);
                int new5C = OldToNew5W_C(sub5W, new10C);
                return new100 + "E" + new5R.ToString().PadLeft(3, '0') + new5C.ToString().PadLeft(3, '0');
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Old mapnumber to new mapnumber 2.5W
        /// 2.5万旧图幅号转新图幅号
        /// </summary>
        /// <param name="oldMapnumber2_5W"></param>
        /// <returns></returns>
        public string OldMapnumberToNewMapnumber_2_5W(string oldMapnumber2_5W) {
            try {
                if (!OldMapnumber_Check2_5W(oldMapnumber2_5W)) {
                    return "";
                }
                string[] temp = oldMapnumber2_5W.Split('-');
                string new100 = temp[0] + temp[1].PadLeft(2, '0');
                string sub10W = temp[2];
                int x = int.Parse(sub10W);
                int new10R = OldToNew10W_R(x);
                int new10C = OldToNew10W_C(x);
                int sub5W = OldMapnumber_ChangeABCDTo1234(temp[3]);
                int new5R = OldToNew5W_R(sub5W, new10R);
                int new5C = OldToNew5W_C(sub5W, new10C);
                int sub2_5W = int.Parse(temp[4]);
                int new2_5R = OldToNew2_5W_R(sub2_5W, new5R);
                int new2_5C = OldToNew2_5W_C(sub2_5W, new5C);
                string new2 = new100 + "F" + new2_5R.ToString().PadLeft(3, '0') + new2_5C.ToString().PadLeft(3, '0');
                return new2;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Old mapnumber to new mapnumber 1W
        /// 1万旧图幅号转新图幅号
        /// </summary>
        /// <param name="oldMapnumber1W"></param>
        /// <returns></returns>
        public string OldMapnumberToNewMapnumber_1W(string oldMapnumber1W) {
            try {
                if (!OldMapnumber_Check1W(oldMapnumber1W)) {
                    return "";
                }
                string[] temp = oldMapnumber1W.Split('-');
                string new100 = temp[0] + temp[1].PadLeft(2, '0');
                string sub10W = temp[2];
                int x = int.Parse(sub10W);
                int new10R = OldToNew10W_R(x);
                int new10C = OldToNew10W_C(x);
                string sub1W = temp[3];
                string[] subTemp = sub1W.Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                int k = int.Parse(subTemp[0]);
                int new1R = OldToNew1W_R(k, new10R);
                int new1C = OldToNew1W_C(k, new10C);
                return new100 + "G" + new1R.ToString().PadLeft(3, '0') + new1C.ToString().PadLeft(3, '0');
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Old mapnumber to new mapnumber 0.5W
        /// 0.5万旧图幅号转新图幅号
        /// </summary>
        /// <param name="oldMapnumber0_5W"></param>
        /// <returns></returns>
        public string OldMapnumberToNewMapnumber_0_5W(string oldMapnumber0_5W) {
            try {
                if (!OldMapnumber_Check0_5W(oldMapnumber0_5W)) {
                    return "";
                }
                string[] temp = oldMapnumber0_5W.Split('-');
                string new100 = temp[0] + temp[1].PadLeft(2, '0');
                string sub10W = temp[2];
                int x = int.Parse(sub10W);
                int new10R = OldToNew10W_R(x);
                int new10C = OldToNew10W_C(x);
                string sub1W = temp[3];
                string[] subTemp = sub1W.Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                int k = int.Parse(subTemp[0]);
                int new1R = OldToNew1W_R(k, new10R);
                int new1C = OldToNew1W_C(k, new10C);
                string sub0_5W = temp[4];
                int l = OldMapnumber_ChangeABCDTo1234(sub0_5W);
                int new0_5R = OldToNew0_5W_R(l, new1R);
                int new0_5C = OldToNew0_5W_C(l, new1C);
                return new100 + "H" + new0_5R.ToString().PadLeft(3, '0') + new0_5C.ToString().PadLeft(3, '0');
            } catch {
                throw;
            }
        }

        #region Old mapnumber to new mapnumber calculate row column number      旧转新计算行列号

        /// <summary>
        /// Old mapnumber to new mapnumber calculate 50W row number
        /// </summary>
        private int OldToNew50W_R(int oldMapnumberSub50W) {
            return (oldMapnumberSub50W - 1) / 2 + 1;
        }
        /// <summary>
        /// Old mapnumber to new mapnumber calculate 50W column number
        /// </summary>
        private int OldToNew50W_C(int oldMapnumberSub50W) {
            return (oldMapnumberSub50W + 1) % 2 + 1;
        }

        /// <summary>
        /// Old mapnumber to new mapnumber calculate 25W row number
        /// </summary>
        private int OldToNew25W_R(int oldMapnumberSub25W) {
            return ((oldMapnumberSub25W - 1) / 4) + 1;
        }
        /// <summary>
        /// Old mapnumber to new mapnumber calculate 25W column number
        /// </summary>
        private int OldToNew25W_C(int oldMapnumberSub25W) {
            return ((oldMapnumberSub25W + 3) % 4) + 1;
        }

        /// <summary>
        /// Old mapnumber to new mapnumber calculate 10W row number
        /// </summary>
        private int OldToNew10W_R(int oldMapnumberSub10W) {
            return ((oldMapnumberSub10W - 1) / 12) + 1;
        }
        /// <summary>
        /// Old mapnumber to new mapnumber calculate 10W column number
        /// </summary>
        private int OldToNew10W_C(int oldMapnumberSub10W) {
            return ((oldMapnumberSub10W + 11) % 12) + 1;
        }

        /// <summary>
        /// Old mapnumber to new mapnumber calculate 5W row number
        /// </summary>
        private int OldToNew5W_R(int oldMapnumberSub5W, int new10R) {
            return (2 * new10R) + ((oldMapnumberSub5W - 1) / 2 - 1);
        }
        /// <summary>
        /// Old mapnumber to new mapnumber calculate 5W column number
        /// </summary>
        private int OldToNew5W_C(int oldMapnumberSub5W, int new10C) {
            return (2 * new10C) + ((oldMapnumberSub5W + 1) % 2 - 1);
        }

        /// <summary>
        /// Old mapnumber to new mapnumber calculate 2_5W row number
        /// </summary>
        private int OldToNew2_5W_R(int oldMapnumberSub2_5W, int new5R) {
            return 2 * new5R + (oldMapnumberSub2_5W - 1) / 2 - 1;
        }
        /// <summary>
        /// Old mapnumber to new mapnumber calculate 2_5W column number
        /// </summary>
        private int OldToNew2_5W_C(int oldMapnumberSub2_5W, int new5C) {
            return 2 * new5C + (oldMapnumberSub2_5W + 1) % 2 - 1;
        }

        /// <summary>
        /// Old mapnumber to new mapnumber calculate 1W row number
        /// </summary>
        private int OldToNew1W_R(int oldMapnumberSub1W, int new10R) {
            return 8 * new10R + ((oldMapnumberSub1W - 1) / 8) - 7;
        }
        /// <summary>
        /// Old mapnumber to new mapnumber calculate 1W column number
        /// </summary>
        private int OldToNew1W_C(int oldMapnumberSub1W, int new10C) {
            return 8 * new10C + ((oldMapnumberSub1W + 7) % 8) - 7;
        }

        /// <summary>
        /// Old mapnumber to new mapnumber calculate 0_5W row number
        /// </summary>
        private int OldToNew0_5W_R(int oldMapnumberSub0_5W, int new1R) {
            return 2 * new1R + (oldMapnumberSub0_5W - 1) / 2 - 1;
        }
        /// <summary>
        /// Old mapnumber to new mapnumber calculate 0_5W column number
        /// </summary>
        private int OldToNew0_5W_C(int oldMapnumberSub0_5W, int new1C) {
            return 2 * new1C + (oldMapnumberSub0_5W + 1) % 2 - 1;
        }

        #endregion

        #endregion

        #region New mapnumber to old mapnumber      新图号转旧图号

        /// <summary>
        /// New mapnumber to old mapnumber 
        /// 新图幅号转旧图幅号
        /// </summary>
        /// <param name="newMapnumber"></param>
        /// <returns></returns>
        public string NewMapnumberToOldMapnumber(string newMapnumber) {
            try {
                if (!NewMapnumber_Check(newMapnumber)) {
                    return "";
                }
                string[] newMapnumberInfo = GetInfoFromNewMapnumber(newMapnumber);
                if (newMapnumberInfo == null) {
                    return "";
                }
                string n100WR = newMapnumberInfo[0];
                string n100WC = newMapnumberInfo[1];
                string nScaleStr = newMapnumberInfo[2];
                string nR = newMapnumberInfo[3];
                string nC = newMapnumberInfo[4];
                int scaleNumber = NewMapnumberGetScaleDenominatorNumberByScaleStr(nScaleStr);
                if (scaleNumber == -1) {
                    return null;
                }
                #region 100万
                else if (scaleNumber == 1000000) {
                    return NewMapnumberToOldMapnumber_100W(n100WR, n100WC);
                }
                #endregion
                #region 50万
                else if (scaleNumber == 500000) {
                    string o100W = NewMapnumberToOldMapnumber_100W(n100WR, n100WC);
                    int o50W = NewToOld50WNum(nR, nC);
                    string o50WStr = OldMapnumber_Change1234ToABCD(o50W);
                    if (string.IsNullOrEmpty(o50WStr)) {
                        return "";
                    }
                    return o100W + "-" + o50WStr;
                }
                #endregion
                #region 25万
                else if (scaleNumber == 250000) {
                    string o100W = NewMapnumberToOldMapnumber_100W(n100WR, n100WC);
                    int o25W = NewToOld25WNum(nR, nC);
                    if (o25W <= 0 || o25W > 16) {
                        return "";
                    }
                    return o100W + "-[" + o25W.ToString("00") + "]";
                }
                #endregion
                #region 10万
                else if (scaleNumber == 100000) {
                    string o100W = NewMapnumberToOldMapnumber_100W(n100WR, n100WC);
                    int o10W = NewToOld10WNum(nR, nC);
                    if (o10W <= 0 || o10W > 144) {
                        return "";
                    }
                    return o100W + "-" + o10W.ToString("000");
                }
                #endregion
                #region 5万
                else if (scaleNumber == 50000) {
                    string o100W = NewMapnumberToOldMapnumber_100W(n100WR, n100WC);
                    int o5W = NewToOld5WNum(nR, nC);
                    string o5WStr = OldMapnumber_Change1234ToABCD(o5W);
                    if (string.IsNullOrEmpty(o5WStr)) {
                        return "";
                    }
                    int n10WR = New5WRCToNew10WRC(int.Parse(nR));
                    int n10WC = New5WRCToNew10WRC(int.Parse(nC));
                    int o10W = NewToOld10WNum(n10WR.ToString(), n10WC.ToString());
                    if (o10W <= 0 || o10W > 144) {
                        return "";
                    }
                    return o100W + "-" + o10W.ToString("000") + "-" + o5WStr;
                }
                #endregion
                #region 2.5万
                else if (scaleNumber == 25000) {
                    string o100W = NewMapnumberToOldMapnumber_100W(n100WR, n100WC);
                    int o2_5W = NewToOld2_5WNum(nR, nC);
                    if (o2_5W <= 0 || o2_5W > 4) {
                        return "";
                    }
                    int n5WR = New2_5WRCToNew5WRC(int.Parse(nR));
                    int n5WC = New2_5WRCToNew5WRC(int.Parse(nC));
                    int o5W = NewToOld5WNum(n5WR.ToString(), n5WC.ToString());
                    string o5WStr = OldMapnumber_Change1234ToABCD(o5W);
                    if (string.IsNullOrEmpty(o5WStr)) {
                        return "";
                    }
                    int n10WR = New5WRCToNew10WRC(n5WR);
                    int n10WC = New5WRCToNew10WRC(n5WC);
                    int o10W = NewToOld10WNum(n10WR.ToString(), n10WC.ToString());
                    if (o10W <= 0 || o10W > 144) {
                        return "";
                    }

                    return o100W + "-" + o10W.ToString("000") + "-" + o5WStr + "-" + o2_5W.ToString();
                }
                #endregion
                #region 1万
                else if (scaleNumber == 10000) {
                    string o100W = NewMapnumberToOldMapnumber_100W(n100WR, n100WC);
                    int o1W = NewToOld1WNum(nR, nC);
                    if (o1W <= 0 || o1W > 64) {
                        return "";
                    }
                    int n10WR = New1WRCToNew10WRC(int.Parse(nR));
                    int n10WC = New1WRCToNew10WRC(int.Parse(nC));
                    int o10W = NewToOld10WNum(n10WR.ToString(), n10WC.ToString());
                    if (o10W <= 0 || o10W > 144) {
                        return "";
                    }
                    return o100W + "-" + o10W.ToString("000") + "-(" + o1W.ToString("00") + ")";
                }
                #endregion
                #region 5000
                else if (scaleNumber == 5000) {
                    string o100W = NewMapnumberToOldMapnumber_100W(n100WR, n100WC);
                    int o0_5W = NewToOld0_5WNum(nR, nC);
                    string o0_5WStr = OldMapnumber_Change1234Toabcd(o0_5W);
                    if (string.IsNullOrEmpty(o0_5WStr)) {
                        return "";
                    }
                    int n1WR = New0_5WRCToNew1WRC(int.Parse(nR));
                    int n1WC = New0_5WRCToNew1WRC(int.Parse(nC));
                    int o1W = NewToOld1WNum(n1WR.ToString(), n1WC.ToString());
                    if (o1W <= 0 || o1W > 64) {
                        return "";
                    }
                    int n10WR = New1WRCToNew10WRC(n1WR);
                    int n10WC = New1WRCToNew10WRC(n1WC);
                    int o10W = NewToOld10WNum(n10WR.ToString(), n10WC.ToString());
                    if (o10W <= 0 || o10W > 144) {
                        return "";
                    }
                    return o100W + "-" + o10W.ToString("000") + "-(" + o1W.ToString("00") + ")-" + o0_5WStr;
                }
                #endregion
                else {
                    return null;
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// New mapnumber to old mapnumber 100W
        /// </summary>
        /// <param name="newMapnumber100WR"></param>
        /// <param name="newMapnumber100WC"></param>
        /// <returns></returns>
        private string NewMapnumberToOldMapnumber_100W(string newMapnumber100WR, string newMapnumber100WC) {
            return newMapnumber100WR + "-" + newMapnumber100WC;
        }

        #region New mapnumber to old mapnumber calculate row column num      新转旧计算行列号

        /// <summary>
        /// New mapnumber to old mapnumber calculate num 50W
        /// </summary>
        private int NewToOld50WNum(string newMapnumber50WR, string newMapnumber50WC) {
            int n50WR = int.Parse(newMapnumber50WR);
            int n50WC = int.Parse(newMapnumber50WC);
            return 2 * (n50WR - 1) + n50WC;
        }

        /// <summary>
        /// New mapnumber to old mapnumber calculate num 25W
        /// </summary>
        private int NewToOld25WNum(string newMapnumber25WR, string newMapnumber25WC) {
            int n25WR = int.Parse(newMapnumber25WR);
            int n25WC = int.Parse(newMapnumber25WC);
            return 4 * (n25WR - 1) + n25WC;
        }

        /// <summary>
        /// New mapnumber to old mapnumber calculate num 10W
        /// </summary>
        private int NewToOld10WNum(string newMapnumber10WR, string newMapnumber10WC) {
            int n10WR = int.Parse(newMapnumber10WR);
            int n10WC = int.Parse(newMapnumber10WC);
            return 12 * (n10WR - 1) + n10WC;
        }

        /// <summary>
        /// New mapnumber to old mapnumber calculate num 5W
        /// </summary>
        private int NewToOld5WNum(string newMapnumber5WR, string newMapnumber5WC) {
            int n5WR = int.Parse(newMapnumber5WR);
            int n5WC = int.Parse(newMapnumber5WC);
            return 2 * n5WR + n5WC - (4 * ((int)(n5WR - 1) / 2)) - (2 * ((int)(n5WC - 1) / 2)) - 2;
        }

        /// <summary>
        /// New mapnumber to old mapnumber calculate num 2.5W
        /// </summary>
        private int NewToOld2_5WNum(string newMapnumber2_5WR, string newMapnumber2_5WC) {
            int n2_5WR = int.Parse(newMapnumber2_5WR);
            int n2_5WC = int.Parse(newMapnumber2_5WC);
            return 2 * n2_5WR + n2_5WC - (4 * ((int)(n2_5WR - 1) / 2)) - (2 * ((int)(n2_5WC - 1) / 2)) - 2;
        }

        /// <summary>
        /// New mapnumber to old mapnumber calculate num 1W
        /// </summary>
        private int NewToOld1WNum(string newMapnumber1WR, string newMapnumber1WC) {
            int n1WR = int.Parse(newMapnumber1WR);
            int n1WC = int.Parse(newMapnumber1WC);
            return 8 * n1WR + n1WC - (64 * ((int)(n1WR - 1) / 8)) - (8 * ((int)(n1WC - 1) / 8)) - 8;
        }

        /// <summary>
        /// New mapnumber to old mapnumber calculate num 0.5W
        /// </summary>
        private int NewToOld0_5WNum(string newMapnumber0_5WR, string newMapnumber0_5WC) {
            int n0_5WR = int.Parse(newMapnumber0_5WR);
            int n0_5WC = int.Parse(newMapnumber0_5WC);
            return 2 * n0_5WR + n0_5WC - (4 * ((int)(n0_5WR - 1) / 2)) - (2 * ((int)(n0_5WC - 1) / 2)) - 2;
        }

        /// <summary>
        /// 5W New mapnumber row column number to 10W new mapnumber row column 
        /// </summary>
        /// <param name="newMapnumber5WRC"></param>
        /// <returns></returns>
        private int New5WRCToNew10WRC(int newMapnumber5WRC) {
            return (int)((newMapnumber5WRC - 1) / 2) + 1;
        }

        private int New2_5WRCToNew5WRC(int newMapnumber2_5WRC) {
            return (int)((newMapnumber2_5WRC - 1) / 2) + 1;
        }

        private int New1WRCToNew10WRC(int newMapnumber1WRC) {
            return (int)((newMapnumber1WRC - 1) / 8) + 1;
        }

        private int New0_5WRCToNew1WRC(int newMapnumber0_5WRC) {
            return (int)((newMapnumber0_5WRC - 1) / 2) + 1;
        }

        #endregion

        #endregion

        #region New mapnumber to new mapnumber      新图号转新图号

        /// <summary>
        /// Newmapnumber to newmapnumber
        /// 新图号转新图号
        /// </summary>
        /// <param name="newMapnumber"></param>
        /// <returns></returns>
        public string NewMapnumberToNewMapnumber(string newMapnumber) {
            if (NewMapnumber_Check(newMapnumber)) {
                return newMapnumber;
            }

            newMapnumber = newMapnumber.ToUpper();
            if (NewMapnumber_Check(newMapnumber)) {
                return newMapnumber;
            }

            return "";
        }

        #endregion

        #region Old mapnumber to old mapnumber      旧图号转旧图号

        /// <summary>
        /// Old mapnumber to old mapnumber
        /// 旧图号转旧图号
        /// </summary>
        /// <param name="oldMapnumber"></param>
        /// <param name="scaleDenominator"></param>
        /// <returns></returns>
        public string OldMapnumberToOldMapnumber(string oldMapnumber, int scaleDenominator) {
            if (scaleDenominator == 1000000) {
                return OldMapnumberToOldMapnumber100W(oldMapnumber);
            } else if (scaleDenominator == 500000) {
                return OldMapnumberToOldMapnumber50W(oldMapnumber);
            } else if (scaleDenominator == 250000) {
                return OldMapnumberToOldMapnumber25W(oldMapnumber);
            } else if (scaleDenominator == 100000) {
                return OldMapnumberToOldMapnumber10W(oldMapnumber);
            } else if (scaleDenominator == 50000) {
                return OldMapnumberToOldMapnumber5W(oldMapnumber);
            } else if (scaleDenominator == 25000) {
                return OldMapnumberToOldMapnumber2_5W(oldMapnumber);
            } else if (scaleDenominator == 10000) {
                return OldMapnumberToOldMapnumber1W(oldMapnumber);
            } else if (scaleDenominator == 5000) {
                return OldMapnumberToOldMapnumber0_5W(oldMapnumber);
            } else {
                return "";
            }
        }

        /// <summary>
        /// Change old mapnumber char 
        /// </summary>
        /// <param name="oldMapnumber"></param>
        /// <returns></returns>
        private string ChangeOldMapnumberChar(string oldMapnumber) {
            oldMapnumber = oldMapnumber.Replace("(", "");
            oldMapnumber = oldMapnumber.Replace(")", "");
            oldMapnumber = oldMapnumber.Replace("（", "");
            oldMapnumber = oldMapnumber.Replace("）", "");
            oldMapnumber = oldMapnumber.Replace("【", "");
            oldMapnumber = oldMapnumber.Replace("】", "");
            oldMapnumber = oldMapnumber.Replace("甲", "1");
            oldMapnumber = oldMapnumber.Replace("乙", "2");
            oldMapnumber = oldMapnumber.Replace("丙", "3");
            oldMapnumber = oldMapnumber.Replace("丁", "4");
            oldMapnumber = oldMapnumber.Replace("A", "1");
            oldMapnumber = oldMapnumber.Replace("B", "2");
            oldMapnumber = oldMapnumber.Replace("C", "3");
            oldMapnumber = oldMapnumber.Replace("D", "4");
            oldMapnumber = oldMapnumber.Replace("a", "1");
            oldMapnumber = oldMapnumber.Replace("b", "2");
            oldMapnumber = oldMapnumber.Replace("c", "3");
            oldMapnumber = oldMapnumber.Replace("d", "4");

            oldMapnumber = oldMapnumber.ToUpper();
            foreach (string m100WR in MAPNUMBER_100W_ROWNUM) {
                oldMapnumber = oldMapnumber.Replace(m100WR, Mapnumber100WRowStringToDigital(m100WR).ToString());
            }
            return oldMapnumber;
        }

        /// <summary>
        /// Old mapnumber to old mapnumber 100W
        /// </summary>
        private string OldMapnumberToOldMapnumber100W(string oldMapnumber100W) {
            if (string.IsNullOrEmpty(oldMapnumber100W)) {
                return "";
            }
            if (OldMapnumber_Check100W(oldMapnumber100W)) {
                return oldMapnumber100W;
            }

            oldMapnumber100W = ChangeOldMapnumberChar(oldMapnumber100W);
            if (!oldMapnumber100W.Contains("-")) {
                return "";
            }
            string[] split = oldMapnumber100W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            int length = split.Length;
            if (length != 2) {
                return "";
            }

            int x100R = -1;
            if (!int.TryParse(split[0], out x100R)) {
                return "";
            }
            int x100C = -1;
            if (!int.TryParse(split[1], out x100C)) {
                return "";
            }

            string s100R = Mapnumber100WRowDigitalToString(x100R);
            string s100C = x100C.ToString("00");
            oldMapnumber100W = s100R + "-" + s100C;
            if (OldMapnumber_Check100W(oldMapnumber100W)) {
                return oldMapnumber100W;
            }
            return "";
        }

        /// <summary>
        /// Old mapnumber to old mapnumber 50W
        /// </summary>
        private string OldMapnumberToOldMapnumber50W(string oldMapnumber50W) {
            if (string.IsNullOrEmpty(oldMapnumber50W)) {
                return "";
            }
            if (OldMapnumber_Check50W(oldMapnumber50W)) {
                return oldMapnumber50W;
            }

            oldMapnumber50W = ChangeOldMapnumberChar(oldMapnumber50W);
            if (!oldMapnumber50W.Contains("-")) {
                return "";
            }
            string[] split = oldMapnumber50W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            int length = split.Length;
            if (length != 3) {
                return "";
            }
            string x100 = split[0] + "-" + split[1];
            string s100 = OldMapnumberToOldMapnumber100W(x100);
            if (string.IsNullOrEmpty(s100)) {
                return "";
            }

            int x50 = -1;
            if (!int.TryParse(split[2], out x50)) {
                return "";
            }
            string s50 = OldMapnumber_Change1234ToABCD(x50);
            oldMapnumber50W = s100 + "-" + s50;
            if (OldMapnumber_Check50W(oldMapnumber50W)) {
                return oldMapnumber50W;
            }
            return "";
        }

        /// <summary>
        /// Old mapnumber to old mapnumber 25W
        /// </summary>
        private string OldMapnumberToOldMapnumber25W(string oldMapnumber25W) {
            if (string.IsNullOrEmpty(oldMapnumber25W)) {
                return "";
            }
            if (OldMapnumber_Check25W(oldMapnumber25W)) {
                return oldMapnumber25W;
            }

            oldMapnumber25W = ChangeOldMapnumberChar(oldMapnumber25W);
            if (!oldMapnumber25W.Contains("-")) {
                return "";
            }
            string[] split = oldMapnumber25W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            int length = split.Length;
            if (length != 3) {
                return "";
            }
            string x100 = split[0] + "-" + split[1];
            string s100 = OldMapnumberToOldMapnumber100W(x100);
            if (string.IsNullOrEmpty(s100)) {
                return "";
            }

            int x25 = -1;
            if (!int.TryParse(split[2], out x25)) {
                return "";
            }
            string s25 = x25.ToString("00");
            oldMapnumber25W = s100 + "-[" + s25 + "]";
            if (OldMapnumber_Check25W(oldMapnumber25W)) {
                return oldMapnumber25W;
            }
            return "";
        }

        /// <summary>
        /// Old mapnumber to old mapnumber 10W
        /// </summary>
        private string OldMapnumberToOldMapnumber10W(string oldMapnumber10W) {
            if (string.IsNullOrEmpty(oldMapnumber10W)) {
                return "";
            }
            if (OldMapnumber_Check10W(oldMapnumber10W)) {
                return oldMapnumber10W;
            }

            oldMapnumber10W = ChangeOldMapnumberChar(oldMapnumber10W);
            if (!oldMapnumber10W.Contains("-")) {
                return "";
            }
            string[] split = oldMapnumber10W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            int length = split.Length;
            if (length != 3) {
                return "";
            }
            string x100 = split[0] + "-" + split[1];
            string s100 = OldMapnumberToOldMapnumber100W(x100);
            if (string.IsNullOrEmpty(s100)) {
                return "";
            }

            int x10 = -1;
            if (!int.TryParse(split[2], out x10)) {
                return "";
            }
            string s10 = x10.ToString("000");
            oldMapnumber10W = s100 + "-" + s10;
            if (OldMapnumber_Check10W(oldMapnumber10W)) {
                return oldMapnumber10W;
            }
            return "";
        }

        /// <summary>
        /// Old mapnumber to old mapnumber 5W
        /// </summary>
        private string OldMapnumberToOldMapnumber5W(string oldMapnumber5W) {
            if (string.IsNullOrEmpty(oldMapnumber5W)) {
                return "";
            }
            if (OldMapnumber_Check5W(oldMapnumber5W)) {
                return oldMapnumber5W;
            }

            oldMapnumber5W = ChangeOldMapnumberChar(oldMapnumber5W);
            if (!oldMapnumber5W.Contains("-")) {
                return "";
            }
            string[] split = oldMapnumber5W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            int length = split.Length;
            if (length != 4) {
                return "";
            }
            string x10 = split[0] + "-" + split[1] + "-" + split[2];
            string s10 = OldMapnumberToOldMapnumber10W(x10);
            if (string.IsNullOrEmpty(s10)) {
                return "";
            }

            int x5 = -1;
            if (!int.TryParse(split[3], out x5)) {
                return "";
            }
            string s5 = OldMapnumber_Change1234ToABCD(x5);
            oldMapnumber5W = s10 + "-" + s5;
            if (OldMapnumber_Check5W(oldMapnumber5W)) {
                return oldMapnumber5W;
            }
            return "";
        }

        /// <summary>
        /// Old mapnumber to old mapnumber 2.5W
        /// </summary>
        private string OldMapnumberToOldMapnumber2_5W(string oldMapnumber2_5W) {
            if (string.IsNullOrEmpty(oldMapnumber2_5W)) {
                return "";
            }
            if (OldMapnumber_Check2_5W(oldMapnumber2_5W)) {
                return oldMapnumber2_5W;
            }

            oldMapnumber2_5W = ChangeOldMapnumberChar(oldMapnumber2_5W);
            if (!oldMapnumber2_5W.Contains("-")) {
                return "";
            }
            string[] split = oldMapnumber2_5W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            int length = split.Length;
            if (length != 5) {
                return "";
            }
            string x5 = split[0] + "-" + split[1] + "-" + split[2] + "-" + split[3];
            string s5 = OldMapnumberToOldMapnumber5W(x5);
            if (string.IsNullOrEmpty(s5)) {
                return "";
            }

            int x2_5 = -1;
            if (!int.TryParse(split[4], out x2_5)) {
                return "";
            }
            string s2_5 = x2_5.ToString();
            oldMapnumber2_5W = s5 + "-" + s2_5;
            if (OldMapnumber_Check2_5W(oldMapnumber2_5W)) {
                return oldMapnumber2_5W;
            }
            return "";
        }

        /// <summary>
        /// Old mapnumber to old mapnumber 1W
        /// </summary>
        private string OldMapnumberToOldMapnumber1W(string oldMapnumber1W) {
            if (string.IsNullOrEmpty(oldMapnumber1W)) {
                return "";
            }
            if (OldMapnumber_Check1W(oldMapnumber1W)) {
                return oldMapnumber1W;
            }

            oldMapnumber1W = ChangeOldMapnumberChar(oldMapnumber1W);
            if (!oldMapnumber1W.Contains("-")) {
                return "";
            }
            string[] split = oldMapnumber1W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            int length = split.Length;
            if (length != 4) {
                return "";
            }
            string x10 = split[0] + "-" + split[1] + "-" + split[2];
            string s10 = OldMapnumberToOldMapnumber10W(x10);
            if (string.IsNullOrEmpty(s10)) {
                return "";
            }

            int x1 = -1;
            if (!int.TryParse(split[3], out x1)) {
                return "";
            }
            string s1 = x1.ToString("00");
            oldMapnumber1W = s10 + "-(" + s1 + ")";
            if (OldMapnumber_Check1W(oldMapnumber1W)) {
                return oldMapnumber1W;
            }
            return "";
        }

        /// <summary>
        /// Old mapnumber to old mapnumber 0.5W
        /// </summary>
        private string OldMapnumberToOldMapnumber0_5W(string oldMapnumber0_5W) {
            if (string.IsNullOrEmpty(oldMapnumber0_5W)) {
                return "";
            }
            if (OldMapnumber_Check0_5W(oldMapnumber0_5W)) {
                return oldMapnumber0_5W;
            }

            oldMapnumber0_5W = ChangeOldMapnumberChar(oldMapnumber0_5W);
            if (!oldMapnumber0_5W.Contains("-")) {
                return "";
            }
            string[] split = oldMapnumber0_5W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
            int length = split.Length;
            if (length != 5) {
                return "";
            }
            string x1 = split[0] + "-" + split[1] + "-" + split[2] + "-(" + split[3] + ")";
            string s1 = OldMapnumberToOldMapnumber1W(x1);
            if (string.IsNullOrEmpty(s1)) {
                return "";
            }

            int x0_5 = -1;
            if (!int.TryParse(split[4], out x0_5)) {
                return "";
            }
            string s0_5 = OldMapnumber_Change1234Toabcd(x0_5);
            oldMapnumber0_5W = s1 + "-" + s0_5;
            if (OldMapnumber_Check0_5W(oldMapnumber0_5W)) {
                return oldMapnumber0_5W;
            }
            return "";
        }

        #endregion


        #endregion


        #region Exchange between mapnumber and coordinate       图幅号和坐标的转换

        #region Mapnumber to coordinate     图号转坐标

        #region New mapnumber to coordinate     新图号转坐标

        /// <summary>
        /// Calculate West North East South coordinate from new mapnumber
        /// 从新图幅号计算图廓“西北东南”坐标([0]W [1]N [2]E [3]S)
        /// </summary>
        /// <param name="newMapnumber"></param>
        /// <returns></returns>
        public decimal[] CalculateLongitudeLatitudeFromNewMapnumber(string newMapnumber) {
            try {
                decimal[] WNES = new decimal[4];
                string[] newMapnumberInfo = GetInfoFromNewMapnumber(newMapnumber);
                if (newMapnumberInfo == null) {
                    return null;
                }
                string n100WR = newMapnumberInfo[0];
                string n100WC = newMapnumberInfo[1];
                string nScaleStr = newMapnumberInfo[2];
                string nR = newMapnumberInfo[3];
                string nC = newMapnumberInfo[4];
                int scaleNumber = NewMapnumberGetScaleDenominatorNumberByScaleStr(nScaleStr);
                if (scaleNumber == -1) {
                    return null;
                }
                #region 100万
 else if (scaleNumber == 1000000) {
                    decimal W = CalculateLongitudeLatitudeFromNewMapnumberWest(n100WC, MAPNUMBER_100W_LATITUDE_DIFFERENT, "0", 0);
                    decimal S = CalculateLongitudeLatitudeFromNewMapnumberSouth(n100WR, MAPNUMBER_100W_LONGITUDE_DIFFERENT, "0", 0);
                    decimal N = S + MAPNUMBER_100W_LONGITUDE_DIFFERENT;
                    decimal E = W + MAPNUMBER_100W_LATITUDE_DIFFERENT;
                    WNES[0] = W;
                    WNES[1] = N;
                    WNES[2] = E;
                    WNES[3] = S;
                    return WNES;
                }
                #endregion
                #region 50万
 else if (scaleNumber == 500000) {
                    decimal W = CalculateLongitudeLatitudeFromNewMapnumberWest(n100WC, MAPNUMBER_100W_LATITUDE_DIFFERENT, nC, MAPNUMBER_50W_LONGITUDE_DIFFERENT);
                    decimal S = CalculateLongitudeLatitudeFromNewMapnumberSouth(n100WR, MAPNUMBER_100W_LONGITUDE_DIFFERENT, nR, MAPNUMBER_50W_LATITUDE_DIFFERENT);
                    decimal N = S + MAPNUMBER_50W_LATITUDE_DIFFERENT;
                    decimal E = W + MAPNUMBER_50W_LONGITUDE_DIFFERENT;
                    WNES[0] = W;
                    WNES[1] = N;
                    WNES[2] = E;
                    WNES[3] = S;
                    return WNES;
                }
                #endregion
                #region 25万
 else if (scaleNumber == 250000) {
                    decimal W = CalculateLongitudeLatitudeFromNewMapnumberWest(n100WC, MAPNUMBER_100W_LATITUDE_DIFFERENT, nC, MAPNUMBER_25W_LONGITUDE_DIFFERENT);
                    decimal S = CalculateLongitudeLatitudeFromNewMapnumberSouth(n100WR, MAPNUMBER_100W_LONGITUDE_DIFFERENT, nR, MAPNUMBER_25W_LATITUDE_DIFFERENT);
                    decimal N = S + MAPNUMBER_25W_LATITUDE_DIFFERENT;
                    decimal E = W + MAPNUMBER_25W_LONGITUDE_DIFFERENT;
                    WNES[0] = W;
                    WNES[1] = N;
                    WNES[2] = E;
                    WNES[3] = S;
                    return WNES;
                }
                #endregion
                #region 10万
 else if (scaleNumber == 100000) {
                    decimal W = CalculateLongitudeLatitudeFromNewMapnumberWest(n100WC, MAPNUMBER_100W_LATITUDE_DIFFERENT, nC, MAPNUMBER_10W_LONGITUDE_DIFFERENT);
                    decimal S = CalculateLongitudeLatitudeFromNewMapnumberSouth(n100WR, MAPNUMBER_100W_LONGITUDE_DIFFERENT, nR, MAPNUMBER_10W_LATITUDE_DIFFERENT);
                    decimal N = S + MAPNUMBER_10W_LATITUDE_DIFFERENT;
                    decimal E = W + MAPNUMBER_10W_LONGITUDE_DIFFERENT;
                    WNES[0] = W;
                    WNES[1] = N;
                    WNES[2] = E;
                    WNES[3] = S;
                    return WNES;
                }
                #endregion
                #region 5万
 else if (scaleNumber == 50000) {
                    decimal W = CalculateLongitudeLatitudeFromNewMapnumberWest(n100WC, MAPNUMBER_100W_LATITUDE_DIFFERENT, nC, MAPNUMBER_5W_LONGITUDE_DIFFERENT);
                    decimal S = CalculateLongitudeLatitudeFromNewMapnumberSouth(n100WR, MAPNUMBER_100W_LONGITUDE_DIFFERENT, nR, MAPNUMBER_5W_LATITUDE_DIFFERENT);
                    decimal N = S + MAPNUMBER_5W_LATITUDE_DIFFERENT;
                    decimal E = W + MAPNUMBER_5W_LONGITUDE_DIFFERENT;
                    WNES[0] = W;
                    WNES[1] = N;
                    WNES[2] = E;
                    WNES[3] = S;
                    return WNES;
                }
                #endregion
                #region 2.5万
 else if (scaleNumber == 25000) {
                    decimal W = CalculateLongitudeLatitudeFromNewMapnumberWest(n100WC, MAPNUMBER_100W_LATITUDE_DIFFERENT, nC, MAPNUMBER_2_5W_LONGITUDE_DIFFERENT);
                    decimal S = CalculateLongitudeLatitudeFromNewMapnumberSouth(n100WR, MAPNUMBER_100W_LONGITUDE_DIFFERENT, nR, MAPNUMBER_2_5W_LATITUDE_DIFFERENT);
                    decimal N = S + MAPNUMBER_2_5W_LATITUDE_DIFFERENT;
                    decimal E = W + MAPNUMBER_2_5W_LONGITUDE_DIFFERENT;
                    WNES[0] = W;
                    WNES[1] = N;
                    WNES[2] = E;
                    WNES[3] = S;
                    return WNES;
                }
                #endregion
                #region 1万
 else if (scaleNumber == 10000) {
                    decimal W = CalculateLongitudeLatitudeFromNewMapnumberWest(n100WC, MAPNUMBER_100W_LATITUDE_DIFFERENT, nC, MAPNUMBER_1W_LONGITUDE_DIFFERENT);
                    decimal S = CalculateLongitudeLatitudeFromNewMapnumberSouth(n100WR, MAPNUMBER_100W_LONGITUDE_DIFFERENT, nR, MAPNUMBER_1W_LATITUDE_DIFFERENT);
                    decimal N = S + MAPNUMBER_1W_LATITUDE_DIFFERENT;
                    decimal E = W + MAPNUMBER_1W_LONGITUDE_DIFFERENT;
                    WNES[0] = W;
                    WNES[1] = N;
                    WNES[2] = E;
                    WNES[3] = S;
                    return WNES;
                }
                #endregion
                #region 5000
 else if (scaleNumber == 5000) {
                    decimal W = CalculateLongitudeLatitudeFromNewMapnumberWest(n100WC, MAPNUMBER_100W_LATITUDE_DIFFERENT, nC, MAPNUMBER_5K_LONGITUDE_DIFFERENT);
                    decimal S = CalculateLongitudeLatitudeFromNewMapnumberSouth(n100WR, MAPNUMBER_100W_LONGITUDE_DIFFERENT, nR, MAPNUMBER_5K_LATITUDE_DIFFERENT);
                    decimal N = S + MAPNUMBER_5K_LATITUDE_DIFFERENT;
                    decimal E = W + MAPNUMBER_5K_LONGITUDE_DIFFERENT;
                    WNES[0] = W;
                    WNES[1] = N;
                    WNES[2] = E;
                    WNES[3] = S;
                    return WNES;
                }
                #endregion
                #region 2000
 else if (scaleNumber == 2000) {
                    decimal W = CalculateLongitudeLatitudeFromNewMapnumberWest(n100WC, MAPNUMBER_100W_LATITUDE_DIFFERENT, nC, MAPNUMBER_2K_LONGITUDE_DIFFERENT);
                    decimal S = CalculateLongitudeLatitudeFromNewMapnumberSouth(n100WR, MAPNUMBER_100W_LONGITUDE_DIFFERENT, nR, MAPNUMBER_2K_LATITUDE_DIFFERENT);
                    decimal N = S + MAPNUMBER_2K_LATITUDE_DIFFERENT;
                    decimal E = W + MAPNUMBER_2K_LONGITUDE_DIFFERENT;
                    WNES[0] = W;
                    WNES[1] = N;
                    WNES[2] = E;
                    WNES[3] = S;
                    return WNES;
                }
                #endregion
                #region 1000
 else if (scaleNumber == 1000) {
                    decimal W = CalculateLongitudeLatitudeFromNewMapnumberWest(n100WC, MAPNUMBER_100W_LATITUDE_DIFFERENT, nC, MAPNUMBER_1K_LONGITUDE_DIFFERENT);
                    decimal S = CalculateLongitudeLatitudeFromNewMapnumberSouth(n100WR, MAPNUMBER_100W_LONGITUDE_DIFFERENT, nR, MAPNUMBER_1K_LATITUDE_DIFFERENT);
                    decimal N = S + MAPNUMBER_1K_LATITUDE_DIFFERENT;
                    decimal E = W + MAPNUMBER_1K_LONGITUDE_DIFFERENT;
                    WNES[0] = W;
                    WNES[1] = N;
                    WNES[2] = E;
                    WNES[3] = S;
                    return WNES;
                }
                #endregion
                #region 500
 else if (scaleNumber == 500) {
                    decimal W = CalculateLongitudeLatitudeFromNewMapnumberWest(n100WC, MAPNUMBER_100W_LATITUDE_DIFFERENT, nC, MAPNUMBER_500_LONGITUDE_DIFFERENT);
                    decimal S = CalculateLongitudeLatitudeFromNewMapnumberSouth(n100WR, MAPNUMBER_100W_LONGITUDE_DIFFERENT, nR, MAPNUMBER_500_LATITUDE_DIFFERENT);
                    decimal N = S + MAPNUMBER_500_LATITUDE_DIFFERENT;
                    decimal E = W + MAPNUMBER_500_LONGITUDE_DIFFERENT;
                    WNES[0] = W;
                    WNES[1] = N;
                    WNES[2] = E;
                    WNES[3] = S;
                    return WNES;
                }
                #endregion
 else {
                    return null;
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Calculate West coordinate from new mapnumber
        /// </summary>
        private decimal CalculateLongitudeLatitudeFromNewMapnumberWest(string newMapnumber_100W_Column, decimal newMapnumber_100W_LongitudeDifference,
            string subColumn, decimal subLongitudeDifference) {
            try {
                if (string.IsNullOrEmpty(newMapnumber_100W_Column)) {
                    return 0;
                }
                if (string.IsNullOrEmpty(subColumn)) {
                    subColumn = "0";
                }
                decimal n100WC_d = decimal.Parse(newMapnumber_100W_Column);
                decimal subC_d = decimal.Parse(subColumn);
                decimal x = (n100WC_d - 31) * newMapnumber_100W_LongitudeDifference + (subC_d - 1) * subLongitudeDifference;
                return x;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Calculate South coordinate from new mapnumber
        /// </summary>
        private decimal CalculateLongitudeLatitudeFromNewMapnumberSouth(string newMapnumber_100W_Row, decimal newMapnumber_100W_LatitudeDifference,
            string subRow, decimal subLatitudeDifference) {
            try {
                if (string.IsNullOrEmpty(newMapnumber_100W_Row)) {
                    return 0;
                }
                if (string.IsNullOrEmpty(subRow)) {
                    subRow = "0";
                }
                int n100WRInt = Mapnumber100WRowStringToDigital(newMapnumber_100W_Row);
                if (n100WRInt == -1) {
                    return 0;
                }
                decimal n100WR_d = decimal.Parse(n100WRInt.ToString());
                decimal subR_d = decimal.Parse(subRow);
                if (subLatitudeDifference == 0M) {
                    decimal x = (n100WR_d - 1) * newMapnumber_100W_LatitudeDifference;
                    return x;
                } else {
                    decimal x = (n100WR_d - 1) * newMapnumber_100W_LatitudeDifference + (newMapnumber_100W_LatitudeDifference / subLatitudeDifference - subR_d) * subLatitudeDifference;
                    return x;
                }
            } catch {
                throw;
            }
        }

        #endregion

        #region Old mapnumber to coordinate     旧图号转坐标

        /// <summary>
        /// Calculate West North East South coordinate from old mapnumber
        /// 从旧图幅号计算图廓“西北东南”坐标([0]W [1]N [2]E [3]S)
        /// </summary>
        /// <param name="oldMapnumber"></param>
        /// <returns></returns>
        public decimal[] CalculateLongitudeLatitudeFromOldMapnumber(string oldMapnumber) {
            try {
                string newMapnumber = OldMapnumberToNewMapnumber(oldMapnumber);
                if (string.IsNullOrEmpty(newMapnumber)) {
                    return CalculateLongitudeLatitudeFromNewMapnumber(newMapnumber);
                } else {
                    return CalculateLongitudeLatitudeFromOldMapnumber20W(oldMapnumber);
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Calculate West North East South coordinate from 20W old mapnumber
        /// 从20万旧图幅号计算图廓“西北东南”坐标([0]W [1]N [2]E [3]S)
        /// </summary>
        /// <param name="oldMapnumber20W"></param>
        /// <returns></returns>
        public decimal[] CalculateLongitudeLatitudeFromOldMapnumber20W(string oldMapnumber20W) {
            try {
                if (!OldMapnumber_Check20W(oldMapnumber20W)) {
                    return null;
                }
                decimal[] WNES = new decimal[4];
                string[] split = oldMapnumber20W.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                string o100WR = split[0];
                string o100WC = split[1];
                string o20W = split[2];
                string[] subSplit = o20W.Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                string o20WNum = subSplit[0];
                decimal o100WW = CalculateLongitudeLatitudeFromNewMapnumberWest(o100WC, MAPNUMBER_100W_LATITUDE_DIFFERENT, "0", 0);
                decimal o100WS = CalculateLongitudeLatitudeFromNewMapnumberSouth(o100WR, MAPNUMBER_100W_LONGITUDE_DIFFERENT, "0", 0);
                int i20WNum = int.Parse(o20WNum);
                int o20WR = Old20WR(i20WNum);
                int o20WC = Old20WC(i20WNum);
                decimal W = o100WW + (o20WC - 1) * MAPNUMBER_20W_LONGITUDE_DIFFERENT;
                decimal S = o100WS + (oldMapnumber_20W_RCNum - o20WR) * MAPNUMBER_20W_LATITUDE_DIFFERENT;
                decimal N = S + MAPNUMBER_20W_LATITUDE_DIFFERENT;
                decimal E = W + MAPNUMBER_20W_LONGITUDE_DIFFERENT;
                WNES[0] = W;
                WNES[1] = N;
                WNES[2] = E;
                WNES[3] = S;
                return WNES;
            } catch {
                throw;
            }
        }

        private int Old20WR(int o20WNum) {
            return ((o20WNum - 1) / oldMapnumber_20W_RCNum) + 1;
        }
        private int Old20WC(int o20WNum) {
            return ((o20WNum - 1) % oldMapnumber_20W_RCNum) + 1;
        }

        #endregion

        #endregion

        #region Coordinate to mapnumber     坐标转图号

        #region Coordinate to new mapnumber     坐标转新图号

        /// <summary>
        /// Coordinate to new mapnumber
        /// 从经纬度计算所在新图幅号
        /// </summary>
        /// <param name="longitude">longitude/经度</param>
        /// <param name="latitude">latitude/纬度</param>
        /// <param name="scaleDenominator">scaleDenominator/比例尺分母</param>
        /// <returns></returns>
        public string CalculateNewMapnumberFromLongitudeLatitude(decimal longitude, decimal latitude, int scaleDenominator) {
            try {
                string newMapnumber_100W = CalculateNewMapnumberFromLongitudeLatitude100W(longitude, latitude);
                if (string.IsNullOrEmpty(newMapnumber_100W)) {
                    return "";
                }
                decimal[] longitudeLatitudeDifference = GetLongitudeLatitudeDifference(scaleDenominator);
                decimal longitudeDifference = longitudeLatitudeDifference[0];
                decimal latitudeDifference = longitudeLatitudeDifference[1];

                int[] subRC = CalculateNewMapnumberRowColumnIn100WFromLongitudeLatitude(longitude, latitude, longitudeDifference, latitudeDifference);
                string scaleStr = GetNewMapnumberScaleString(scaleDenominator);
                string r = "";
                string c = "";
                if (scaleStr == "J" || scaleStr == "K") {
                    r = subRC[0].ToString("0000");
                    c = subRC[1].ToString("0000");
                } else {
                    r = subRC[0].ToString("000");
                    c = subRC[1].ToString("000");
                }
                if (string.IsNullOrEmpty(scaleStr)) {
                    scaleStr = "";
                    r = "";
                    c = "";
                }
                string newMapnumber = newMapnumber_100W + scaleStr + r + c;
                if (NewMapnumber_Check(newMapnumber)) {
                    return newMapnumber;
                } else {
                    return "";
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Coordinate to 100W new mapnumber
        /// 从经纬度计算所在100万新图幅号
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <returns></returns>
        public string CalculateNewMapnumberFromLongitudeLatitude100W(decimal longitude, decimal latitude) {
            try {
                int rNum = (int)(latitude / MAPNUMBER_100W_LONGITUDE_DIFFERENT) + 1;
                int cNum = (int)(longitude / MAPNUMBER_100W_LATITUDE_DIFFERENT) + 31;
                string rStr = Mapnumber100WRowDigitalToString(rNum);
                string n100W = rStr + cNum.ToString("00");
                if (NewMapnumber_Check(n100W)) {
                    return n100W;
                } else {
                    return "";
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Coordinate to 50W new mapnumber
        /// 从经纬度计算所在50万新图幅号
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <returns></returns>
        public string CalculateNewMapnumberFromLongitudeLatitude50W(decimal longitude, decimal latitude) {
            try {
                string n100W = CalculateNewMapnumberFromLongitudeLatitude100W(longitude, latitude);
                if (string.IsNullOrEmpty(n100W)) {
                    return "";
                }
                int[] subRC = CalculateNewMapnumberRowColumnIn100WFromLongitudeLatitude(longitude, latitude, MAPNUMBER_50W_LONGITUDE_DIFFERENT, MAPNUMBER_50W_LATITUDE_DIFFERENT);
                string r = subRC[0].ToString("000");
                string c = subRC[1].ToString("000");
                string n50W = n100W + "B" + r + c;
                if (NewMapnumber_Check(n50W)) {
                    return n50W;
                } else {
                    return "";
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Coordinate to 25W new mapnumber
        /// 从经纬度计算所在25万新图幅号
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <returns></returns>
        public string CalculateNewMapnumberFromLongitudeLatitude25W(decimal longitude, decimal latitude) {
            try {
                string n100W = CalculateNewMapnumberFromLongitudeLatitude100W(longitude, latitude);
                if (string.IsNullOrEmpty(n100W)) {
                    return "";
                }
                int[] subRC = CalculateNewMapnumberRowColumnIn100WFromLongitudeLatitude(longitude, latitude, MAPNUMBER_25W_LONGITUDE_DIFFERENT, MAPNUMBER_25W_LATITUDE_DIFFERENT);
                string r = subRC[0].ToString("000");
                string c = subRC[1].ToString("000");
                string n25W = n100W + "C" + r + c;
                if (NewMapnumber_Check(n25W)) {
                    return n25W;
                } else {
                    return "";
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Coordinate to 10W new mapnumber
        /// 从经纬度计算所在10万新图幅号
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <returns></returns>
        public string CalculateNewMapnumberFromLongitudeLatitude10W(decimal longitude, decimal latitude) {
            try {
                string n100W = CalculateNewMapnumberFromLongitudeLatitude100W(longitude, latitude);
                if (string.IsNullOrEmpty(n100W)) {
                    return "";
                }
                int[] subRC = CalculateNewMapnumberRowColumnIn100WFromLongitudeLatitude(longitude, latitude, MAPNUMBER_10W_LONGITUDE_DIFFERENT, MAPNUMBER_10W_LATITUDE_DIFFERENT);
                string r = subRC[0].ToString("000");
                string c = subRC[1].ToString("000");
                string n10W = n100W + "D" + r + c;
                if (NewMapnumber_Check(n10W)) {
                    return n10W;
                } else {
                    return "";
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Coordinate to 5W new mapnumber
        /// 从经纬度计算所在5万新图幅号
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <returns></returns>
        public string CalculateNewMapnumberFromLongitudeLatitude5W(decimal longitude, decimal latitude) {
            try {
                string n100W = CalculateNewMapnumberFromLongitudeLatitude100W(longitude, latitude);
                if (string.IsNullOrEmpty(n100W)) {
                    return "";
                }
                int[] subRC = CalculateNewMapnumberRowColumnIn100WFromLongitudeLatitude(longitude, latitude, MAPNUMBER_5W_LONGITUDE_DIFFERENT, MAPNUMBER_5W_LATITUDE_DIFFERENT);
                string r = subRC[0].ToString("000");
                string c = subRC[1].ToString("000");
                string n5W = n100W + "E" + r + c;
                if (NewMapnumber_Check(n5W)) {
                    return n5W;
                } else {
                    return "";
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Coordinate to 2.5W new mapnumber
        /// 从经纬度计算所在2.5万新图幅号
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <returns></returns>
        public string CalculateNewMapnumberFromLongitudeLatitude2_5W(decimal longitude, decimal latitude) {
            try {
                string n100W = CalculateNewMapnumberFromLongitudeLatitude100W(longitude, latitude);
                if (string.IsNullOrEmpty(n100W)) {
                    return "";
                }
                int[] subRC = CalculateNewMapnumberRowColumnIn100WFromLongitudeLatitude(longitude, latitude, MAPNUMBER_2_5W_LONGITUDE_DIFFERENT, MAPNUMBER_2_5W_LATITUDE_DIFFERENT);
                string r = subRC[0].ToString("000");
                string c = subRC[1].ToString("000");
                string n2_5W = n100W + "F" + r + c;
                if (NewMapnumber_Check(n2_5W)) {
                    return n2_5W;
                } else {
                    return "";
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Coordinate to 1W new mapnumber
        /// 从经纬度计算所在1万新图幅号
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <returns></returns>
        public string CalculateNewMapnumberFromLongitudeLatitude1W(decimal longitude, decimal latitude) {
            try {
                string n100W = CalculateNewMapnumberFromLongitudeLatitude100W(longitude, latitude);
                if (string.IsNullOrEmpty(n100W)) {
                    return "";
                }
                int[] subRC = CalculateNewMapnumberRowColumnIn100WFromLongitudeLatitude(longitude, latitude, MAPNUMBER_1W_LONGITUDE_DIFFERENT, MAPNUMBER_1W_LATITUDE_DIFFERENT);
                string r = subRC[0].ToString("000");
                string c = subRC[1].ToString("000");
                string n1W = n100W + "G" + r + c;
                if (NewMapnumber_Check(n1W)) {
                    return n1W;
                } else {
                    return "";
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Coordinate to 0.5W new mapnumber
        /// 从经纬度计算所在0.5万新图幅号
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <returns></returns>
        public string CalculateNewMapnumberFromLongitudeLatitude0_5W(decimal longitude, decimal latitude) {
            try {
                string n100W = CalculateNewMapnumberFromLongitudeLatitude100W(longitude, latitude);
                if (string.IsNullOrEmpty(n100W)) {
                    return "";
                }
                int[] subRC = CalculateNewMapnumberRowColumnIn100WFromLongitudeLatitude(longitude, latitude, MAPNUMBER_5K_LONGITUDE_DIFFERENT, MAPNUMBER_5K_LATITUDE_DIFFERENT);
                string r = subRC[0].ToString("000");
                string c = subRC[1].ToString("000");
                string n0_5W = n100W + "H" + r + c;
                if (NewMapnumber_Check(n0_5W)) {
                    return n0_5W;
                } else {
                    return "";
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Coordinate to 0.2W new mapnumber
        /// 从经纬度计算所在0.2万新图幅号
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <returns></returns>
        public string CalculateNewMapnumberFromLongitudeLatitude0_2W(decimal longitude, decimal latitude) {
            try {
                string n100W = CalculateNewMapnumberFromLongitudeLatitude100W(longitude, latitude);
                if (string.IsNullOrEmpty(n100W)) {
                    return "";
                }
                int[] subRC = CalculateNewMapnumberRowColumnIn100WFromLongitudeLatitude(longitude, latitude, MAPNUMBER_2K_LONGITUDE_DIFFERENT, MAPNUMBER_2K_LATITUDE_DIFFERENT);
                string r = subRC[0].ToString("000");
                string c = subRC[1].ToString("000");
                string n0_2W = n100W + "I" + r + c;
                if (NewMapnumber_Check(n0_2W)) {
                    return n0_2W;
                } else {
                    return "";
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Coordinate to 0.1W new mapnumber
        /// 从经纬度计算所在0.1万新图幅号
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <returns></returns>
        public string CalculateNewMapnumberFromLongitudeLatitude0_1W(decimal longitude, decimal latitude) {
            try {
                string n100W = CalculateNewMapnumberFromLongitudeLatitude100W(longitude, latitude);
                if (string.IsNullOrEmpty(n100W)) {
                    return "";
                }
                int[] subRC = CalculateNewMapnumberRowColumnIn100WFromLongitudeLatitude(longitude, latitude, MAPNUMBER_1K_LONGITUDE_DIFFERENT, MAPNUMBER_1K_LATITUDE_DIFFERENT);
                string r = subRC[0].ToString("0000");
                string c = subRC[1].ToString("0000");
                string n0_1W = n100W + "J" + r + c;
                if (NewMapnumber_Check(n0_1W)) {
                    return n0_1W;
                } else {
                    return "";
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Coordinate to 500 new mapnumber
        /// 从经纬度计算所在500新图幅号
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <returns></returns>
        public string CalculateNewMapnumberFromLongitudeLatitude500(decimal longitude, decimal latitude) {
            try {
                string n100W = CalculateNewMapnumberFromLongitudeLatitude100W(longitude, latitude);
                if (string.IsNullOrEmpty(n100W)) {
                    return "";
                }
                int[] subRC = CalculateNewMapnumberRowColumnIn100WFromLongitudeLatitude(longitude, latitude, MAPNUMBER_500_LONGITUDE_DIFFERENT, MAPNUMBER_500_LATITUDE_DIFFERENT);
                string r = subRC[0].ToString("0000");
                string c = subRC[1].ToString("0000");
                string n500 = n100W + "K" + r + c;
                if (NewMapnumber_Check(n500)) {
                    return n500;
                } else {
                    return "";
                }
            } catch {
                throw;
            }
        }

        private int[] CalculateNewMapnumberRowColumnIn100WFromLongitudeLatitude(decimal longitude, decimal latitude, decimal JC, decimal WC) {
            int rNum = (int)(Math.Round((MAPNUMBER_100W_LONGITUDE_DIFFERENT / WC), MidpointRounding.AwayFromZero)) - (int)((latitude % MAPNUMBER_100W_LONGITUDE_DIFFERENT) / WC);
            int cNum = (int)((int)((longitude % MAPNUMBER_100W_LATITUDE_DIFFERENT) / JC)) + 1;

            return new int[] { rNum, cNum };
        }

        #endregion

        #region Coordinate to old mapnumber     坐标转旧图号

        /// <summary>
        /// Coordinate to old mapnumber
        /// 从经纬度计算所在旧图幅号
        /// </summary>
        /// <param name="longitude">经度</param>
        /// <param name="latitude">纬度</param>
        /// <param name="scaleDenominator">比例尺分母</param>
        /// <returns></returns>
        public string CalculateOldMapnumberFromLongitudeLatitude(decimal longitude, decimal latitude, int scaleDenominator) {
            try {
                string n100W = CalculateNewMapnumberFromLongitudeLatitude100W(longitude, latitude);
                if (string.IsNullOrEmpty(n100W)) {
                    return "";
                }
                decimal[] jwc = GetLongitudeLatitudeDifference(scaleDenominator);
                decimal JC = jwc[0];
                decimal WC = jwc[1];
                int[] subRC = CalculateNewMapnumberRowColumnIn100WFromLongitudeLatitude(longitude, latitude, JC, WC);
                string scaleStr = GetNewMapnumberScaleString(scaleDenominator);
                #region 20万
                if (scaleDenominator == 200000) {
                    return CalculateOldMapnumberFromLongitudeLatitude20W(longitude, latitude);
                }
                #endregion
                #region
 else {
                    string r = "";
                    string c = "";
                    if (scaleStr == "J" || scaleStr == "K") {
                        r = subRC[0].ToString("0000");
                        c = subRC[1].ToString("0000");
                    } else {
                        r = subRC[0].ToString("000");
                        c = subRC[1].ToString("000");
                    }
                    if (string.IsNullOrEmpty(scaleStr)) {
                        scaleStr = "";
                        r = "";
                        c = "";
                    }
                    string newMapnumber = n100W + scaleStr + r + c;
                    if (NewMapnumber_Check(newMapnumber)) {
                        string oldMapnumber = NewMapnumberToOldMapnumber(newMapnumber);
                        if (OldMapnumber_Check(oldMapnumber)) {
                            return oldMapnumber;
                        } else {
                            return "";
                        }
                    } else {
                        return "";
                    }
                }
                #endregion
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Coordinate to 100W old mapnumber
        /// 从经纬度计算所在100万旧图幅号
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <returns></returns>
        public string CalculateOldMapnumberFromLongitudeLatitude100W(decimal longitude, decimal latitude) {
            try {
                int rNum = (int)(latitude / MAPNUMBER_100W_LONGITUDE_DIFFERENT) + 1;
                int cNum = (int)(longitude / MAPNUMBER_100W_LATITUDE_DIFFERENT) + 31;
                string rStr = Mapnumber100WRowDigitalToString(rNum);
                string o100W = rStr + "-" + cNum.ToString("00");
                if (OldMapnumber_Check100W(o100W)) {
                    return o100W;
                } else {
                    return "";
                }
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Coordinate to 20W old mapnumber
        /// 从经纬度计算所在20万旧图幅号
        /// </summary>
        /// <param name="longitude"></param>
        /// <param name="latitude"></param>
        /// <returns></returns>
        public string CalculateOldMapnumberFromLongitudeLatitude20W(decimal longitude, decimal latitude) {
            try {
                string o100W = CalculateOldMapnumberFromLongitudeLatitude100W(longitude, latitude);
                if (string.IsNullOrEmpty(o100W)) {
                    return "";
                }
                int[] subRC = CalculateNewMapnumberRowColumnIn100WFromLongitudeLatitude(longitude, latitude, MAPNUMBER_20W_LONGITUDE_DIFFERENT, MAPNUMBER_20W_LATITUDE_DIFFERENT);
                int o20WNum = O20WNum(subRC[0], subRC[1]);
                string o20W = o100W + "-(" + o20WNum.ToString("00") + ")";
                if (OldMapnumber_Check20W(o20W)) {
                    return o20W;
                } else {
                    return "";
                }
            } catch {
                throw;
            }
        }

        private int O20WNum(int n20WR, int n20WC) {
            return oldMapnumber_20W_RCNum * (n20WR - 1) + n20WC;
        }

        #endregion

        #endregion

        #endregion


        #region Other       其他

        /// <summary>
        /// Get 100W Row/100W Column/ScaleStr/Rownum/Columnnum from new  mapnumber
        /// 从新图号获得比例尺、行列号信息（[0]：百万行；[1]：百万咧；[2]：比例尺代码；[3]：行号；[4]：列号）
        /// </summary>
        /// <param name="newMapnumber"></param>
        /// <returns></returns>
        public string[] GetInfoFromNewMapnumber(string newMapnumber) {
            try {
                string[] strs = new string[5];
                if (!NewMapnumber_Check(newMapnumber)) {
                    return null;
                }
                int length = newMapnumber.Length;
                string n100WR = "";
                string n100WC = "";
                string nScaleStr = "";
                string nR = "";
                string nC = "";
                if (length == 3) {
                    n100WR = newMapnumber.Substring(0, 1);
                    n100WC = newMapnumber.Substring(1, 2);
                } else {
                    n100WR = newMapnumber.Substring(0, 1);
                    n100WC = newMapnumber.Substring(1, 2);
                    nScaleStr = newMapnumber.Substring(3, 1);
                    if (length == 10) {
                        nR = newMapnumber.Substring(4, 3);
                        nC = newMapnumber.Substring(7, 3);
                    } else {
                        nR = newMapnumber.Substring(4, 4);
                        nC = newMapnumber.Substring(8, 4);
                    }
                }
                if (!string.IsNullOrEmpty(n100WR) && !string.IsNullOrEmpty(n100WC)) {
                    strs[0] = n100WR;
                    strs[1] = n100WC;
                    strs[2] = nScaleStr;
                    strs[3] = nR;
                    strs[4] = nC;
                    return strs;
                }
                return null;
            } catch {
                throw;
            }
        }

        /// <summary>
        /// Get longitude and latitude difference from scale denominator
        /// 从比例尺分母获得经差、纬差 [0]：经差；[1]：纬差
        /// </summary>
        /// <param name="scaleDenominator"></param>
        /// <returns></returns>
        public decimal[] GetLongitudeLatitudeDifference(int scaleDenominator) {
            switch (scaleDenominator) {
                case 1000000:
                    return new decimal[] { MAPNUMBER_100W_LATITUDE_DIFFERENT, MAPNUMBER_100W_LONGITUDE_DIFFERENT };
                case 500000:
                    return new decimal[] { MAPNUMBER_50W_LONGITUDE_DIFFERENT, MAPNUMBER_50W_LATITUDE_DIFFERENT };
                case 250000:
                    return new decimal[] { MAPNUMBER_25W_LONGITUDE_DIFFERENT, MAPNUMBER_25W_LATITUDE_DIFFERENT };
                case 200000:
                    return new decimal[] { MAPNUMBER_20W_LONGITUDE_DIFFERENT, MAPNUMBER_20W_LATITUDE_DIFFERENT };
                case 100000:
                    return new decimal[] { MAPNUMBER_10W_LONGITUDE_DIFFERENT, MAPNUMBER_10W_LATITUDE_DIFFERENT };
                case 50000:
                    return new decimal[] { MAPNUMBER_5W_LONGITUDE_DIFFERENT, MAPNUMBER_5W_LATITUDE_DIFFERENT };
                case 25000:
                    return new decimal[] { MAPNUMBER_2_5W_LONGITUDE_DIFFERENT, MAPNUMBER_2_5W_LATITUDE_DIFFERENT };
                case 10000:
                    return new decimal[] { MAPNUMBER_1W_LONGITUDE_DIFFERENT, MAPNUMBER_1W_LATITUDE_DIFFERENT };
                case 5000:
                    return new decimal[] { MAPNUMBER_5K_LONGITUDE_DIFFERENT, MAPNUMBER_5K_LATITUDE_DIFFERENT };
                case 2000:
                    return new decimal[] { MAPNUMBER_2K_LONGITUDE_DIFFERENT, MAPNUMBER_2K_LATITUDE_DIFFERENT };
                case 1000:
                    return new decimal[] { MAPNUMBER_1K_LONGITUDE_DIFFERENT, MAPNUMBER_1K_LATITUDE_DIFFERENT };
                case 500:
                    return new decimal[] { MAPNUMBER_500_LONGITUDE_DIFFERENT, MAPNUMBER_500_LATITUDE_DIFFERENT };
                default:
                    return null;
            }
        }

        /// <summary>
        /// Get scale str from scale denominator
        /// 从比例尺分母获得新图号中的比例尺代码
        /// </summary>
        /// <param name="scaleDenominator"></param>
        /// <returns></returns>
        public string GetNewMapnumberScaleString(int scaleDenominator) {
            switch (scaleDenominator) {
                case 1000000:
                    return "";
                case 500000:
                    return "B";
                case 250000:
                    return "C";
                case 100000:
                    return "D";
                case 50000:
                    return "E";
                case 25000:
                    return "F";
                case 10000:
                    return "G";
                case 5000:
                    return "H";
                case 2000:
                    return "I";
                case 1000:
                    return "J";
                case 500:
                    return "K";
                default:
                    return null;
            }
        }

        ///// <summary>
        ///// Get polygon from new mapnumber
        ///// 根据图号，生成面图形
        ///// </summary>
        ///// <param name="newMapnumber"></param>
        ///// <returns></returns>
        //public ESRI.ArcGIS.Geometry.IGeometry GetPolygonGeometryFromNewMapnumber( string newMapnumber ) {
        //    if ( NewMapnumber_Check( newMapnumber ) ) {
        //        decimal[] coor = CalculateLongitudeLatitudeFromNewMapnumber( newMapnumber );
        //        if ( coor != null ) {
        //            ESRI.ArcGIS.Geometry.Ring ring = new ESRI.ArcGIS.Geometry.RingClass();

        //            ESRI.ArcGIS.Geometry.Point p1 = new ESRI.ArcGIS.Geometry.PointClass();
        //            p1. PutCoords( decimal. ToDouble( coor[0] ) , decimal. ToDouble( coor[1] ) );
        //            ring. AddPoint( p1 );

        //            ESRI. ArcGIS. Geometry. Point p2 = new ESRI. ArcGIS. Geometry. PointClass();
        //            p2. PutCoords( decimal. ToDouble( coor[0] ) , decimal. ToDouble( coor[3] ) );
        //            ring. AddPoint( p2 );

        //            ESRI. ArcGIS. Geometry. Point p3 = new ESRI. ArcGIS. Geometry. PointClass();
        //            p3. PutCoords( decimal. ToDouble( coor[2] ) , decimal. ToDouble( coor[3] ) );
        //            ring. AddPoint( p3 );

        //            ESRI. ArcGIS. Geometry. Point p4 = new ESRI. ArcGIS. Geometry. PointClass();
        //            p4. PutCoords( decimal. ToDouble( coor[2] ) , decimal. ToDouble( coor[1] ) );
        //            ring. AddPoint( p4 );

        //            ring. AddPoint( p1 );

        //            ESRI.ArcGIS.Geometry.IGeometryCollection pointPolygon = new ESRI.ArcGIS.Geometry.PolygonClass();
        //            pointPolygon. AddGeometry( ring as ESRI.ArcGIS.Geometry.IGeometry );
        //            ESRI.ArcGIS.Geometry.IPolygon pPolygon = pointPolygon as ESRI.ArcGIS.Geometry.IPolygon;
        //            ESRI.ArcGIS.Geometry.IGeometry pGeometry = pPolygon as ESRI.ArcGIS.Geometry.IGeometry;
        //            return pGeometry;
        //        }
        //    }
        //    return null;
        //}

        private bool Contains(string[] strs, string str) {
            if (strs == null || strs.Length <= 0) { return false; }
            var count = strs.Length;
            for (int i = 0; i < count; i++) {
                if (strs[i] == str) { return true; }
            }
            return false;
        }


        #endregion

    }
}
