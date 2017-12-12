//------------------------------------------------------------------------------
// C #   I N   A C T I O N   ( C S A )
//------------------------------------------------------------------------------
// Repository:
//    $Id: Robot.cs 1039 2016-10-25 11:56:45Z chj-hslu $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RobotCtrl
{
    public class Robot: IDisposable
    {
        
        #region members
        private RobotConsole robotConsole;
        private Radar radar;
        private Drive drive;

        private int blinkTicks;
        #endregion


        #region constructor & destructor
        public Robot()
        {
            this.robotConsole = new RobotConsole();
            this.radar = new Radar(Constants.IORadarSensor);
            this.drive = new Drive();
            this.drive.Radar = this.radar;

            drive.DistanceToShort += Drive_DistanceToShort;
        }

        private void Drive_DistanceToShort(object sender, EventArgs e)
        {
            this.Blink();
        }

        /// <summary>
        /// Disposed das Drive-Objekt sowie die robotConsole.
        /// Damit werden die Worker-Threads in diesen Objekten beendet
        /// </summary>
        public void Dispose()
        {
            this.drive.Dispose();
            this.robotConsole.Dispose();
        }
        #endregion


        #region properties
        /// <summary>
        /// Liefert die Konsole des Roboters
        /// </summary>
        public RobotConsole RobotConsole
        {
            get { return this.robotConsole; }
        }


        /// <summary>
        /// Liefert den Radar des Roboters
        /// </summary>
        public Radar Radar
        {
            get { return this.radar; }
        }


        /// <summary>
        /// Liefert den Antrieb des Roboters
        /// </summary>
        public Drive Drive
        {
            get { return this.drive; }
        }


        /// <summary>
        /// Liefert bzw. setzt die aktuelle Postion des Roboters.
        /// </summary>
        public PositionInfo Position { get { return drive.Position; } set { drive.Position = value; } }
        #endregion


        public void Blink()
        {
            int newTicks = Environment.TickCount / Constants.blinkCadence;

            if (newTicks > blinkTicks)
            {
                ToggleTheLights();
                blinkTicks = newTicks;
            }
        }

        private void ToggleTheLights()
        {
            bool enabled = robotConsole[Leds.Led1].LedEnabled;
            TurnOnTheLights(!enabled);
        }

        private void TurnOnTheLights(bool turnOn)
        {
            for (int i = 0; i <= 3; i++)
            {
                robotConsole[(Leds)i].LedEnabled = turnOn;
            }
        }
    }
}
