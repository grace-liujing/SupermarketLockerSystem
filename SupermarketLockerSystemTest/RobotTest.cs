using System;
using System.Collections.Generic;
using System.Linq;
using SupermarketLockerSystem;
using Xunit;

namespace SupermarketLockerSystemTest
{
    public class RobotTest
    {
        private  Robot robot = new Robot(new List<Locker>()
            {
                new Locker(1),
                new Locker(2)
            });

        [Fact]
        public void should_get_a_ticket_when_robot_store_a_bag_in_locker()
        {
            robot = new Robot(new List<Locker>()
            {
                new Locker(1)
            });
            var bag = new Bag();
            Ticket ticket = robot.Store(bag);

            Assert.NotNull(ticket);
        }

        [Fact]
        public void should_pick_bag_when_robot_uses_right_ticket()
        {
            robot = new Robot(new List<Locker>()
            {
                new Locker(1)
            });
            var bag = new Bag();
            Ticket ticket = robot.Store(bag);
            Bag pickdBag = robot.Pick(ticket);

            Assert.Same(bag, pickdBag);
        }

        [Fact]
        public void should_store_bag_in_order()
        {
            var locker1 = new Locker(2);
            var locker2 = new Locker(2);
            var regularRobot = new Robot(new[] { locker1, locker2 }.ToList());
            regularRobot.Store(new Bag());
            Assert.Equal(1, locker1.AvailableCount);
        }

        [Fact]
        public void should_throw_exception_when_store_a_bag_if_all_lockers_are_full()
        {
            Enumerable.Range(0, 3).ToList().ForEach(_ => robot.Store(new Bag()));
            Assert.Throws<InvalidOperationException>(() => robot.Store(new Bag()));
        }

        [Fact]
        public void should_be_invalid_when_pick_bag_use_wrong_ticket()
        {
            robot.Store(new Bag());

            Assert.Throws<InvalidOperationException>(() => robot.Pick(new Ticket()));
            Assert.Throws<ArgumentNullException>(() => robot.Pick(null));
        }
    }


}