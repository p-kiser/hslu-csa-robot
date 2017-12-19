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
        private static FileMonitor monitor;

        Thread thread;
        public IterativerServer()
        {
            monitor = new FileMonitor();
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
                while (true)
                {
                    Console.WriteLine("Warte auf Verbindung auf Port " +
                    listen.LocalEndpoint + "...");
                    TcpClient client = listen.AcceptTcpClient();
                    Console.WriteLine("Verbindung zu " +
                    client.Client.RemoteEndPoint);
                    StreamWriter sw = new StreamWriter(client.GetStream(), Encoding.ASCII);
                    sw.WriteLine(monitor.dump());
                    sw.Flush();
                    client.Close();
                }
            }
        }
    }
}

