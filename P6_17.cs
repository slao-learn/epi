using System;
using System.Collections.Generic;

public class P6_17
{
    public static bool IsValidSudoku(int[][] grid)
    {
        Dictionary<int, List<int>> rowData = new Dictionary<int, List<int>>();
        Dictionary<int, List<int>> colData = new Dictionary<int, List<int>>();
        Dictionary<int, List<int>> subgridData = new Dictionary<int, List<int>>();

        for (int i = 0; i < grid.Length; ++i)
        {
            rowData.Add(i, new List<int>());
            for (int j = 0; j < grid.Length; ++j)
            {
                if (!colData.ContainsKey(j))
                    colData.Add(j, new List<int>());

                int val = grid [i] [j];

                if (val == 0)
                    continue;

                // check row
                if (rowData [i].Contains(val))
                    return false;
                rowData [i].Add(val);

                // check column
                if (colData [j].Contains(val))
                    return false;
                colData [j].Add(val);

                // check subgridData
                int subgridIndex = 3 * (i / 3) + j / 3;
                if (!subgridData.ContainsKey(subgridIndex))
                    subgridData.Add(subgridIndex, new List<int>());
                else if (subgridData [subgridIndex].Contains(val))
                    return false;
                subgridData [subgridIndex].Add(val);
            }
        }

        return true;
    }
}

