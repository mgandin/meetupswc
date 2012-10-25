using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SchedulerDotNet
{
    public class Event
    {
        private DateTime date;
        private int slot;

        public Event(DateTime date, int slot)
        {
            this.date = date;
            this.slot = slot;
        }

        public void Added()
        {

        }

        public DateTime GetDate()
        {
            return date;
        }

        public int GetSlot()
        {
            return slot;
        }

        public String ToString()
        {
            return date + " @" + slot + ":00 hours";
        }

    }
}
