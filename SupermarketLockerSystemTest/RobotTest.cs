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
            Ticket ticket = robot.store(bag);

            Assert.NotNull(ticket);
        } 
    }


}