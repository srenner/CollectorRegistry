namespace CollectorRegistry.Server.Enum
{
    public class EntryStatusEnum : Enumeration
    {
        public static EntryStatusEnum Draft = new(1, nameof(Draft));
        public static EntryStatusEnum Pending = new(2, nameof(Pending));
        public static EntryStatusEnum FlagReview = new(3, nameof(FlagReview));
        public static EntryStatusEnum Complete = new(4, nameof(Complete));

        public EntryStatusEnum(int id, string name) : base(id, name)
        {
        }
    }
}
