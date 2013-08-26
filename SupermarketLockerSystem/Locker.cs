using System;

namespace SupermarketLockerSystem
{
    public class Locker
    {
        private Bag _bag;
        public Ticket Store(Bag bag)
        {
            if (_bag == null)
            {
                _bag = bag;
                return new Ticket();
            }
            throw new InvalidOperationException();
        }
    }
}