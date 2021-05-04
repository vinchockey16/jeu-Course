using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNodes 
{
    private Grid<PathNodes> grid;
    public int x;
    public int y;

    public int gCout;
    public int hCout;
    public int fCout;

    public PathNodes vientDeNode;

    public PathNodes(Grid<PathNodes> grid, int x, int y)
    {
        this.grid = grid;
        this.x = x ;
        this.y = y;
    }

    public void CalculateFCout()
    {
        fCout = gCout + hCout;
    }

    public override string ToString()
    {
        return x + "," + y;
    }
}
