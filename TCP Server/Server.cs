using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TcpServer
{
    class Program
    {
        private const int PORT = 7777;

        static void Main(string[] args)
        {
            IPAddress localAddress = IPAddress.Loopback;
            TcpListener serverSocket = new TcpListener(localAddress, PORT);
            serverSocket.Start();
            Console.WriteLine($"TCP server is running on port {PORT}");

            while (true) // server loop
            {
                try
                {
                    TcpClient client = serverSocket.AcceptTcpClient();
                    Console.WriteLine("Incoming client");
                    Task.Run(() => DoIt(client));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        public static void DoIt(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            StreamReader sReader = new StreamReader(stream);
            StreamWriter sWriter = new StreamWriter(stream);

            while (true)
            {
                string request = sReader.ReadLine();
                if (request == "exit")
                {
                    break;
                }
                //protocol TOGRAM
                if (request.Contains("TOGRAM"))
                {
                    try
                    {
                        Console.WriteLine("TOGRAMM Request");
                        string[] temp = request.Split(" ");
                        var numberToConvert = Convert.ToDouble(temp[1]);
                        double res = GrammToOunces.GrammToOuncesClass.OuncesToGramm(numberToConvert);
                        sWriter.WriteLine(res);
                        sWriter.Flush();
                        Console.WriteLine($"Result: " + res);
                        
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
                //protocol TOOUNCES
                else if (request.Contains("TOOUNCES"))
                {
                    try
                    {
                        Console.WriteLine("TOOUNCES Request");
                        string[] temp = request.Split(" ");
                        var numberToConvert = Convert.ToDouble(temp[1]);
                        double res = GrammToOunces.GrammToOuncesClass.GrammToOunces(numberToConvert);
                        sWriter.WriteLine(res);
                        sWriter.Flush();
                        Console.WriteLine($"Result: " + res);
                        
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
                else
                {
                    Console.WriteLine($"BadRequest: {request}");
                    sWriter.WriteLine($"BadRequest: {request}");
                    sWriter.Flush();
                }
            }

        }
    }
}



