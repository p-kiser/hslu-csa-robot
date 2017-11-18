using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using RobotCtrl;

namespace RobotView
{
    public partial class ConsoleView : UserControl
    {
        private Led[] leds = new Led[4];
        private Switch[] switches = new Switch[4];

        public RobotConsole robotConsole
        {
            set
            {
                // setup leds / switches
                ledView1.LedCtrl = value[Leds.Led1];
                ledView2.LedCtrl = value[Leds.Led2];
                ledView3.LedCtrl = value[Leds.Led3];
                ledView4.LedCtrl = value[Leds.Led4];

                switchView1.SwitchCtrl = value[Switches.Switch1];
                switchView2.SwitchCtrl = value[Switches.Switch2];
                switchView3.SwitchCtrl = value[Switches.Switch3];
                switchView4.SwitchCtrl = value[Switches.Switch4];

                appendAction(value[Switches.Switch1], value[Leds.Led1]);
                appendAction(value[Switches.Switch2], value[Leds.Led2]);
                appendAction(value[Switches.Switch3], value[Leds.Led3]);
                appendAction(value[Switches.Switch4], value[Leds.Led4]);
            }
        }

        public ConsoleView()
        {
            InitializeComponent();            
        }

        private void appendAction(Switch swi, Led led)
        {
            swi.SwitchStateChanged += (object sender, SwitchEventArgs e) =>
            {
                led.LedEnabled = swi.SwitchEnabled;
            };
        }
    }
}