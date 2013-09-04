using System;
using System.Collections.Generic;
using SupermarketLockerSystem;
using Xunit;

namespace SupermarketLockerSystemTest
{
    public class SmartRobotTest
    {
        private readonly SmartRobot smartRobot;
        private readonly Locker locker1;
        private readonly Locker locker2;

        public SmartRobotTest()
        {
            locker1 = new Locker(1);
            locker2 = new Locker(2);
            smartRobot = new SmartRobot(new List<Locker>() {locker1, locker2});
        }


        [Fact]
        public void should_get_a_ticket_when_smartrobot_store_a_bag_in_locker()
        {
            var bag = new Bag();
            Ticket ticket = smartRobot.Store(bag);

            Assert.NotNull(ticket);
        }

        [Fact]
        public void should_store_bag_in_locker_which_has_more_capacity()
        {
            smartRobot.Store(new Bag());
            Assert.Equal(1, locker2.AvailableCount);
        }

        [Fact]
        public void should_throw_exception_when_store_a_bag_if_all_lockers_are_full()
        {
            for (var i = 0; i < 3; i++)
            {
                smartRobot.Store(new Bag());
            }

            Assert.Throws<InvalidOperationException>(() => smartRobot.Store(new Bag()));
        }
    }


}