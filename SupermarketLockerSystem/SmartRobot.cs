using System;
using System.Collections.Generic;

namespace SupermarketLockerSystem
{
    public class SmartRobot
    {
        private static int lockerCount;
        public readonly List<Locker> Lockers;

        public SmartRobot(List<Locker> lockerList)
        {
            lockerCount = lockerList.Count;
            Lockers = lockerList;
        }

        public Ticket Store(Bag bag)
        {
            var num = GetMostVacancyLocerNum();
            if (Lockers[num].IsAvailable())
            {
                var ticket = Lockers[num].Store(bag);
                return ticket;
            }
            throw new InvalidOperationException();
        }

        public Bag Pick(Ticket ticket)
        {
            int num;
            Bag bag = null;
            for (num = 0; num <= lockerCount; num++)
            {
                try
                {
                    bag = Lockers[num].Pick(ticket);
                    break;
                }
                catch (InvalidOperationException e)
                {
                }
            }
            return bag;
        }

        private int GetMostVacancyLocerNum()
        {
            var availableCount = 0;
            var tempLockerNum = 0;
            for (var num = 0; num < lockerCount; num++)
            {
                if (Lockers[num].AvailableCount > availableCount)
                {
                    availableCount = Lockers[num].AvailableCount;
                    tempLockerNum = num;
                }
            }
            return tempLockerNum;
        }
    }
}