using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotCtrl
{
    public interface Monitor
    {
        void start(Command cmd);

        void stop();

        void clear();

        string dump();
    }
}
