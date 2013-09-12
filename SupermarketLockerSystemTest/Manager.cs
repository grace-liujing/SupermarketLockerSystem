using System;
using System.Collections.Generic;
using System.Linq;
using SupermarketLockerSystem;

namespace SupermarketLockerSystemTest
{
    public class Manager
    {
        private readonly List<Locker> lockers;
        private readonly List<BaseRobot> baseRobots;

        public Manager(List<Locker> lockerList, List<BaseRobot> baseRobotList)
        {
            lockers = lockerList;
            baseRobots = baseRobotList;
        }

        public Ticket Store(Bag bag)
        {
            Ticket ticket = null;
            var locker = lockers.FirstOrDefault(l => l.IsAvailable());
            if (locker != null)
            {
                ticket = locker.Store(bag);
                return ticket;
            }
            foreach (var baseRobot in baseRobots)
            {
                if (TryStore(baseRobot, bag, out ticket)) break;
            }
            if (ticket == null) throw new InvalidOperationException();
            return ticket;
        }

        public Bag Pick(Ticket ticket)
        {
            Bag bag = null;
            foreach (var locker in lockers)
            {
                if (TryPick(locker, ticket, out bag)) break;
            }
            if (bag != null)
                return bag;
            foreach (var baseRobot in baseRobots)
            {
                baseRobot.Pick(ticket);
            }
            if (bag == null) throw new InvalidOperationException();
                return bag;
        }

        private bool TryStore(BaseRobot baseRobot, Bag bag, out Ticket ticket)
        {
            try
            {
                ticket = baseRobot.Store(bag);
                return true;
            }
            catch (InvalidOperationException)
            {
                ticket = null;
                return false;
            }
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