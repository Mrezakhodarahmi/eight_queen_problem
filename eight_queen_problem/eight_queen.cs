using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eight_queen_problem
{
    public class eight_queen
    {
        // Decleare the chees ground
        static int[,] chess = new int[8, 8];

        // Choose the safe place for queens
        public static bool IsSafe(int satrr = 0, int sotonn = 0)
        {
            for (int satr = satrr; satr < 8; satr++)
            {
                for (int soton = sotonn; soton < 8; soton++)
                {
                    if (chess[satr, soton] == 0)
                    {
                        chess[satr, soton] = 1;
                        NQueen(satr, soton);
                        return true;
                    }
                }
            }
            return false;
        }

        // Delete places that next queen can not stay on
        public static void NQueen(int satr, int soton)
        {
            // Set 2 this row
            for (int i = soton + 1; i < 8; i++)
            {
                chess[satr, i] = 2;
            }
            if (soton > 0)
            {
                for (int i = soton - 1; i >= 0; i--)
                {
                    chess[satr, i] = 2;
                }
            }

            // j => satr
            // Set 2 this column
            for (int j = satr + 1; j < 8; j++)
            {
                chess[j, soton] = 2;
            }
            if (satr > 0)
            {
                for (int j = satr - 1; j >= 0; j--)
                {
                    chess[j, soton] = 2;
                }
            }
            // Set 2 the Main diameter that created
            // i => soton
            // j => satr
            // m => satr

            int m = satr + 1;
            for (int i = soton + 1; i < 8; i++)
            {
                if (i < 8 && m < 8)
                {
                    chess[m, i] = 2;
                    m = m + 1;
                }
            }
            m = satr - 1;
            for (int i = soton - 1; i > 0; i--)
            {
                if (i >= 0 && m >= 0)
                {
                    chess[m, i] = 2;
                    m = m - 1;
                }
            }
            // Set 2 the Sub-diameter that created
            // i => soton
            // j => satr
            // m => satr

            m = satr + 1;
            for (int i = soton - 1; i >= 0; i--)
            {
                if (m < 8 && i >= 0)
                {
                    chess[m, i] = 2;
                    m = m + 1;
                }
            }

            m = satr - 1;
            for (int i = soton + 1; i < 8; i++)
            {
                if (m >= 0 && i < 8)
                {
                    chess[m, i] = 2;
                    m = m - 1;
                }
            }
        }

        public static int[,] main()
        {
            // Use IsSafe function (Eight times) to placement the Queens
            //for (int i = 0; i < 3; i++)
            //{
            //    IsSafe(0, 3);
            //}
            IsSafe(0, 3);
            IsSafe(1, 3);
            IsSafe(2, 3);
            IsSafe(3, 2);
            IsSafe(4);
            IsSafe(5, 6);
            IsSafe(6, 4);
            IsSafe(7);
            return chess;
        }
    }
}
