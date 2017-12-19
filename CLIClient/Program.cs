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
                // clear any reads
                Console.WriteLine(cmd);
            }
        }
    }
}
