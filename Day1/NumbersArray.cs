namespace Day1
{
    public class NumbersArray
    {
        public int[] Numbers { get; set; }

        public NumbersArray(int[] numbers)
        {
            Numbers = numbers;
        }

        public (int, int) GetTwoNumbersThatSumTo2020()
        {
            for (int outerIndex = 0; outerIndex < Numbers.Length; outerIndex++)
                for (int innerIndex = outerIndex; innerIndex < Numbers.Length; innerIndex++)
                    if ( Numbers[outerIndex] + Numbers[innerIndex] == 2020 )
                        return (Numbers[outerIndex], Numbers[innerIndex]);

            return (0,0);
        }

        public (int, int, int) GetThreeNumbersThatSumTo2020()
        {
            for (int outerIndex = 0; outerIndex < Numbers.Length; outerIndex++)
                for (int innerIndex = outerIndex; innerIndex < Numbers.Length; innerIndex++)
                    for (int innerestIndex = innerIndex; innerestIndex < Numbers.Length; innerestIndex++)
                        if ( Numbers[outerIndex] + Numbers[innerIndex] + Numbers[innerestIndex] == 2020 )
                            return (Numbers[outerIndex], Numbers[innerIndex], Numbers[innerestIndex]);

            return (0,0,0);
        }
    }
}
