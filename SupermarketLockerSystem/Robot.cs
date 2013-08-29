using System;
using System.Collections.Generic;

namespace SupermarketLockerSystem
{
    public class Robot
    {
        private static int _lockerCount;
        private List<Locker> lockers;

        public Robot(List<Locker> lockerList)
        {
            _lockerCount = lockerList.Count;
            lockers = lockerList;
        }

        public Ticket Store(Bag bag)
        {
            for (var num = 0; num < _lockerCount; num++)
            {
                if (lockers[num].IsAvailable())
                {
                    var ticket = lockers[num].Store(bag);
                    return ticket;
                }
            }
            throw new InvalidOperationException();
        }

        public Bag Pick(Ticket ticket)
        {
            int num;
            Bag bag = null;
            for (num = 0; num <= _lockerCount; num++)
            {
                try
                {
                    bag = lockers[num].Pick(ticket);
                    break;
                }
                catch (InvalidOperationException e)
                {
                }
            }
            return bag;
        }
    }
}