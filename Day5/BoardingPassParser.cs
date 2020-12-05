namespace AdventOfCode.Day5
{
    public class BoardingPassParser
    {
        public string Seat { get; private set; } = string.Empty;
        private int Row { get; set; } = 0;
        private int Col { get; set; } = 0;

        public BoardingPassParser(string seat)
        {
            Seat = seat;
        }

        public int GetRow()
        {
            BinaryTreeParser btp = new BinaryTreeParser(Seat.Substring(0, 7), 'F', 'B');
            Row = btp.GetValue();
            return Row;
        }

        public int GetCol()
        {
            BinaryTreeParser btp = new BinaryTreeParser(Seat.Substring(7, 3), 'L', 'R');
            Col = btp.GetValue();
            return Col;
        }

        public int GetId()
        {
            if (Row == 0) GetRow();
            if (Col == 0) GetCol();
            return Row * 8 + Col;
        }
    }
}