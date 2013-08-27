namespace SupermarketLockerSystem
{
    public class Robot
    {
        public Ticket store(Bag bag)
        {
            var locker = new Locker();
            return locker.Store(bag);
        }
    }
}