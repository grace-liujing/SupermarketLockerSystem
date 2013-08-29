using System;
using System.Collections.Generic;

namespace SupermarketLockerSystem
{
    public class Locker
    {
        private Dictionary<Ticket, Bag> storedBagMap;
        public bool IsEmpty { get; private set; }
        public int Capacity { get; set; }
        public int AvailableCount { get; private set; }

        public Locker(int boxCount)
        {
            storedBagMap = new Dictionary<Ticket, Bag>();
            Capacity = boxCount;
            AvailableCount = boxCount;
            IsEmpty = true;
        }

        public Ticket Store(Bag bag)
        {
            if (AvailableCount == 0)
            {
                throw new InvalidOperationException();
            }
            var ticket = new Ticket();
            storedBagMap[ticket] = bag;
            AvailableCount--;
            IsEmpty = false;
            return ticket;
        }

        public Bag Pick(Ticket ticket)
        {
            if (ticket == null) throw new ArgumentNullException();

            if (!storedBagMap.ContainsKey(ticket))
            {
                throw new InvalidOperationException();
            }
            Bag bag = storedBagMap[ticket];
            IsEmpty = true;
            storedBagMap.Remove(ticket);
            return bag;
        }
    }
}