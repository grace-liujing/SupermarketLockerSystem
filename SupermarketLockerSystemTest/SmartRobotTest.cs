using System.Collections.Generic;
using SupermarketLockerSystem;
using Xunit;

namespace SupermarketLockerSystemTest
{
    public class SmartRobotTest
    {
        private readonly SmartRobot smartRobot = new SmartRobot(new List<Locker>()
            {
                new Locker(1),
                new Locker(2)
            });

        [Fact]
        public void should_get_a_ticket_when_smartrobot_store_a_bag_in_locker()
        {
            var bag = new Bag();
            Ticket ticket = smartRobot.Store(bag);

            Assert.NotNull(ticket);
        }

        [Fact]
        public void should_get_two_different_tickets_when_robot_store_two_bags_in_locker()
        {
            var firstBag = new Bag();
            var secondBag = new Bag();

            Ticket firstTicket = smartRobot.Store(firstBag);
            Ticket secondTicket = smartRobot.Store(secondBag);

            Assert.NotNull(firstTicket);
            Assert.NotNull(secondTicket);
            Assert.NotSame(firstTicket, secondTicket);
        } 

        [Fact]
        public void should_pick_bag_when_smartrobot_uses_right_ticket()
        {
            var bag = new Bag();
            Ticket ticket = smartRobot.Store(bag);
            Bag pickdBag = smartRobot.Pick(ticket);

            Assert.Same(bag, pickdBag);
        }

        [Fact]
        public void should_pick_right_bag_with_different_right_tickets()
        {
            var firstBag = new Bag();
            var secondBag = new Bag();
            Ticket firstTicket = smartRobot.Store(firstBag);
            Ticket secondTicket = smartRobot.Store(secondBag);
            Bag firstPickdBag = smartRobot.Pick(firstTicket);
            Bag secondPickdBag = smartRobot.Pick(secondTicket);

            Assert.Same(firstBag, firstPickdBag);
            Assert.Same(secondBag, secondPickdBag);
        }

        [Fact]
        public void should_store_bags_as_many_as_the_total_capacity()
        {
            for (var i = 0; i < 3; i++)
            {
                Ticket ticket = smartRobot.Store(new Bag());
                Assert.NotNull(ticket);
            }
        }

        [Fact]
        public void should_store_bag_in_locker_which_has_more_capacity()
        {
            var bag = new Bag();
            smartRobot.Store(bag);

            Assert.True(smartRobot.Lockers[0].IsAvailable());
            Assert.True(smartRobot.Lockers[1].IsAvailable());
        }
    }


}