using System;
using System.Collections.Generic;
using System.Linq;

namespace SupermarketLockerSystem
{
    public class SuperRobot : BaseRobot
    {
        public SuperRobot(List<Locker> lockerList):base(lockerList)
        {

        }

        public override Ticket Store(Bag bag)
        {
            var locker = Lockers.OrderByDescending(l => l.VacancyRate()).FirstOrDefault();
            if (locker == null || locker.AvailableCount == 0) throw new InvalidOperationException();
            return locker.Store(bag);
        }
    }
}