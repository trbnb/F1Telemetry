using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UdpTestApp.UDP;

namespace UdpTestApp
{
    class Program
    {
        const string TEST_DATA = "7D-5D-71-43-6D-75-75-42-08-74-19-45-50-90-2C-46-01-3F-B1-C3-1B-70-1A-42-02-29-7F-42-EF-6F-F5-3B-07-65-AF-3B-D2-6B-A1-3B-BE-E6-E9-3A-71-3C-4A-3F-80-3D-C3-38-D7-F5-1C-3F-13-E4-1C-3F-EA-8F-F4-BC-41-25-4A-BF-5C-C5-16-BF-C0-E1-02-3F-07-E1-2F-3F-EB-9D-75-BE-5A-52-28-BE-62-F9-AA-BE-7F-D2-B0-3F-23-B4-A7-3F-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-00-8B-23-18-3E-00-00-00-00-00-00-00-00-00-00-80-3F-BF-8C-7B-BC-34-6C-6A-3B-00-00-00-40-24-72-6E-45-00-00-00-00-00-00-A0-41-00-50-C3-48-00-50-C3-48-00-00-00-00-00-00-00-00-00-00-00-00-B4-F3-CC-41-00-00-D2-42-00-00-00-00-00-00-80-3F-60-17-95-41-00-00-00-00-C7-AB-C0-43-77-4A-C1-43-81-89-A2-43-63-18-A4-43-00-00-AC-41-00-00-AC-41-00-00-B8-41-00-00-B8-41-00-00-00-00-00-00-90-41-4E-33-86-45-00-84-94-42-00-F0-52-46-FF-7F-6D-45-00-00-10-41-00-00-40-40-00-00-00-00-00-00-80-41-00-00-40-40-00-20-FC-44-A0-92-CC-42-60-65-89-BB-48-61-48-3B-C2-FD-03-BA-CE-70-07-3C-4E-4A-50-4B-09-0A-09-08-01-35-01-00-09-0A-09-08-00-00-00-01-01-00-00-31-99-22-DA-45-00-00-FF-14-0F-58-9E-00-C3-CA-12-F3-41-F8-AF-76-C3-9A-95-95-42-59-DB-74-42-9A-95-95-42-90-27-96-41-DC-60-24-42-60-19-47-45-22-02-11-03-01-00-02-00-00-D4-B0-0B-C4-9C-19-68-42-D6-63-59-42-73-50-91-42-E9-68-89-42-73-50-91-42-E8-8B-90-41-D8-35-14-42-DC-5F-76-45-10-00-05-03-01-00-02-00-00-3B-40-08-C4-E2-9A-5E-42-0F-3D-6E-43-2A-25-90-42-51-50-8C-42-2A-25-90-42-F8-AD-8E-41-40-8D-12-42-E0-06-81-45-00-01-04-03-02-00-02-00-00-61-B8-01-C4-AC-77-64-42-1F-8C-AB-43-2E-CF-8F-42-59-26-8F-42-2E-CF-8F-42-30-F2-8E-41-FC-E3-12-42-D8-67-84-45-06-01-02-03-02-00-02-00-00-03-B8-EE-C3-74-EB-6B-42-69-7A-67-C3-45-37-93-42-D3-F7-82-42-45-37-93-42-60-D0-90-41-AC-53-16-42-18-90-63-45-07-0B-0A-03-01-00-02-00-00-83-B3-20-C3-77-BC-E3-41-82-48-41-C3-0E-6A-96-42-EE-C8-6D-42-0E-6A-96-42-58-B0-92-41-D4-D6-23-42-88-2D-43-45-12-05-13-03-01-00-02-00-00-1C-47-05-C4-C3-DC-6E-42-FB-38-AF-C2-9C-58-92-42-05-9C-86-42-9C-58-92-42-50-39-8F-41-F8-CD-16-42-28-5E-6D-45-05-06-07-03-01-00-02-00-00-A5-D1-F3-C2-8C-BC-F6-41-A9-E8-8B-C3-E9-48-95-42-8C-B9-76-42-E9-48-95-42-10-4B-96-41-E0-E8-21-42-D8-45-49-45-02-02-0F-03-01-00-02-00-00-28-25-8A-C3-1B-92-2A-42-41-57-A9-C3-ED-FB-94-42-5C-BA-7A-42-ED-FB-94-42-00-AF-90-41-C4-C8-18-42-8C-D0-54-45-23-07-0E-03-01-00-02-00-00-15-4E-F3-C2-98-50-F6-41-0E-39-87-C3-AE-48-95-42-B0-B8-73-42-AE-48-95-42-B0-48-94-41-18-C7-20-42-60-A5-48-45-03-07-10-03-01-00-02-00-00-A4-CC-B8-C3-E1-EA-4E-42-B0-47-9C-C3-2C-62-94-42-EB-2A-80-42-2C-62-94-42-D8-AF-90-41-B4-63-18-42-D0-E5-5A-45-0E-0B-0B-03-01-00-02-00-00-66-54-AF-C3-9B-37-48-42-01-1B-A0-C3-B1-48-94-42-95-55-7F-42-B1-48-94-42-C8-16-91-41-14-41-18-42-EC-9E-59-45-01-08-0C-03-01-00-02-00-00-39-F6-06-C4-B4-46-6D-42-58-C1-71-C2-20-73-92-42-85-2C-87-42-20-73-92-42-30-C0-8F-41-C8-EF-15-42-54-1F-6F-45-0A-03-06-03-01-00-02-00-00-0A-03-9B-C3-42-32-38-42-E2-4C-A6-C3-0D-AF-94-42-24-AA-7C-42-0D-AF-94-42-F8-38-91-41-54-51-18-42-E0-F5-56-45-14-03-0D-03-01-00-02-00-00-F7-54-F8-C3-F6-24-70-42-E8-3F-49-C3-F6-3F-93-42-97-91-83-42-F6-3F-93-42-88-12-8F-41-78-BB-16-42-20-E0-65-45-21-06-09-03-01-00-02-00-00-01-3F-B1-C3-1B-70-1A-42-02-29-7F-42-00-84-94-42-6D-75-75-42-00-84-94-42-60-17-95-41-00-00-00-00-08-74-19-45-16-00-14-03-01-00-01-00-00-A4-1C-EA-C3-D0-82-79-42-00-7F-08-44-CE-95-8F-42-2C-30-E2-3F-EB-93-8E-42-00-00-00-00-00-00-00-00-C0-E0-17-43-09-04-01-04-01-00-00-00-00-10-DF-01-C4-65-AC-71-42-3E-38-10-C3-79-B6-92-42-79-DF-84-42-79-B6-92-42-68-6C-90-41-10-77-15-42-08-BD-69-45-17-08-08-03-01-00-02-00-00-B2-D4-03-C4-55-6D-61-42-03-9A-9C-43-DF-79-8F-42-03-B7-8D-42-DF-79-8F-42-C8-E0-8D-41-B0-49-13-42-CA-6E-83-45-0F-04-03-03-01-00-02-00-00-78-77-13-C3-2A-EC-E9-41-CB-13-57-C3-B7-95-96-42-B2-95-6E-42-B7-95-96-42-08-27-92-41-C0-4E-23-42-20-C9-44-45-1F-05-12-03-01-00-02-00-00-BA-D5-1E-40-C0-5A-95-3C-82-3D-C3-B8-49-6D-AE-BB-14-2A-A3-3B-82-FE-E1-3A-CD-9D-7F-41-F6-D9-50-C2-E8-01-B0-C2-05-FE-E1-C2-A8-BC-7D-3E-10-84-10-BC-51-B3-F7-3D";
        const bool USE_TESTDATA = true;

        [STAThread]
        static void Main(string[] args)
        {
            if(USE_TESTDATA)
            {
                var bytes = TEST_DATA.Split('-').Select(ch => Convert.ToByte(ch, 16)).ToArray();
                var data = ConvertToPacket<UDPPacket>(bytes);

                data.CarData = data.CarData.Where((carData, index) => index == data.PlayerCarIndex).ToArray();
                
                var jsonResult = JsonConvert.SerializeObject(data, Formatting.Indented);
                Console.WriteLine(jsonResult);
                Clipboard.SetText(jsonResult);
            } else
            {
                var client = new UdpClient(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 20777));
                Task.Factory.StartNew(() => Listen(client));
            }
            
            Console.ReadLine();
        }
        
        public static T ConvertToPacket<T>(byte[] bytes)
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
            return (T)Marshal.PtrToStructure(ptr, typeof(T));
        }

        async static void Listen(UdpClient client)
        {
            while (true)
            {
                Console.WriteLine("-----------------------");
                try
                {
                    var result = await client.ReceiveAsync();
                    var bytes = result.Buffer;
                    var item = ConvertToPacket<UDPPacket>(bytes);
                    Console.WriteLine(JsonConvert.SerializeObject(item, Formatting.Indented));
                }
                catch
                {
                    Console.WriteLine("ERROR!");
                }
            }
        }
    }
}
