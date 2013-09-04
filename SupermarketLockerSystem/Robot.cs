using System;
using System.Collections.Generic;
using System.Linq;

namespace SupermarketLockerSystem
{
    public class Robot : BaseRobot
    {
        public Robot(List<Locker> lockerList) : base(lockerList)
        {

        }

        public override Ticket Store(Bag bag)
        {
            var locker = Lockers.FirstOrDefault(l => l.IsAvailable());
            if (locker == null)
            {
                throw new InvalidOperationException();
            }
            var ticket = locker.Store(bag);
            return ticket;
        }
    }
}