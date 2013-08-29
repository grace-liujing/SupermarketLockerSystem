using System.Collections.Generic;
using SupermarketLockerSystem;
using Xunit;

namespace SupermarketLockerSystemTest
{
    public class RobotTest
    {
        private readonly Robot robot = new Robot(new List<Locker>()
            {
                new Locker(1),
                new Locker(2)
            });

        [Fact]
        public void should_get_a_ticket_when_robot_fisrt_store_a_bag_in_locker()
        {
            var bag = new Bag();
            Ticket ticket = robot.Store(bag);

            Assert.NotNull(ticket);
        }
        
        [Fact]
        public void should_get_two_different_tickets_when_robot_store_two_bags_in_locker()
        {
            var firstBag = new Bag();
            var secondBag = new Bag();

            Ticket firstTicket = robot.Store(firstBag);
            Ticket secondTicket = robot.Store(secondBag);

            Assert.NotNull(firstTicket);
            Assert.NotNull(secondTicket);
            Assert.NotSame(firstTicket, secondTicket);
        } 

        [Fact]
        public void should_pick_bag_when_robot_uses_right_ticket()
        {
            var bag = new Bag();
            Ticket ticket = robot.Store(bag);
            Bag pickdBag = robot.Pick(ticket);

            Assert.Same(bag,pickdBag);
        }

        [Fact]
        public void should_pick_right_bag_with_different_right_tickets()
        {
            var firstBag = new Bag();
            var secondBag = new Bag();
            Ticket firstTicket = robot.Store(firstBag);
            Ticket secondTicket = robot.Store(secondBag);
            Bag firstPickdBag = robot.Pick(firstTicket);
            Bag secondPickdBag = robot.Pick(secondTicket);

            Assert.Same(firstBag,firstPickdBag);
            Assert.Same(secondBag,secondPickdBag);
        }

        [Fact]
        public void should_store_bags_as_many_as_the_total_capacity()
        {
            for (int i = 0; i < 3; i++)
            {
                Ticket ticket = robot.Store(new Bag());
                Assert.NotNull(ticket);
            }
        }

        [Fact]
        public void should_store_by_circle_when_store_bag()
        {
            var firstBag = new Bag();
            var secondBag = new Bag();
            var thirdBag = new Bag();
            Ticket firstTicket = robot.Store(firstBag);
            robot.Store(secondBag);
            robot.Store(thirdBag);
            robot.Pick(firstTicket);
            var forthBag = new Bag();
            Ticket thirdTicket = robot.Store(forthBag);

            Assert.NotNull(thirdTicket);
        }
    }


}