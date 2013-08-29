using System;
using System.Collections.Generic;

namespace SupermarketLockerSystem
{
    public class Locker
    {
        private readonly Dictionary<Ticket, Bag> storedBagMap;
        public int Capacity { get; set; }
        private int AvailableCount { get; set; }

        public Locker(int boxCount)
        {
            storedBagMap = new Dictionary<Ticket, Bag>();
            Capacity = boxCount;
            AvailableCount = boxCount;
        }

        public bool IsAvailable()
        {
            return AvailableCount > 0;
        }
        public Ticket Store(Bag bag)
        {
            if (!IsAvailable())
            {
                throw new InvalidOperationException();
            }
            var ticket = new Ticket();
            storedBagMap[ticket] = bag;
            AvailableCount--;
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
            AvailableCount++;
            storedBagMap.Remove(ticket);
            return bag;
        }
    }
}