//https://leetcode.com/problems/course-schedule/solutions/6239471/not-topological-sort-with-comments/
public class Solution
{
    public bool CanFinish(int numCourses, int[][] prerequisites)
    {
        // map of just dependencies
        var map = new Dictionary<int, List<int>>();
        // fill map
        for (int i = 0; i < prerequisites.Length; ++i)
        {
            int course = prerequisites[i][0];
            int dependency = prerequisites[i][1];

            if (!map.ContainsKey(course)) map.Add(course, new List<int>());

            map[course].Add(dependency);
        }
        // index is course
        bool[] visited = new bool[numCourses];
        // backtracking because the best next node to process is the last, you just cleared the dependencies of
        var lasts = new Stack<int>();
        // current course
        int current = 0;
        // while any dependencies exist
        while (map.Count > 0)
        {
            // if course has no dependency
            if (!map.ContainsKey(current))
            {
                // backtrack if possible or go to next(current + 1)
                current = lasts.Count > 0 ? lasts.Pop() : current + 1;
                // it is 'cleared' as it doesn't exist in map anyway
                continue;
            }

            List<int> dependencies = map[current];
            // keep clearing dependencies of this course until none or ... read else
            while (dependencies.Count > 0)
            {
                // if your dependency doesn't itself have dependency
                if (!map.ContainsKey(dependencies.Last()))
                {
                    // can be cleared
                    dependencies.RemoveAt(dependencies.Count - 1);
                }
                else // go resolve the dependency of your dependency first
                {
                    // loop detection
                    if (visited[dependencies.Last()]) return false;
                    // the previous node(current) may become clearable, so remember to go back
                    lasts.Push(current);
                    visited[current] = true;
                    // go to your dependency
                    current = dependencies.Last();
                    break;
                }
            }
            // if no dependencies
            if (dependencies.Count == 0)
            {
                // remove keyValuePair from map
                map.Remove(current);
                // backtrack if possible or go to next(current + 1)
                current = lasts.Count > 0 ? lasts.Pop() : current + 1;
            }
        }
        // if all dependencies are cleared(map.Count == 0), you can do all courses
        return true;
    }
}
