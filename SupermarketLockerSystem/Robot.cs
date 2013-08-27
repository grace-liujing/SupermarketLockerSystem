using System;
using System.Collections.Generic;

namespace SupermarketLockerSystem
{
    public class Robot
    {
        private static int _lockerCount = 10;
        private List<Locker> lockers;
        private static int currentLockerNum = 0;

        public Robot()
        {
            lockers = new List<Locker>(_lockerCount);
            for (var num = 0; num < _lockerCount; num++)
            {
                lockers.Add(new Locker());
            }

        }

        public Ticket Store(Bag bag)
        {
            var ticket = lockers[currentLockerNum].Store(bag);
            currentLockerNum++;
            return ticket;
        }

        public Bag Pick(Ticket ticket)
        {
            int num;
            Bag bag = null;
            for (num = 0; num <= currentLockerNum; num++)
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
            if (num > currentLockerNum) throw new InvalidOperationException();
            return bag;
        }
    }
}