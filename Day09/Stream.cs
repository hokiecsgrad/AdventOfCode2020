using System;

namespace AdventOfCode.Day9
{
    public class Stream
    {
        public long[] StreamData { get; private set; } = new long[0];
        public int FrameSize { get; private set; } = 0;
        public bool IsValid { get; private set; } = true;
        public long InvalidOperation { get; private set; } = 0;

        public Stream(long[] data, int frameSize = 25)
        {
            StreamData = data;
            FrameSize = frameSize;
        }

        public void Run()
        {
            int streamPosition = 0;
            for (streamPosition = FrameSize;
                    streamPosition < StreamData.Length;
                    streamPosition++)
            {
                Range frameWindowRange = (streamPosition - FrameSize)..(streamPosition);
                StreamValidator stream = new StreamValidator(
                                                StreamData[frameWindowRange],
                                                StreamData[streamPosition]);
                IsValid = stream.IsValid();
                if (!IsValid)
                {
                    InvalidOperation = StreamData[streamPosition];
                    break;
                }
            }
        }

        public (int, int) FindContiguousRange(long target)
        {
            long total = 0;
            for (int i = 0; i < StreamData.Length; i++)
            {
                total = StreamData[i];
                for (int j = i + 1; j < StreamData.Length; j++)
                {
                    if (total + StreamData[j] > target)
                        break;

                    total += StreamData[j];
                    if (total == target)
                        return (i, j);
                }
            }
            return (0, 0);
        }
    }
}