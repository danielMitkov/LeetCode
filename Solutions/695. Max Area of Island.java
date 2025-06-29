class Solution {

    public int maxAreaOfIsland(int[][] grid) {

        int maxArea = 0;

        for (int r = 0; r < grid.length; ++r) {

            for (int c = 0; c < grid[r].length; ++c) {

                int cell = grid[r][c];
                if (cell == 0 || cell == 2) continue;

                int area = areaAt(grid, r, c);
                if (area > maxArea) maxArea = area;
            }
        }

        return maxArea;
    }

    private int areaAt(int[][] grid, int r, int c) {

//        if (r < 0 || r >= grid.length) return 0;
//        if (c < 0 || c >= grid[r].length) return 0;
//        if (grid[r][c] == 0 || grid[r][c] == 2) return 0;

        grid[r][c] = 2;

        int up = tryVisit(grid, r - 1, c);
        int down = tryVisit(grid, r + 1, c);
        int left = tryVisit(grid, r, c - 1);
        int right = tryVisit(grid, r, c + 1);

        return 1 + up + down + left + right;
    }

    private int tryVisit(int[][] grid, int r, int c) {

        if (r < 0 || r >= grid.length) return 0;
        if (c < 0 || c >= grid[r].length) return 0;
        if (grid[r][c] == 0 || grid[r][c] == 2) return 0;

        return areaAt(grid, r, c);
    }
}
