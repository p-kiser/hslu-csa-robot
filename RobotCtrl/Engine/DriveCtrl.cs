//------------------------------------------------------------------------------
// C #   I N   A C T I O N   ( C S A )
//------------------------------------------------------------------------------
// Repository:
//    $Id: MotorCtrl.cs 973 2015-11-10 13:12:03Z zajost $
//------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RobotCtrl
{

    public class DriveCtrl : IDisposable
    {
        #region motor power constants
        public const int PowerMotorRight = 0x01;
        public const int PowerMotorLeft = 0x02;
        public const int PowerMotorReset = 0x80;
        public const int PowerMotorOff = 0x00;
        #endregion

        #region members
        private int ioAddress;
        private readonly object syncIODriveCtrl = new object();
        #endregion


        #region constructor & destructor
        public DriveCtrl(int IOAddress)
        {
            this.ioAddress = IOAddress;
            Reset();
        }

        public void Dispose()
        {
            Reset();
        }
        #endregion


        #region properties
        /// <summary>
        /// Schaltet die Stromversorgung der beiden Motoren ein oder aus.
        /// </summary>
        public bool Power
        {
            set { DriveState = (value) ? DriveState | (PowerMotorRight + PowerMotorLeft) : DriveState & ~(PowerMotorRight + PowerMotorLeft); }
        }


        /// <summary>
        /// Liefert den Status ob der rechte Motor ein-/ausgeschaltet ist bzw. schaltet den rechten Motor ein-/aus.
        /// Die Information dazu steht im Bit0 von DriveState.
        /// </summary>
        public bool PowerRight
        {
            get { return (DriveState & PowerMotorRight) == PowerMotorRight; } // ToD
            set { DriveState = (value) ? DriveState | PowerMotorRight : DriveState & ~PowerMotorRight; }
        }


        /// <summary>
        /// Liefert den Status ob der linke Motor ein-/ausgeschaltet ist bzw. schaltet den linken Motor ein-/aus.
        /// </summary>
        public bool PowerLeft
        {
            get { return (DriveState & PowerMotorLeft) == PowerMotorLeft; }
            set { DriveState = (value) ? DriveState | PowerMotorLeft : DriveState & ~PowerMotorLeft; }
        }


        /// <summary>
        /// Bietet Zugriff auf das Status-/Controlregister
        /// </summary>
        public int DriveState
        {
            get {
                int val;
                lock(syncIODriveCtrl)
                {
                    val = IOPort.Read(Constants.IODriveCtrl);
                }
                return val;
            }
            set {
                lock(syncIODriveCtrl)
                {
                    IOPort.Write(Constants.IODriveCtrl, value);
                }
            }
        }
        #endregion

        
        #region methods
        /// <summary>
        /// Setzt die beiden Motorencontroller (LM629) zurück, 
        /// indem kurz die Reset-Leitung aktiviert wird.
        /// </summary>
        public void Reset()
        {
            DriveState = PowerMotorOff;
            Thread.Sleep(5);
            DriveState = PowerMotorReset;
            Thread.Sleep(5);
            DriveState = PowerMotorOff;
            Thread.Sleep(5);
        }
        #endregion

    }
}
