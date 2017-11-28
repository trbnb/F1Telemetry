using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Utils
{
    public static class StructHelpers
    {
        public static T ConvertToPacket<T>(this byte[] bytes)
            where T : struct
        {
            var handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            var stuff = ConvertToPacket<T>(handle.AddrOfPinnedObject());
            handle.Free();
            return stuff;
        }

        public static T ConvertToPacket<T>(IntPtr ptr)
            where T : struct
        {
            return Marshal.PtrToStructure<T>(ptr);
        }
    }
}
