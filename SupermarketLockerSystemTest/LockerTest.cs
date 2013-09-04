using System;
using System.Collections.Generic;
using SupermarketLockerSystem;
using Xunit;

namespace SupermarketLockerSystemTest
{
    public class LockerTest
    {
        private readonly Locker locker = new Locker(2);

        [Fact]
        public void should_get_a_ticket_when_store_a_bag_into_locker()
        {
            var bag = new Bag();
            Ticket ticket = locker.Store(bag);
            Assert.NotNull(ticket);
        }

        [Fact]
        public void should_be_unavailable_when_locker_is_full()
        {
            FillLockerToFullAndGetTickets();
            Assert.False(locker.IsAvailable());
        }

        [Fact]
        public void should_be_available_after_store_a_bag()
        {
            locker.Store(new Bag());
            Assert.True(locker.IsAvailable());
        }

        [Fact]
        public void should_be_available_after_pick_a_bag_from_full_locker()
        {
            var tickets = FillLockerToFullAndGetTickets();
            locker.Pick(tickets[0]);
            Assert.True(locker.IsAvailable());
        }

        [Fact]
        public void should_throw_exception_when_store_bag_if_locker_is_full()
        {
            FillLockerToFullAndGetTickets();
            Assert.Throws<InvalidOperationException>(() => locker.Store(new Bag()));
        }

        private List<Ticket> FillLockerToFullAndGetTickets()
        {
            var tickets = new List<Ticket>();
            for (var i = 0; i < locker.Capacity; i++)
            {
                tickets.Add(locker.Store(new Bag()));
            }
            return tickets;
        }

        [Fact] 
        public void should_get_ticket_when_store_nothing()
        {
            Ticket ticket = locker.Store(null);
            Assert.NotNull(ticket);
        }

        [Fact]
        public void should_pick_the_bag_from_locker_when_use_right_ticket()
        {
            var bag = new Bag();
            Ticket ticket = locker.Store(bag);
            Bag pickBag = locker.Pick(ticket);

            Assert.Equal(bag,pickBag);
        }

        [Fact]
        public void should_not_pick_the_bag_from_locker_when_null_ticket_is_provided()
        {
            var bag = new Bag();
            locker.Store(bag);

            Assert.Throws<ArgumentNullException>(() => locker.Pick(null));
        }

        [Fact]
        public void should_not_pick_the_bag_from_locker_when_use_another_ticket()
        {
            var bag = new Bag();
            locker.Store(bag);
            var ticket = new Ticket();

            Assert.Throws<InvalidOperationException>(() => locker.Pick(ticket));
        }       
        
        [Fact]
        public void should_not_pick_the_bag_from_locker_when_use_used_ticket()
        {
            var bag = new Bag();
            Ticket ticket = locker.Store(bag);
            locker.Pick(ticket);

            Assert.Throws<InvalidOperationException>(() => locker.Pick(ticket));
        }

        [Fact]
        public void should_not_pick_the_bag_from_locker_before_storing_the_bag()
        {
            var ticket = new Ticket();

            Assert.Throws<InvalidOperationException>(() => locker.Pick(ticket));
        }

    }
}
