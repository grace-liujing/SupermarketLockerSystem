using System;
using System.Collections.Generic;
using SupermarketLockerSystem;
using Xunit;

namespace SupermarketLockerSystemTest
{
    public class LockerTest
    {
        private readonly Locker _locker = new Locker(2);

        [Fact]
        public void should_get_a_ticket_when_store_a_bag_into_locker()
        {
            var bag = new Bag();
            Ticket ticket = _locker.Store(bag);
            Assert.NotNull(ticket);
        }

        [Fact]
        public void should_pick_the_bag_from_locker_when_use_right_ticket()
        {
            var bag = new Bag();
            Ticket ticket = _locker.Store(bag);
            Bag pickBag = _locker.Pick(ticket);

            Assert.Equal(bag, pickBag);
        }

        [Fact]
        public void should_be_unavailable_when_locker_is_full()
        {
            FillLockerToFullAndGetTickets();
            Assert.False(_locker.IsAvailable());
        }

        [Fact]
        public void should_be_available_after_store_a_bag()
        {
            _locker.Store(new Bag());
            Assert.True(_locker.IsAvailable());
        }

        [Fact]
        public void should_be_available_after_pick_a_bag_from_full_locker()
        {
            var tickets = FillLockerToFullAndGetTickets();
            _locker.Pick(tickets[0]);
            Assert.True(_locker.IsAvailable());
        }

        [Fact]
        public void should_throw_exception_when_store_bag_if_locker_is_full()
        {
            FillLockerToFullAndGetTickets();
            Assert.Throws<InvalidOperationException>(() => _locker.Store(new Bag()));
        }

        private List<Ticket> FillLockerToFullAndGetTickets()
        {
            var tickets = new List<Ticket>();
            for (var i = 0; i < _locker.Capacity; i++)
            {
                tickets.Add(_locker.Store(new Bag()));
            }
            return tickets;
        }

        [Fact] 
        public void should_get_ticket_when_store_nothing()
        {
            Ticket ticket = _locker.Store(null);
            Assert.NotNull(ticket);
        }

        [Fact]
        public void should_not_pick_the_bag_from_locker_when_null_ticket_is_provided()
        {
            var bag = new Bag();
            _locker.Store(bag);

            Assert.Throws<ArgumentNullException>(() => _locker.Pick(null));
        }

        [Fact]
        public void should_not_pick_the_bag_from_locker_when_use_another_ticket()
        {
            var bag = new Bag();
            _locker.Store(bag);
            var ticket = new Ticket();

            Assert.Throws<InvalidOperationException>(() => _locker.Pick(ticket));
        }       
        
        [Fact]
        public void should_not_pick_the_bag_from_locker_when_use_used_ticket()
        {
            var bag = new Bag();
            Ticket ticket = _locker.Store(bag);
            _locker.Pick(ticket);

            Assert.Throws<InvalidOperationException>(() => _locker.Pick(ticket));
        }

        [Fact]
        public void should_not_pick_the_bag_from_locker_before_storing_the_bag()
        {
            var ticket = new Ticket();

            Assert.Throws<InvalidOperationException>(() => _locker.Pick(ticket));
        }

        [Fact]
        public void should_get_vacancy_rate_from_locker()
        {
            Locker locker = new Locker(2);
            locker.Store(new Bag());
            var vacancyRate = locker.VacancyRate();
            Assert.Equal(0.5, vacancyRate);
        }

    }
}
