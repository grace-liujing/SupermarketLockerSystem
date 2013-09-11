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
                },null);
            Ticket ticket = manager.Store(new Bag());

            Assert.NotNull(ticket);
        }

        [Fact]
        public void should_get_a_bag_when_manager_pick_with_ticket()
        {
            var manager = new Manager(new List<Locker>()
                {
                    new Locker(1)
                }, null);
            var bag = new Bag();
            Ticket ticket = manager.Store(bag);
            Bag pickedBag = manager.Pick(ticket);

            Assert.Same(bag,pickedBag);
        }

        [Fact]
        public void should_pick_bag_given_existing_ticket()
        {

            var robot = new Robot(new List<Locker> { new Locker(1) });
            var smartRobot = new SmartRobot(new List<Locker> { new Locker(1) });
            var superRobot = new SuperRobot(new List<Locker> { new Locker(1) });
            var lockers = new List<Locker> { new Locker(1) };
            var baseRobots = new List<BaseRobot> { robot, smartRobot, superRobot };
            var manager = new Manager(lockers, baseRobots);
            var expectedBag = new Bag();
            var ticket = manager.Store(expectedBag);
            var actualBag = manager.Pick(ticket);
            Assert.Equal(expectedBag, actualBag);
        }

        [Fact]
        public void should_store_bags_in_order_when_manager_manage_lockers_and_robots()
        {
            var locker = new Locker(1);
            var lockers = new List<Locker> { locker };
            var robot = new Robot(new List<Locker> { new Locker(1) });
            var smartRobot = new SmartRobot(new List<Locker> { new Locker(1) });
            var superRobot = new SuperRobot(new List<Locker> { new Locker(1) });
            var baseRobots = new List<BaseRobot> { robot, smartRobot, superRobot };
            var manager = new Manager(lockers, baseRobots);
            var bag1 = new Bag();
            var bag2 = new Bag();
            var bag3 = new Bag();
            var bag4 = new Bag();
            var ticket1 = manager.Store(bag1);
            var ticket2 = manager.Store(bag2);
            var ticket3 = manager.Store(bag3);
            var ticket4 = manager.Store(bag4);
            Assert.Equal(bag1, locker.Pick(ticket1));
            Assert.Equal(bag2, robot.Pick(ticket2));
            Assert.Equal(bag3, smartRobot.Pick(ticket3));
            Assert.Equal(bag4, superRobot.Pick(ticket4));
        }
    }
}