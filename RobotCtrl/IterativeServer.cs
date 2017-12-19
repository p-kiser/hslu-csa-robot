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
    class IterativerServer
    {
        private static bool isRunning = false;
        private static volatile bool shouldExit = false;
        private Command cmd;
        private static int MS_WAIT = 200;

        Thread thread;
        public void start(Command cmd)
        {
            this.cmd = cmd;
            if (!isRunning)
            {
                shouldExit = false;
                isRunning = true;
                clear();
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
                Thread.Sleep(MS_WAIT);
                //monitor.writeLine(monitor.getLine());
            }
        }

        public void clear()
        {
            //NOP
        }

        public static void Main()
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

                writeHeader(sw);
                sw.WriteLine("Hello World!");

                sw.Flush();
                client.Close();
            }
        }

        private static void writeHeader(StreamWriter sw) 
        {
            sw.WriteLine("HTTP/1.1 200 OK");
            sw.WriteLine("Content-Type: text/csv");
            sw.WriteLine("");
        }


    }
}

/*
Example header:

HTTP/1.1 200 OK
Date: Tue, 19 Dec 2017 13:46:47 GMT
Server: Apache/2.2.29 (Unix) mod_ssl/2.2.29 OpenSSL/1.0.1e-fips mod_bwlimited/1.4
Last-Modified: Fri, 17 Jun 2016 18:16:55 GMT
ETag: "341707-44a-5357d5c0b93c0"
Accept-Ranges: bytes
Content-Length: 1098
Content-Type: text/csv

 */
