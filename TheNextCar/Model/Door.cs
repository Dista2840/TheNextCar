﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheNextCar.Model
{
    class Door
    {
        private bool locked;
        private bool closed;

        public void close()
        {
            this.closed = true;
        }

        public void open()
        {
            this.locked = true;
        }

        public void activateLock()
        {
            this.locked = true;
        }

        public void unlock()
        {
            this.locked = false;
        }

        public bool isLocked()
        {
            return this.locked;
        }

        public bool isClosed()
        {
            return this.closed;
        }
    }
}
