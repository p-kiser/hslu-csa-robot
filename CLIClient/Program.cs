using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace CLIClient
{
    class Program
    {
        static void Main(string[] args)
        {
            string cmd;
            while ((cmd = Console.ReadLine()) != "exit")
            {

                Thread.Sleep(4000);

                // clear any reads
                Console.WriteLine(cmd);
            }
        }
    }
}
