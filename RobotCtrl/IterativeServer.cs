using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace RobotCtrl
{
    public class IterativerServer
    {
        private static bool isRunning = false;
        private static volatile bool shouldExit = false;
        private static Monitor monitor;

        Thread thread;
        public IterativerServer(Monitor mon)
        {
            monitor = mon;
            this.start();
        }

        public void start()
        {
            if (!isRunning)
            {
                shouldExit = false;
                isRunning = true;
                thread = new Thread(run);
                thread.Start();
            }
        }

        public void stop()
        {
            if (isRunning)
            {
                shouldExit = true;
                thread.Join();
            }
        }

        private static void run()
        {
            while (!shouldExit)
            {
                IPAddress ipAddress = IPAddress.Any;
                TcpListener listen = new TcpListener(ipAddress, 7070);
                listen.Start();
                Console.WriteLine("Warte auf Verbindung auf Port " +
                listen.LocalEndpoint + "...");
                TcpClient client;
                while ((client = listen.AcceptTcpClient()) != null)
                {
                    Console.WriteLine("Verbindung zu " +
                    client.Client.RemoteEndPoint);
                    StreamWriter sw = new StreamWriter(client.GetStream(), Encoding.ASCII);
                    string res = monitor.dump();
                    sw.WriteLine("HTTP/1.1 200 OK");
                    sw.WriteLine("Content-Length: " + res.LongCount());
                    sw.WriteLine("Content-Type: text/csv" + sw.NewLine);
                    sw.WriteLine(monitor.dump());

                    sw.Flush();
                    client.Close();
                }
            }
        }
    }
}

