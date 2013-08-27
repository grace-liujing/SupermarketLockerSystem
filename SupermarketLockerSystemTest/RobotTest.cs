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

    }


}