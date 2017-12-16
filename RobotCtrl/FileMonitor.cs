using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace RobotCtrl
{
    public class FileMonitor : Monitor, IDisposable
    {
        private Command cmd;
        private string path;
        private static bool isRunning = false;
        private static volatile bool shouldExit = false;

        private static FileMonitor monitor;
        private static int MS_WAIT = 200;

        Thread thread;
        

        public FileMonitor(string path) {
            this.path = path;
            monitor = this;
        }

        public FileMonitor() : this("tmp\\FileName")
        {
        }

        private FileStream createFileStream()
        {
            return new FileStream(path, FileMode.OpenOrCreate);
        }

        private void writeLine(string line)
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(createFileStream(), Encoding.ASCII);
                writer.BaseStream.Seek(0, SeekOrigin.End);
                writer.WriteLine(line);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } finally
            {
                if(writer != null)
                {
                    writer.Close();
                }
            }
        }

        public void clear()
        {
            File.Delete(path);
            writeLine("Team xy");
        }

        public string dump()
        {
            String text = "";
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(createFileStream());
                text = reader.ReadToEnd();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            } finally
            {
                if (reader != null)
                    reader.Close();
            }
            return text;
        }

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
            if(isRunning)
            {
                shouldExit = true;
                thread.Join();
            }
        }

        public void Dispose()
        {
            stop();
        }

        public string getLine()
        {
            PositionInfo pos = cmd.getPosition();
            return DateTime.Now.ToString("dd/MM/yyyy-hh:mm:ss.fff") + ";" + pos.X + ";" + pos.Y;
        }

        private static void run()
        {
            while(!shouldExit)
            {
                Thread.Sleep(MS_WAIT);
                monitor.writeLine(monitor.getLine());
            }
        }
    }
}
