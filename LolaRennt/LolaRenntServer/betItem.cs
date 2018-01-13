namespace LolaRenntServer
{
    public class BetItem
    {
        public string UserId { get; set; }

        public long? Amount { get; set; }

        public BetDriver Driver { get; set; }
    }

    public enum BetDriver
    {

        Driver1 = 0,

        Driver2 = 1,

    }
}
