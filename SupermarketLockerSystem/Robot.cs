using System;
using System.Collections.Generic;
using System.Linq;

namespace SupermarketLockerSystem
{
    public class Robot
    {
        protected static int LockerCount;
        protected readonly List<Locker> Lockers;

        public Robot(List<Locker> lockerList)
        {
            LockerCount = lockerList.Count;
            Lockers = lockerList;
        }

        public virtual Ticket Store(Bag bag)
        {
            var locker = Lockers.FirstOrDefault(l => l.IsAvailable());
            if (locker == null)
            {
                throw new InvalidOperationException();
            }
            var ticket = locker.Store(bag);
            return ticket;
        }

        public Bag Pick(Ticket ticket)
        {
            if(ticket == null) throw new ArgumentNullException();
            Bag bag = null;
            foreach (var locker in Lockers)
            {
                if (TryPick(locker, ticket, out bag)) break;
            }
            if(bag == null) throw new InvalidOperationException();
            return bag;
        }

        private bool TryPick(Locker locker, Ticket ticket, out Bag bag)
        {
            try
            {
                bag = locker.Pick(ticket);
                return true;
            }
            catch (InvalidOperationException)
            {
                bag = null;
                return false;
            }
        }
    }
}