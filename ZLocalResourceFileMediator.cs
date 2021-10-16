using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HM5ResourceEditor
{
    class ZLocalResourceFileMediator
    {
        public ZMD5Engine md5Engine
        {
            get;
            set;
        } = new ZMD5Engine();

        public IntPtr UnmanagedAddr
        {
            get;
            set;
        }

        public string DevicePath
        {
            get;
            set;
        }

        public string ProjectPath
        {
            get;
            set;
        }

        public string RuntimePath
        {
            get;
            set;
        }

        [DllImport(@"C:\Program Files (x86)\Steam\steamapps\common\Hitman Absolution\Debug\runtime.resource.dll", EntryPoint = "#406", CallingConvention = CallingConvention.ThisCall)]
        public static extern void reset(IntPtr md5Engine);

        [DllImport(@"C:\Program Files (x86)\Steam\steamapps\common\Hitman Absolution\Debug\runtime.resource.dll", EntryPoint = "#407", CallingConvention = CallingConvention.ThisCall)]
        public static extern void update(IntPtr md5Engine, [MarshalAs(UnmanagedType.LPStr)] string pData, uint dataLength);

        [DllImport(@"C:\Program Files (x86)\Steam\steamapps\common\Hitman Absolution\Debug\runtime.resource.dll", EntryPoint = "#411", CallingConvention = CallingConvention.ThisCall)]
        public static extern IntPtr final(IntPtr md5Engine, IntPtr result);

        public ZLocalResourceFileMediator()
        {
            UnmanagedAddr = Marshal.AllocHGlobal(Marshal.SizeOf(md5Engine));
            DevicePath = "";
            ProjectPath = "../";
            RuntimePath = "runtime/";
        }

        ~ZLocalResourceFileMediator()
        {
            Marshal.FreeHGlobal(UnmanagedAddr);
        }

        public void CallResetFunction()
        {
            Marshal.StructureToPtr(md5Engine, UnmanagedAddr, true);

            reset(UnmanagedAddr);

            Marshal.PtrToStructure(UnmanagedAddr, md5Engine);
        }

        public void CallUpdateFunction(string pData, uint dataLength)
        {
            Marshal.StructureToPtr(md5Engine, UnmanagedAddr, false);

            update(UnmanagedAddr, pData, dataLength);

            Marshal.PtrToStructure(UnmanagedAddr, md5Engine);
        }

        public TFixedArray CallFinalFunction()
        {
            TFixedArray result2 = new TFixedArray();
            IntPtr UnmanagedAddr2 = Marshal.AllocHGlobal(Marshal.SizeOf(result2));

            Marshal.StructureToPtr(md5Engine, UnmanagedAddr, false);
            Marshal.StructureToPtr(result2, UnmanagedAddr2, false);

            IntPtr result = final(UnmanagedAddr, UnmanagedAddr2);

            Marshal.PtrToStructure(UnmanagedAddr, md5Engine);

            Marshal.PtrToStructure(result, result2);
            Marshal.FreeHGlobal(result);

            return result2;
        }

        public string CalcResourceFileName(ZResourceID idOriginalResource)
        {
            string result = "";
            ZResourceID initial = idOriginalResource;
            ZResourceID DLCRoot = new ZResourceID(initial.Uri.ToLower());

            ZResourceID idResource = new ZResourceID
            {
                Uri = DLCRoot.Uri
            };

            string platorm = idResource.GetPlatformFromExtension();

            if (idResource.IsDerived())
            {
                ZResourceID sourceResourceID = idResource.GetSourceResourceID();
                ZResourceID root = sourceResourceID.GetRoot();

                DLCRoot = ZResourceID.GetInnermostSourceRootID(root);
            }
            else
            {
                DLCRoot = idResource.GetRoot();
            }

            initial = DLCRoot;

            StringBuilder pathName = new StringBuilder();

            pathName.Append(initial.Uri);
            pathName = pathName.Replace(":/", "/");
            pathName = pathName.Replace(':', '/');
            pathName = pathName.Replace(' ', '_');
            pathName = pathName.Replace("//", "/");

            if (pathName.ToString().StartsWith("assembly/"))
            {
                pathName.Remove(0, 9);
            }

            if (platorm.Equals("xbox360"))
            {
                DLCRoot.Uri = pathName.ToString();

                pathName.Clear();

                int var = 0;

                for (int i = 0; i < DLCRoot.Uri.Length; i++)
                {
                    if (var < 42 || DLCRoot.Uri[i] == '/')
                    {
                        pathName.Append(DLCRoot.Uri[i]);

                        var++;

                        if (DLCRoot.Uri[i] == '/')
                        {
                            var = 0;
                        }
                    }
                    else if (var == 42 && pathName.ToString().EndsWith("."))
                    {
                        pathName.Remove(pathName.Length - 1, 1);
                    }
                }
            }

            StringBuilder path = pathName;

            if (path.Length > 100)
            {
                int length = path.Length;
                int length2;

                for (string j = path.ToString().Remove(100, length - 100); ; j = j.Substring(0, length2 - 1))
                {
                    path = new StringBuilder();

                    path.Append(j);

                    if (!path.ToString().EndsWith("/") && !path.ToString().EndsWith("."))
                    {
                        break;
                    }

                    length2 = path.Length;
                }
            }

            path.Append("/");

            string hashID;

            if (platorm.Equals("xbox360"))
            {
                initial = idOriginalResource;

                hashID = initial.Uri.ToLower();
            }
            else
            {
                DLCRoot.Uri = "";
                initial = idOriginalResource.ReplaceExtension(DLCRoot.Uri);

                hashID = initial.Uri.ToLower();
            }

            CallResetFunction();
            CallUpdateFunction(hashID, (uint)hashID.Length);

            TFixedArray bytes = CallFinalFunction();
            string fileName;

            if (platorm.Equals("xbox360"))
            {
                fileName = ZMD5Engine.ToString(bytes);
            }
            else if (platorm.Equals("ps3"))
            {
                string extension = idResource.GetExtension();

                DLCRoot.Uri = ZMD5Engine.ToString(bytes);
                initial.Uri = DLCRoot.Uri.ToLower();
                initial.Uri += ".";
                initial.Uri += extension;

                fileName = initial.Uri;
            }
            else
            {
                string extension = idResource.GetExtension();

                initial.Uri = extension;

                fileName = ZMD5Engine.ToString(bytes);
                fileName += ".";
                fileName += extension;
            }

            initial.Uri = ".ps3_securelib";

            if (!fileName.EndsWith(initial.Uri))
            {
                string result2 = ProjectPath + RuntimePath;

                result2 += path.ToString();
                result = result2 + fileName;
            }

            return result;
        }

        public string GetResourceFileName(ZResourceID resourceID)
        {
            return CalcResourceFileName(resourceID);
        }
    }
}
