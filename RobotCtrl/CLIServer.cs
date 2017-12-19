using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace RobotCtrl
{
    public class CLIServer
    {
        public readonly static int PORT = 8080;

        TcpListener listener;
        Command cmd;
        IPAddress ipAddress;
        public CLIServer(Command cmd)
        {
            listener = new TcpListener(
                IPAddress.Any, 
                PORT
            );
            this.cmd = cmd;
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
                            case "print":
                                writer.WriteLine(cmd.getHelp());
                                writer.Flush();
                                break;
                            case "start":
                                cmd.executeQueue();
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
