using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
           
            IPEndPoint ips = new IPEndPoint(IPAddress.Any, 1234);
            UdpClient server = new UdpClient(ips);
            IPEndPoint ipc = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                try
                {
                    byte[] a = server.Receive(ref ipc);
                    int x = BitConverter.ToInt32(a, 0);
                    byte[] b = server.Receive(ref ipc);
                    int y = BitConverter.ToInt32(b, 0);

                    int tong = x + y;

                    byte[] result = BitConverter.GetBytes(tong);
                    server.Send(result, result.Length, ipc);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    break;
                }
            }
            server.Close();
        }
    }
}
