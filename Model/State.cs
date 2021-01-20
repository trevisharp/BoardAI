namespace BoardAI
{
    public readonly struct State
    {
        private readonly ushort board;
        private readonly ushort list;
        private readonly byte whitepower;
        private readonly byte blackpower;

        private State(ushort board, ushort list, byte whitepower, byte blackpower)
        {
            this.board = board;
            this.list = list;
            this.whitepower = whitepower;
            this.blackpower = blackpower;
        }

        private State(State state, ushort source, ushort target)
        {
            this.board = ByteBuffer.CopyAlloc(state.board);
            this.list = ByteBuffer.CopyAlloc(state.list);
            this.whitepower = state.whitepower;
            this.blackpower = state.blackpower;

            var stt = ByteBuffer.Access(this.board);
            var lst = ByteBuffer.Access(this.list);
        }

        static State()
        {
            //Create Empty State
            ushort empty = ByteBuffer.Alloc();
            ushort emptylist = ByteBuffer.Alloc();
            var emptyboard = ByteBuffer.Access(empty);
            for (int j = 0; j < 64; j++)
                emptyboard[j] = Piece.None;
            Empty = new State(empty, emptylist, 0, 0);

            //Create Initial State
            ushort initial = ByteBuffer.Alloc();
            ushort initiallist = ByteBuffer.Alloc();
            var initialboard = ByteBuffer.Access(initial);
            for (int j = 16; j < 48; j++)
                initialboard[j] = Piece.None;
            initialboard[0] = Piece.WhiteRookableRook;
            initialboard[1] = Piece.WhiteKnight;
            initialboard[2] = Piece.WhiteBishop;
            initialboard[3] = Piece.WhiteQueen;
            initialboard[4] = Piece.WhiteFullRookableKing;
            initialboard[5] = Piece.WhiteBishop;
            initialboard[6] = Piece.WhiteKnight;
            initialboard[7] = Piece.BlackRookableRook;
            for (int j = 8; j < 16; j++)
                initialboard[j] = Piece.WhiteStartPawn;
            for (int j = 48; j < 56; j++)
                initialboard[j] = Piece.BlackStartPawn;
            initialboard[63] = Piece.WhiteRookableRook;
            initialboard[62] = Piece.WhiteKnight;
            initialboard[61] = Piece.WhiteBishop;
            initialboard[60] = Piece.WhiteFullRookableKing;
            initialboard[59] = Piece.WhiteQueen;
            initialboard[58] = Piece.WhiteBishop;
            initialboard[57] = Piece.WhiteKnight;
            initialboard[56] = Piece.BlackRookableRook;
            Initial = new State(initial, initiallist, 80, 80);


        }

        public static readonly State Empty;
        public static readonly State Initial;

        public static bool operator ==(State a, State b)
        {
            return false;
        }

        public static bool operator !=(State a, State b)
        {
            return false;
        }

        public override bool Equals(object obj)
        {
            return false;
        }

        public override int GetHashCode()
            => board + list * short.MaxValue;
    }
}