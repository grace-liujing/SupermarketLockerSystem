using System;

namespace SupermarketLockerSystem
{
    public class Locker
    {
        private Tuple<Ticket, Bag> _storedBag;
        public bool isEmpty { get; private set;}
        public Locker()
        {
            isEmpty = true;
        }

        public Ticket Store(Bag bag)
        {
            if (_storedBag != null) throw new InvalidOperationException();
            var ticket = new Ticket();
            _storedBag = new Tuple<Ticket, Bag>(ticket, bag);
            isEmpty = false;
            return ticket;
        }

        public Bag Pick(Ticket ticket)
        {
            if (ticket == null) throw new ArgumentNullException();
            if (_storedBag == null) throw new InvalidOperationException();
            
            Ticket dispatchedTicket = _storedBag.Item1;
            if (dispatchedTicket.Equals(ticket))
            {
                isEmpty = true;
                Bag bag = _storedBag.Item2;
                _storedBag = null;
                return bag;
            }

            throw new InvalidOperationException();
        }
    }
}