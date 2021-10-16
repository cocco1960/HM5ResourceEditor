using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HM5ResourceEditor
{
    [StructLayout(LayoutKind.Sequential)]
    public class TFixedArray
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        private byte[] start;

        public byte this[int index]
        {
            get => start[index];
        }
    }
}
