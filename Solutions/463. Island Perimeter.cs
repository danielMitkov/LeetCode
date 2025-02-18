public class Solution
{
    public int IslandPerimeter(int[][] grid)
    {
        int result = 0;

        for (int r = 0; r < grid.Length; ++r)
        {
            for (int c = 0; c < grid[r].Length; ++c)
            {
                if (grid[r][c] == 0) // if current is water
                {
                    if (c + 1 < grid[r].Length && grid[r][c + 1] == 1) result++; // if land to the right
                    if (r + 1 < grid.Length && grid[r + 1][c] == 1) result++; // if land below
                }

                if (grid[r][c] == 1) // if current is land
                {
                    if (c + 1 < grid[r].Length && grid[r][c + 1] == 0) result++; // if water to the right
                    if (r + 1 < grid.Length && grid[r + 1][c] == 0) result++; // if water below

                    if (r == 0) result++; // if it's first row
                    if (r == grid.Length - 1) result++; // if it's last row

                    if (c == 0) result++; // if it's first column
                    if (c == grid[r].Length - 1) result++; // if it's last column
                }
            }
        }

        return result;
    }
}
