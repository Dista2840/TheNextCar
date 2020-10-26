using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheNextCar.Controller
{
    class Car
    {
        private DoorController doorController;
        private AccubattreyController accubattreyController;
        private OnCarEngineStateChanged callback;

        public Car(DoorController doorController, AccubattreyController accubattreyController, OnCarEngineStateChanged callback)
        {
            this.doorController = doorController;
            this.accubattreyController = accubattreyController;
            this.callback = callback;
        }


        private bool doorIsClosed()
        {
            return this.doorController.isClose();
        }

        private bool doorIsLocked()
        {
            return this.doorController.isLocked();
        }

        private bool powerIsReady()
        {
            return this.accubattreyController.accubattreyIsOn();
        }

        public void startEngine()
        {
            if(!doorIsClosed())
            {
                this.callback.onCarEngineStateChanged("STOPED", "Close the door");
                return;
            }

            if(!doorIsLocked())
            {
                this.callback.onCarEngineStateChanged("STOPED", " Lock the door");
                return;
            }

            if(!powerIsReady())
            {
                this.callback.onCarEngineStateChanged("STOPED", "No power available");
                return;
               
            }
            this.callback.onCarEngineStateChanged("STARTED", "Engine Started");

        }

        public void toggleTheLockDoorButton()
        {
            if(!doorIsLocked())
            {
                this.doorController.activateLock();
            }

           else
            {
                this.doorController.unlock();
            }
            
        }

        public void toggleTheOpenDoorButton()
        {
            if (!doorIsClosed())
            {
                this.doorController.close();
            }

            else
            {
                this.doorController.open();
            }
        }

        public void togglePowerButton()
        {
            if(!powerIsReady())
            {
                this.accubattreyController.turnOn();
            }

            else
            {
                this.accubattreyController.turnOff();
            }
        }


    }
    interface OnCarEngineStateChanged
    {
        void onCarEngineStateChanged(string value, string message);
    }
}
