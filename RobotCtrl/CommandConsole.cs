using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace RobotCtrl
{
    public class CommandConsole : Command
    {
        private Robot robot;
        private List<string> tracks = new List<string>();
        private static Dictionary<String, int> AVAILABLE_TRACKS =
        new Dictionary<string, int>() {
            { "RunLine", 1 },
            { "RunTurn", 1 },
            { "RunArcLeft", 2 },
            { "RunArcRight", 2 }
        };

        private float DEFAULT_ACCELERATION = 0.5f;
        private float DEFAULT_SPEED = 0.8f;

        public CommandConsole()
        {
            init();
        }

        private void init()
        {
            robot = new Robot();
            robot.Drive.Power = true;
        }

        public void print()
        {
            AVAILABLE_TRACKS.ToList().ForEach(v =>
           {
               Console.WriteLine("CMD: " + v.Key + " PARS: " + v.Value);
           });
        }

        public void addQueue(string track)
        {
            tracks.Add(track);
        }

        public void clearQueue()
        {
            robot.Drive.Halt();
            tracks.Clear();
        }
 
        public bool execute(List<String> track)
        {
            List<Object> pars = new List<object>();

            int parsize = 0;
            string method = track[0];
            if (track.Count <= 0 || !AVAILABLE_TRACKS.TryGetValue(method, out parsize))
            {
                return false;
            }

            if(track.Count < parsize + 1)
            {
                return false;
            }
            
            for(int i = 1; i < parsize + 1; i++)
            {
                pars.Add(float.Parse(track[i]));
            }

            pars.Add(DEFAULT_SPEED);
            pars.Add(DEFAULT_ACCELERATION);

            try
            {
                Type DriveType = robot.Drive.GetType();
                MethodInfo trackMethod = DriveType.GetMethod(method);
                trackMethod.Invoke(robot.Drive, pars.ToArray());
                return true;
            } catch(Exception ex) {
                pars.ForEach(v => Console.Write("'" + v.ToString() + "',"));
                Console.WriteLine(string.Join(":", track.ToArray()) + ":" + ex.Message);
                Console.WriteLine(ex.ToString());
            }

            return false;
        }

        public void executeQueue()
        {
            tracks.ForEach(t =>
            {
                execute(t.Split(' ').ToList());
                // blocking wait
                while(!robot.Drive.Done) { }
            });
            clearQueue();
        }

        public PositionInfo getPosition()
        {
            return robot.Position;
        }
    }
}
