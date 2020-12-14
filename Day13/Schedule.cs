namespace AdventOfCode.Day13
{
    public class Schedule
    {
        public long Id { get; private set; } = 0;
        public long Offset { get; private set; } = 0;

        public Schedule(long id)
        {
            Id = id;
        }

        public Schedule(long offset, long id)
        {
            Id = id;
            Offset = offset;
        }

        public long GetNearestDepartureTimeTo(long time)
        {
            long busArrivalTime = 0;
            while (busArrivalTime < time)
                busArrivalTime += Id;
            return busArrivalTime;
        }

        public Schedule CombineTwoBussesIntoOne(Schedule b1, Schedule b2)
        {
            var firstMatch = CalculateFirstMatch(b1, b2);
            return new Schedule(
                firstMatch * -1,
                b1.Id * b2.Id
                );
        }

        private long CalculateFirstMatch(Schedule b1, Schedule b2)
        {
            for (long i = b1.Id - b1.Offset; ; i += b1.Id)
            {
                if ((i + b2.Offset) % b2.Id == 0)
                {
                    return i;
                }
            }
        }
    }
}