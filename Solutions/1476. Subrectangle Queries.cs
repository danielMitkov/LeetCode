public class SubrectangleQueries
{
    private int[][] grid;
    public SubrectangleQueries(int[][] rectangle)
    {
        grid = rectangle;
    }

    public void UpdateSubrectangle(int row1, int col1, int row2, int col2, int newValue)
    {
        for (int row = row1; row <= row2; ++row)
        {
            for (int col = col1; col <= col2; ++col)
            {
                grid[row][col] = newValue;
            }
        }
    }

    public int GetValue(int row, int col)
    {
        return grid[row][col];
    }
}
