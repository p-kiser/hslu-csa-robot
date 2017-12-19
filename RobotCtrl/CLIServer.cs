using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;

namespace RobotCtrl
{
    public class CLIServer
    {
        public readonly static int PORT = 8080;

        TcpListener listener;
        Command cmd;
        IPAddress ipAddress;
        Monitor monitor;

        public CLIServer(Command cmd, Monitor monitor)
        {
            listener = new TcpListener(
                IPAddress.Any, 
                PORT
            );
            this.cmd = cmd;
            this.monitor = monitor;
            listener.Start();
        }

        public void listen(bool loop = true)
        {
            TcpClient client;
            Console.WriteLine("Warte auf Verbindung auf Port " + listener.LocalEndpoint + "...");
            bool wait = true;
            while (wait && (client = listener.AcceptTcpClient()) != null)
            {
                wait = loop;
                try
                {
                    string line;
                    StreamReader reader = new StreamReader(client.GetStream());
                    StreamWriter writer = new StreamWriter(client.GetStream());
                    writer.WriteLine("Successfully Connected");
                    writer.Flush();
                    while ((line = reader.ReadLine()) != String.Empty)
                    {
                        switch (line)
                        {
                            case "help":
                                writer.WriteLine(cmd.getHelp());
                                writer.WriteLine("EOS");
                                writer.Flush();
                                break;
                            case "start":
                                monitor.start(cmd);
                                cmd.executeQueue();
                                monitor.stop();
                                break;
                            case "dump":
                                writer.WriteLine(monitor.dump());
                                writer.WriteLine("EOS");
                                writer.Flush();
                                break;
                            default:
                                cmd.addQueue(line);
                                break;
                        }
                    }
                } catch(Exception ex)
                {
                    Console.WriteLine("Connection probably closed");
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
