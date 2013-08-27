using SupermarketLockerSystem;
using Xunit;

namespace SupermarketLockerSystemTest
{
    public class RobotTest
    {
        
        [Fact]
        public void should_get_a_ticket_when_robot_fisrt_store_a_bag_in_locker()
        {
            var robot = new Robot();
            var bag = new Bag();
            Ticket ticket = robot.Store(bag);

            Assert.NotNull(ticket);
        }
        
        [Fact]
        public void should_get_two_different_tickets_when_robot_store_two_bags_in_locker()
        {
            var robot = new Robot();
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
            var robot = new Robot();
            var bag = new Bag();
            Ticket ticket = robot.Store(bag);
            Bag pickdBag = robot.Pick(ticket);

            Assert.Same(bag,pickdBag);
        }

        [Fact]
        public void should_pick_right_bag_with_different__right_tickets()
        {
            var robot = new Robot();
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
        public void should_circle_store_bag()
        {
            var robot = new Robot();
            var firstBag = new Bag();
            var secondBag = new Bag();
            Ticket firstTicket = robot.Store(firstBag);
            robot.Store(secondBag);
            robot.Pick(firstTicket);
            var thirdBag = new Bag();
            Ticket thirdTicket = robot.Store(thirdBag);

            Assert.NotNull(thirdTicket);
        }
    }


}