namespace BoardAI
{
    using System;

    public static unsafe class ByteBuffer
    {
        private static byte[] buffer = new byte[64000];
        private static ulong[] allocated = new ulong[20];
        private static ushort next = 0;

        public static ushort Alloc()
        {
            ushort p = next;
            lock (allocated)
            {
                do next += 64; while (isallocated(next));
                setallocate(p);
            }
            return p;
        }

        public static ushort CopyAlloc(ushort source)
        {
            ushort newcode = Alloc();
            lock (buffer)
            {
                fixed (byte* p = &buffer[source])
                fixed (byte* q = &buffer[newcode])
                    Buffer.MemoryCopy(p, q, 64, 64);
            }
            return newcode;
        }

        public static void Deallocate(ushort code)
        {
            lock (allocated)
            {
                setdeallocate(code);
                var board = Access(code);
                for (int j = 0; j < 64; j++)
                    board[j] = 0;
            }
        }

        public static Span<Piece> Access(ushort code)
        {
            fixed (byte* p = &buffer[code])
                return new Span<Piece>(p, 64);
        }

        public static Span<byte> AccessBytes(ushort code)
        {
            fixed (byte* p = &buffer[code])
                return new Span<byte>(p, 64);
        }

        private static bool isallocated(ushort address)
        {
            int bit = address / 64;
            return allocated[bit / 64] >> (bit % 64) == 1;
        }

        private static void setallocate(ushort address)
        {
            int bit = address / 64;
            allocated[bit / 64] += (ulong)(1 << (bit % 64));
        }

        private static void setdeallocate(ushort address)
        {
            int bit = address / 64;
            allocated[bit / 64] -= (ulong)(1 << (bit % 64));
        }
    }
}