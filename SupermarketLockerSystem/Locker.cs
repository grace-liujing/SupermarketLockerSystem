using System;
using System.Collections.Generic;

namespace SupermarketLockerSystem
{
    public class Locker
    {
        private Dictionary<Ticket, Bag> storedBagMap; 
        public bool IsEmpty { get; private set;}
        private int Capacity { get; set; }

        public Locker(int boxCount)
        {
            Capacity = boxCount;
            IsEmpty = true;
        }

        public Ticket Store(Bag bag)
        {
            var ticket = new Ticket();
            IsEmpty = false;
            return ticket;
        }

        public Bag Pick(Ticket ticket)
        {
            if (ticket == null) throw new ArgumentNullException();
            
            Bag bag = storedBagMap[ticket];
            if (bag!=null)
            {
                IsEmpty = true;
                storedBagMap.Remove(ticket);
                return bag;
            }

            throw new InvalidOperationException();
        }
    }
}