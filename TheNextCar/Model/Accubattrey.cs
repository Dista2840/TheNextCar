﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheNextCar.Model
{
    class Accubattrey
    {
        private int voltage;
        private bool stateOn = false;

        public Accubattrey(int voltage)
        {
            this.voltage = voltage;
        }

        public void turnOn()
        {
            this.stateOn = true;
        }

        public void turnOff()

        {
            this.stateOn = false;
        }

        public bool isOn()
        {
            return this.stateOn;
        }
    }
}
