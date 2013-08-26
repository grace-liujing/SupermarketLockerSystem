using System;

namespace SupermarketLockerSystem
{
    public class Locker
    {
        private Bag _bag;
        private Ticket _ticket;
        public Ticket Store(Bag bag)
        {
            if (_bag == null && _ticket == null)
            {
                _bag = bag;
                _ticket = new Ticket();
                return _ticket;
            }
            throw new InvalidOperationException();
        }
    }
}