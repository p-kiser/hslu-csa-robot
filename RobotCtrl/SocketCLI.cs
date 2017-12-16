using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net.Sockets;
using System.Net;

namespace RobotCtrl
{
    class SocketCLI
    {
        private Command command;
        private IPAddress address;
        private TcpListener listern;

        SocketCLI(Command command)
        {
            this.command = command;
        }
        
        /// <summary>
        /// Starts the server and listens for connections
        /// </summary>
        public void start(string dns, int Port)
        {
            address = Dns.GetHostEntry(dns).AddressList[0];
        }

        public void stop()
        {

        }

        /// <summary>
        /// Interpretes one line of command
        /// </summary>
        /// <param name="line">one line, which is ended</param>
        private void interprete(string line)
        {

        }        
    }
}
