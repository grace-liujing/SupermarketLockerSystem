using System;
using SupermarketLockerSystem;
using Xunit;

namespace SupermarketLockerSystemTest
{
    public class LockerTest
    {
        [Fact]
        public void should_get_a_ticket_when_store_a_bag_in_locker()
        {
            var bag = new Bag();
            var locker = new Locker();
            Ticket ticket = locker.Store(bag);
            Assert.NotNull(ticket);
        }

        [Fact]
        public void should_not_store_another_bag_when_locker_is_stored()
        {
            var bag = new Bag();
            var anotherBag = new Bag();
            var locker = new Locker();
            locker.Store(bag);
            Assert.Throws<InvalidOperationException>(() => locker.Store(anotherBag));
        }

        [Fact] 
        public void should_get_ticket_when_store_nothing()
        {
            var locker = new Locker();
            Ticket ticket=locker.Store(null);
            Assert.NotNull(ticket);
        }

        [Fact]
        public void should_not_store_another_bag_when_nothing_is_stored_in_locker()
        {
            var bag = new Bag();
            var locker = new Locker();
            locker.Store(null);
            Assert.Throws<InvalidOperationException>(() => locker.Store(bag));
        }

        [Fact]
        public void should_pick_the_bag_from_locker_when_use_right_ticket()
        {
            var bag = new Bag();
            var locker = new Locker();
            Ticket ticket = locker.Store(bag);
            Bag pickBag = locker.Pick(ticket);

            Assert.Equal(bag,pickBag);
        }

        [Fact]
        public void should_not_pick_the_bag_from_locker_when_null_ticket_is_provided()
        {
            var bag = new Bag();
            var locker = new Locker();
            locker.Store(bag);

            Assert.Throws<ArgumentNullException>(() => locker.Pick(null));
        }
    }
}
