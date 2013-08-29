using System;
using SupermarketLockerSystem;
using Xunit;

namespace SupermarketLockerSystemTest
{
    public class LockerTest
    {
        private readonly Locker locker = new Locker(4);

        [Fact]
        public void should_get_a_ticket_when_store_a_bag_into_locker()
        {
            var bag = new Bag();
            Ticket ticket = locker.Store(bag);
            Assert.NotNull(ticket);
        }

        [Fact]
        public void should_return_right_capacity_when_initialize()
        {
            Assert.Equal(4, locker.Capacity);
        }

        [Fact]
        public void should_get_right_capacity_after_store_a_bag_into_locker()
        {
            var bag = new Bag();
            locker.Store(bag);
            Assert.Equal(3, locker.AvailableCount);
        }

        [Fact]
        public void should_return_ticket_when_store_another_bag_if_locker_has_available_box()
        {
            var bag = new Bag();
            var anotherBag = new Bag();
            locker.Store(bag);
            Ticket ticket = locker.Store(anotherBag);
            Assert.NotNull(ticket);
        }

        [Fact]
        public void should_throw_exception_when_store_bag_if_locker_is_full()
        {
            for (int i = 0; i < locker.Capacity; i++)
            {
                locker.Store(new Bag());
            }
            Assert.Throws<InvalidOperationException>(() => locker.Store(new Bag()));
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
