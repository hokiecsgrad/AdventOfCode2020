namespace AdventOfCode.Day9
{
    public class StreamValidator
    {
        public long[] StreamFrame { get; private set; } = new long[0];
        public long Value { get; private set; } = 0;

        public StreamValidator(long[] streamFrame, long value)
        {
            StreamFrame = streamFrame;
            Value = value;
        }

        public bool IsValid()
        {
            for (int i = 0; i < StreamFrame.Length; i++)
                for (int j = i + 1; j < StreamFrame.Length; j++)
                    if (StreamFrame[i] + StreamFrame[j] == Value)
                        return true;
            return false;
        }
    }
}