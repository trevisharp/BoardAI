namespace BoardAI
{
    using System.Runtime.CompilerServices;

    public enum Piece : byte
    {
        WhiteStartPawn = 0,
        WhitePassantPawn = 1,
        WhitePawn = 2,
        WhiteRookableRook = 3,
        WhiteRook = 4,
        WhiteKnight = 5,
        WhiteBishop = 6,
        WhiteQueen = 7,
        WhiteFullRookableKing = 8,
        WhiteRightRookableKing = 9,
        WhiteLeftRookableKing = 10,
        WhiteKing = 11,

        None = 12,

        BlackStartPawn = 13,
        BlackPassantPawn = 14,
        BlackPawn = 15,
        BlackRookableRook = 16,
        BlackRook = 17,
        BlackKnight = 18,
        BlackBishop = 19,
        BlackQueen = 20,
        BlackFullRookableKing = 21,
        BlackRightRookableKing = 22,
        BlackLeftRookableKing = 23,
        BlackKing = 24,
    }

    public static class PieceExtension
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWhite(this Piece piece)
            => piece < Piece.None;
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsBlack(this Piece piece)
            => piece > Piece.None;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPiece(this Piece piece)
            => piece != Piece.None;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNone(this Piece piece)
            => piece == Piece.None;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWhitePawn(this Piece piece)
            => piece < Piece.WhiteRookableRook;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsBlackPawn(this Piece piece)
            => piece < Piece.BlackRookableRook && piece > Piece.None;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWhiteKing(this Piece piece)
            => piece > Piece.WhiteQueen && piece < Piece.None;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsBlackKing(this Piece piece)
            => piece > Piece.BlackQueen;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWhiteRook(this Piece piece)
            => piece == Piece.WhiteRook || piece == Piece.WhiteRookableRook;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsBlackRook(this Piece piece)
            => piece == Piece.BlackRook || piece == Piece.BlackRookableRook;
    }
}