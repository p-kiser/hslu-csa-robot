using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotCtrl
{
    interface Monitor
    {
        void start(Command cmd);

        void stop();

        void clear();

        System.IO.StreamReader dump();
    }
}
