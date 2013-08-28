using System;
using System.Collections.Generic;

namespace SupermarketLockerSystem
{
    public class Robot
    {
        private static int _lockerCount = 2;
        private List<Locker> lockers;
        private static int currentLockerNum = 0;

        public Robot()
        {
            lockers = new List<Locker>(_lockerCount);
            for (var num = 0; num < _lockerCount; num++)
            {
                lockers.Add(new Locker(1));
            }

        }

        public Ticket Store(Bag bag)
        {
            for (var num = 0; num < _lockerCount; num++)
            {
                if (lockers[num].IsEmpty)
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