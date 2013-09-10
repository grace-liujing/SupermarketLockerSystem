using System;
using System.Collections.Generic;

namespace SupermarketLockerSystem
{
    public class Locker
    {
        private readonly Dictionary<Ticket, Bag> storedBagMap = new Dictionary<Ticket, Bag>();
        public int Capacity { get; private set; }

        public Locker(int boxCount)
        {
            Capacity = boxCount;
        }

        public int AvailableCount
        {
            get { return Capacity - storedBagMap.Count; }
        }

        public bool IsAvailable()
        {
            return storedBagMap.Count < Capacity;
        }

        public Ticket Store(Bag bag)
        {
            if (!IsAvailable())
            {
                throw new InvalidOperationException();
            }
            var ticket = new Ticket();
            storedBagMap[ticket] = bag;
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
            storedBagMap.Remove(ticket);
            return bag;
        }

        public double VacancyRate()
        {
            return (double)(AvailableCount)/Capacity;
        }
    }
}