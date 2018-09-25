using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace TCP_Client
{
    class Client
    {
        private static TcpClient _clientSocket = null;
        private static Stream _nstream = null;
        private static StreamWriter _sWriter = null;
        private static StreamReader _sReader = null;
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    using (_clientSocket = new TcpClient("127.0.0.1", 7777))
                    {
                        using (_nstream = _clientSocket.GetStream())
                        {
                            while (true)
                            {
                                _sWriter = new StreamWriter(_nstream) { AutoFlush = true };
                                Console.Write("> ");
                                string clientMsg = Console.ReadLine();
                                _sWriter.WriteLine(clientMsg);

                                _sReader = new StreamReader(_nstream);
                                string rdMsgFromServer = _sReader.ReadLine();

                                if (rdMsgFromServer != null)
                                {
                                    Console.WriteLine("SERVER: " + rdMsgFromServer);

                                }
                                else
                                {
                                    Console.WriteLine("Lost connection");
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadKey();
            }
        }


    }
}
