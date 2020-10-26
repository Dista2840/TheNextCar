using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheNextCar.Model;

namespace TheNextCar.Controller
{
    class AccubattreyController
    {
        private Accubattrey accubattrey;
        private OnPowerChanged callbackOnPowerChanged;

        public AccubattreyController(OnPowerChanged callbackOnPowerChanged)
        {
            this.callbackOnPowerChanged = callbackOnPowerChanged;
            this.accubattrey = new Accubattrey(12);
        }

        public void turnOn()
        {
            this.accubattrey.turnOn();
            this.callbackOnPowerChanged.onPowerChangedStatus("ON", "power is on");
        
        }

        public void turnOff()
        {
            this.accubattrey.turnOff();
            this.callbackOnPowerChanged.onPowerChangedStatus("OFF", "power is off");

        }

        public bool accubattreyIsOn()
        {
            return this.accubattrey.isOn();

        }


       
    }
    interface OnPowerChanged
    {
        void onPowerChangedStatus(string value, string message);
    }
}
