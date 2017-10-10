using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class HelloWorld
    {
        private MockMe msg;

        public HelloWorld(MockMe msg)
        {
            this.msg = msg;
        }

        public String run()
        {
            return msg.Message;
        }
    }
}
