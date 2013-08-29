using System.Collections.Generic;
using SupermarketLockerSystem;
using Xunit;

namespace SupermarketLockerSystemTest
{
    public class SmartRobotTest
    {
        private readonly SmartRobot smarRobot = new SmartRobot(new List<Locker>()
            {
                new Locker(1),
                new Locker(2)
            });

        [Fact]
        public void should_get_a_ticket_when_smartrobot_store_a_bag_in_locker()
        {
            var bag = new Bag();
            Ticket ticket = smarRobot.Store(bag);

            Assert.NotNull(ticket);
        }

        [Fact]
        public void should_pick_bag_when_smartrobot_uses_right_ticket()
        {
            var bag = new Bag();
            Ticket ticket = smarRobot.Store(bag);
            Bag pickdBag = smarRobot.Pick(ticket);

            Assert.Same(bag, pickdBag);
        }

        [Fact]
        public void should_store_bags_as_many_as_the_total_capacity()
        {
            for (var i = 0; i < 3; i++)
            {
                Ticket ticket = smarRobot.Store(new Bag());
                Assert.NotNull(ticket);
            }
        }
    }


}