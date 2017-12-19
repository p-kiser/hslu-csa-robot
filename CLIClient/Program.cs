using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace CLIClient
{
    class Program
    {
        static volatile TcpClient client = new TcpClient();
        static Thread thread;
           
        static void Main(string[] args)
        {
            bool isConnected = false;
            string msg;
            string[] exec;

            string cmd;
            while ((cmd = Console.ReadLine()) != "exit")
            {
                exec = cmd.Split(' ');
                msg = "";
                
                if (exec.Count() < 1 || (!client.Connected && exec[0] != "connect"))
                {
                    msg += "please connect first: connect [ip4address] [port]\n";
                } else
                {
                    switch(exec[0])
                    {
                        case "connect":
                            IPAddress address;
                            int port;
                            if(exec.Count() != 3)
                            {
                                msg += "use conncet as : connect [ip4address] [port]\n";
                                break;
                            }
                            if(!IPAddress.TryParse(exec[1], out address))
                            {
                                msg += "IP address parse error\n";
                                break;
                            }
                            if(!Int32.TryParse(exec[2], out port))
                            {
                                msg += "Port parse error\n";
                            }
                            try
                            {
                                client = new TcpClient(address.ToString(), port);
                            }
                            catch (Exception ex)
                            {
                                msg += "Connection to " + address.ToString() + ":" + port + " failed\n";
                                msg += ex.Message + "\n";
                            }
                            break;
                        case "disconnect":
                            msg += "disconnecting\n";
                            if(client.Connected)
                            {
                                client.Close();
                            }
                            break;
                        default:
                            StreamWriter netStream = new StreamWriter(client.GetStream());
                            netStream.WriteLine(String.Join(" ",exec));
                            netStream.Flush();
                            break;
                    }

                    if (client.Connected)
                    {
                        StreamReader netStream = new StreamReader(client.GetStream());
                        switch (exec[0])
                        {
                            case "connect":
                                Console.WriteLine(netStream.ReadLine());
                                break;
                            case "help":
                            case "dump":
                                string line = "";
                                while((line = netStream.ReadLine()) != "EOS")
                                {
                                    Console.WriteLine(line);
                                }
                                break;
                        }
                    }
                }
                Console.WriteLine(msg);
            }
        }
    }
}
