﻿using System;

namespace SupermarketLockerSystem
{
    public class Locker
    {
        private Tuple<Ticket, Bag> _storedBag;
        public Ticket Store(Bag bag)
        {
            if (_storedBag != null) throw new InvalidOperationException();
            var ticket = new Ticket();
            _storedBag = new Tuple<Ticket, Bag>(ticket, bag);
            return ticket;
        }

        public Bag Pick(Ticket ticket)
        {
            if (ticket == null) throw new ArgumentNullException();
            return _storedBag.Item2;
        }
    }
}