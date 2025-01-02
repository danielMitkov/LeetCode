//https://leetcode.com/problems/number-of-islands/solutions/6219857/o1-space-with-comments-by-danielmitkov-yncx/
public class Solution
{
    public int NumIslands(char[][] grid)
    {
        int count = 0;

        for (int r = 0; r < grid.Length; ++r)
        {
            for (int c = 0; c < grid[r].Length; ++c)
            {
                if (grid[r][c] == '0' || grid[r][c] == '2') continue; // if water or visited
                count++; // island begins
                Dfs(grid, r, c); // discover the rest of the same island
            }
        }

        return count;
    }

    private void Dfs(char[][] grid, int r, int c)
    {
        if (r < 0 || r >= grid.Length || c < 0 || c >= grid[r].Length) return; // if invalid coords
        if (grid[r][c] == '0' || grid[r][c] == '2') return; // if water or visited
        if (grid[r][c] == '1') grid[r][c] = '2'; // set as visited

        Dfs(grid, r - 1, c);
        Dfs(grid, r + 1, c);
        Dfs(grid, r, c - 1);
        Dfs(grid, r, c + 1);
    }
}
