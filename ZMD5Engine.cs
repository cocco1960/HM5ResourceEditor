using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HM5ResourceEditor
{
    [StructLayout(LayoutKind.Sequential)]
    public class ZMD5Engine
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private uint[] state;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private uint[] count;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        private char[] buffer;

        public static string ToString(TFixedArray md5value)
        {
            char[] resulta = new char[32];
            int index = 1;
            int index2 = 1;
            int i = 4;

            do
            {
                byte b = md5value[index - 1];

                resulta[index2 - 1] = "0123456789ABCDEF"[b >> 4];

                char c = "0123456789ABCDEF"[b & 0xF];
                byte b2 = md5value[index];

                resulta[index2] = c;
                resulta[index2 + 1] = "0123456789ABCDEF"[b2 >> 4];

                char c2 = "0123456789ABCDEF"[b2 & 0xF];
                byte b3 = md5value[index + 1];

                resulta[index2 + 2] = c2;
                resulta[index2 + 3] = "0123456789ABCDEF"[b3 >> 4];

                char c3 = "0123456789ABCDEF"[b3 & 0xF];
                byte b4 = md5value[index + 2];

                resulta[index2 + 4] = c3;
                resulta[index2 + 5] = "0123456789ABCDEF"[b4 >> 4];
                resulta[index2 + 6] = "0123456789ABCDEF"[b4 & 0xF];

                index += 4;
                index2 += 8;
                --i;
            }
            while (i != 0);

            return new string(resulta);
        }
    }
}
