using System;
namespace JT.Mapnumber {
    public static class OldMapnumber {
        public static string[] AllAllowedNums(int maxCount) {
            string[] numStr = new string[maxCount];
            if (maxCount < 99) {
                for (int q = 1; q <= maxCount; q++) {
                    numStr[q - 1] = q.ToString("00");
                }
            } else {
                for (int q = 1; q <= maxCount; q++) {
                    numStr[q - 1] = q.ToString("000");
                }
            }
            return numStr;
        }

        public static int SumCount(int maxCount) {
            return maxCount * maxCount;
        }

        public static string Change1234ToABCD(int num) {
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
                    throw new Exception();
            }
        }

        public static string Change1234Toabcd(int num) {
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
                    throw new Exception();
            }
        }

        public static int ChangeABCDabcdTo1234(char ABCDabcd) {
            switch (ABCDabcd) {
                case 'A':
                case 'a':
                    return 1;
                case 'B':
                case 'b':
                    return 2;
                case 'C':
                case 'c':
                    return 3;
                case 'D':
                case 'd':
                    return 4;
                default:
                    throw new Exception();
            }
        }

    }
}
