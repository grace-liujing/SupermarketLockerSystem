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
    }
}
