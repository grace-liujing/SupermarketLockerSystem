using System.Collections.Generic;
using SupermarketLockerSystem;
using Xunit;

namespace SupermarketLockerSystemTest
{
    public class ManagerTest
    {
        [Fact]
        public void should_get_a_ticket_when_manager_store_a_bag()
        {
            var manager = new Manager(new List<Locker>()
            {
                new Locker(1)
            });
            Ticket ticket = manager.Store(new Bag());

            Assert.NotNull(ticket);
        }

        [Fact]
        public void should_get_a_bag_when_manager_pick_with_ticket()
        {
            var manager = new Manager(new List<Locker>()
            {
                new Locker(1)
            });
            var bag = new Bag();
            Ticket ticket = manager.Store(bag);
            Bag pickedBag = manager.Pick(ticket);

            Assert.Same(bag,pickedBag);
        }
    }
}