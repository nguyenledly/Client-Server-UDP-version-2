using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint ips = new IPEndPoint(IPAddress.Loopback, 1234);
            UdpClient client = new UdpClient();
            client.Connect(ips);
            while (true)
            {
                try
                {
                    Console.Write("Nhap x: ");
                    int x = int.Parse(Console.ReadLine());
                    Console.Write("Nhap y: ");
                    int y = int.Parse(Console.ReadLine());
                    byte[] a = BitConverter.GetBytes(x);
                    byte[] b = BitConverter.GetBytes(y);
                    client.Send(a, a.Length);
                    client.Send(b, b.Length);

                    Console.Write("Tong x + y: ");
                    byte[] result = client.Receive(ref ips);
                    int tong = BitConverter.ToInt32(result, 0);
                    Console.WriteLine(tong);
                    Console.WriteLine("Bam 0: Tiep tuc nhap ---- Bam 1: Thoat");
                    int i = int.Parse(Console.ReadLine());
                    if (i == 0)
                        continue;
                    else
                        break;
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }
            client.Close();
        }
    }
}
