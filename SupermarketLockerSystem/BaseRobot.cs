using System;
using System.Collections.Generic;
using System.Linq;

namespace SupermarketLockerSystem
{
    public abstract class BaseRobot
    {
        protected static int LockerCount;
        protected readonly List<Locker> Lockers;

        protected BaseRobot(List<Locker> lockerList)
        {
            LockerCount = lockerList.Count;
            Lockers = lockerList;
        }

        public abstract Ticket Store(Bag bag);

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