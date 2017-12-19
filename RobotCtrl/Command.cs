using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotCtrl
{
    public interface Command
    {
        bool execute(List<String> track);

        void executeQueue();

        void stop();

        void addQueue(string track);

        void clearQueue();
    
        string getHelp();

        PositionInfo getPosition();
    }
}
