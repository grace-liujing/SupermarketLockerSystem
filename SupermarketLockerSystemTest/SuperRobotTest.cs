using System;
using System.Collections.Generic;
using System.Linq;
using SupermarketLockerSystem;
using Xunit;

namespace SupermarketLockerSystemTest
{
    public class SuperRobotTest
    {
        private SuperRobot superRobot = new SuperRobot(new List<Locker>()
            {
                new Locker(1),
                new Locker(2)
            });

        [Fact]
        public void should_get_a_ticket_when_robot_store_a_bag_in_locker()
        {
            superRobot = new SuperRobot(new List<Locker>()
            {
                new Locker(1)
            });
            var bag = new Bag();
            Ticket ticket = superRobot.Store(bag);

            Assert.NotNull(ticket);
        }

        [Fact]
        public void should_pick_bag_when_robot_uses_right_ticket()
        {
            superRobot = new SuperRobot(new List<Locker>()
            {
                new Locker(1)
            });
            var bag = new Bag();
            Ticket ticket = superRobot.Store(bag);
            Bag pickdBag = superRobot.Pick(ticket);

            Assert.Same(bag, pickdBag);
        }

        [Fact]
        public void should_store_bag_in_most_vacancy_rate_locker_in_superrobot()
        {
            var locker1 = new Locker(2);
            var locker2 = new Locker(4);
            superRobot = new SuperRobot(new List<Locker>() { locker1, locker2 });
            locker2.Store(new Bag());
            superRobot.Store(new Bag());
            Assert.Equal(1,locker1.AvailableCount);

        }

        [Fact]
        public void should_throw_exception_when_store_a_bag_if_all_lockers_are_full()
        {
            Enumerable.Range(0, 3).ToList().ForEach(_ => superRobot.Store(new Bag()));
            Assert.Throws<InvalidOperationException>(() => superRobot.Store(new Bag()));
        }

        [Fact]
        public void should_be_invalid_when_pick_bag_use_wrong_ticket()
        {
            superRobot.Store(new Bag());

            Assert.Throws<InvalidOperationException>(() => superRobot.Pick(new Ticket()));
            Assert.Throws<ArgumentNullException>(() => superRobot.Pick(null));
        }


    }

}