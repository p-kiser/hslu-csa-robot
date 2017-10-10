using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public class MockMe
    {
        private string message;
        public string Message
        {
            get
            {
                return message == "" ? message : "Hello World";
            }
            set
            {
                message = value;
            }
        }
    }
}
