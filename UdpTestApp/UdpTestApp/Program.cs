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
using Utils;

namespace UdpTestApp
{
    class Program
    {
        private const int PackageSize = 1289;
        private const int Packages = 3000;

        public static void Main(string[] args)
        {
            var client = new UdpClient(new IPEndPoint(IPAddress.Any, 20777));
            Task.Factory.StartNew(() => WaitForPackages(client));

            Console.ReadLine();
        }

        private static async void WaitForPackages(UdpClient client)
        {
            var packageStore = new List<byte[]>(Packages);

            for (var i = 0; i < Packages; i++)
            {
                var result = await client.ReceiveAsync();
                packageStore.Add(result.Buffer);
                Console.WriteLine($"Value Nr. {i + 1}");
            }

            var path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/F1Telemetry/testdata1.txt";

            using (var writer = File.Create(path))
            {
                foreach (var byteArray in packageStore)
                {
                    writer.Write(byteArray, 0, byteArray.Length);
                }
            }

            PrintBytes(path);
        }

        private static void PrintBytes(string path)
        {
            var bytes = File.ReadAllBytes(path);
            
            var isValid = bytes.Length % PackageSize == 0;
            var dataSets = bytes.Split(PackageSize);

            Console.WriteLine($"Sets: {dataSets.Length}; isValid: {isValid}");
        }
    }
}
