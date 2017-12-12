using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RobotCtrl
{
    interface Runnable
    {
        Start();

    }

    interface Command
    {
        void execute(Track track);

        void executeQueue();

        void addQueue(Track track);
        void clearQueue();

        PositionInfo getPosition();
    }
}
