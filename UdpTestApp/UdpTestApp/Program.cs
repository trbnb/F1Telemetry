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

namespace UdpTestApp
{
    class Program
    {
        private const int Packages = 100;

        public static void Main(string[] args)
        {
            var client = new UdpClient(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 20777));
            Task.Factory.StartNew(() => WaitForPackages(client));

            Console.ReadLine();
        }

        private static async void WaitForPackages(UdpClient client)
        {
            var packageStore = new List<byte[]>(Packages);

            for(var i = 0; i < Packages; i++)
            {
                var result = await client.ReceiveAsync();
                packageStore.Add(result.Buffer);
            }

            var strings = packageStore.Select(e => BitConverter.ToString(e));
            File.WriteAllLines(@"%userprofile%/desktop/testdata.txt", strings);
        }
    }
}
