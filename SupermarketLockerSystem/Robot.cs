using System.Collections.Generic;

namespace SupermarketLockerSystem
{
    public class Robot
    {
        private int _lockerCount = 10;
        private List<Locker> lockers;

        public Robot()
        {
            lockers = new List<Locker>(_lockerCount);
        }

        public Ticket Store(Bag bag)
        {
            var locker = new Locker();
            return locker.Store(bag);
        }
    }
}