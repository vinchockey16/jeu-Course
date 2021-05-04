using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pathfinding
{
    private const int COUT_MOUV_DROIT = 10;
    private const int COUT_MOUV_DIAGO = 14;

 
    public Grid<PathNodes> grid;
    private List<PathNodes> listOuverte;
    private List<PathNodes> listFerme;

    public Pathfinding(int width, int height)
    {
   
        grid = new Grid<PathNodes>(width, height, 0.5f, new Vector3(-17,-6,0), (Grid<PathNodes> g, int x, int y) => new PathNodes(g, x , y));
    }

    public Grid<PathNodes> GetGrid()
    {
        return grid;
    }

    public List<PathNodes> FindPath(int startX, int startY, int endX, int endY, int map)
    {
        PathNodes nodeDebut = grid.GetGridObject(startX, startY);
        PathNodes nodeFin = grid.GetGridObject(endX, endY);

        listOuverte = new List<PathNodes> { nodeDebut };
        listFerme = new List<PathNodes>();

        for (int x = 0; x < grid.GetWidth(); x++)
        {
            for (int y = 0; y < grid.GetHeight(); y++)
            {
                PathNodes pathNodes = grid.GetGridObject(x, y);
                pathNodes.gCout = int.MaxValue;
                pathNodes.CalculateFCout();
                pathNodes.vientDeNode = null;
            }
        }

        nodeDebut.gCout = 0;
        nodeDebut.hCout = CalculDistanceCout(nodeDebut, nodeFin);
        nodeDebut.CalculateFCout();
        if (map == 1)
        {
            for (int x = 6; x <= 48; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 0));
            }
            
            for(int y =1; y <= 3; y++)
            {
                listFerme.Add(grid.GetGridObject(6, y));
            }

            for (int y = 0; y <= 3; y++)
            {
                listFerme.Add(grid.GetGridObject(2, y));
            }
            listFerme.Add(grid.GetGridObject(1, 3));
            listFerme.Add(grid.GetGridObject(1, 4));
            listFerme.Add(grid.GetGridObject(0, 4));
            listFerme.Add(grid.GetGridObject(1, 26));
            listFerme.Add(grid.GetGridObject(11, 26));
            listFerme.Add(grid.GetGridObject(11, 25));


            for (int y = 5; y <= 28; y++)
            {
                listFerme.Add(grid.GetGridObject(0, y));
            }

            for (int y = 1; y <= 13; y++)
            {
                listFerme.Add(grid.GetGridObject(41, y));
            }

            for (int x = 33; x <= 48; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 14));
            }

            for (int x = 29; x <= 40; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 9));
            }

            for (int x = 19; x <= 36; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 5));
            }

            for (int x = 1; x <= 12; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 27));
            }

            for (int x = 33; x <= 48; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 14));
            }

            for (int y = 19; y <= 27; y++)
            {
                listFerme.Add(grid.GetGridObject(42, y));
            }
            for (int x = 1; x <= 48; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 28));
            }

        }
        if(map == 2)
        {

        }

        if(map == 3)
        {

        }

        if(map == 4)
        {

        }
   

        while (listOuverte.Count > 0)
        {
           
            PathNodes nodeActuel = GetPlusBasCoutFNode(listOuverte);
            if (nodeActuel == nodeFin)
            {
                return CalculePath(nodeFin);
            }

            listOuverte.Remove(nodeActuel);
            listFerme.Add(nodeActuel);
            
            
            foreach(PathNodes nodeVoisine in GetListVoisine(nodeActuel))
            {

                if (listFerme.Contains(nodeVoisine)) continue;
                /*if (!neightbourNode.marchable)
                {
                    closedList.Add(neightbourNode);
                    continue;
                }*/

                int tentativeGCout = nodeActuel.gCout + CalculDistanceCout(nodeActuel, nodeVoisine);
                if(tentativeGCout < nodeVoisine.gCout)
                {
                    nodeVoisine.vientDeNode = nodeActuel;
                    nodeVoisine.gCout = tentativeGCout;
                    nodeVoisine.hCout = CalculDistanceCout(nodeVoisine, nodeFin);
                    nodeVoisine.CalculateFCout();

                    if (!listOuverte.Contains(nodeVoisine))
                    {
                        listOuverte.Add(nodeVoisine);
                    }
                }
            }
        }

        return null;
      
    }

    private List<PathNodes> GetListVoisine(PathNodes nodeActuel)
    {
        List<PathNodes> listVoisine = new List<PathNodes>();
     
        if(nodeActuel.x - 1 >= 0)
        {
            listVoisine.Add(GetNode(nodeActuel.x - 1, nodeActuel.y));

            if (nodeActuel.y - 1 >= 0) listVoisine.Add(GetNode(nodeActuel.x - 1, nodeActuel.y - 1));

            if (nodeActuel.y + 1 < grid.GetHeight()) listVoisine.Add(GetNode(nodeActuel.x - 1, nodeActuel.y + 1));
        }
        if (nodeActuel.x + 1 < grid.GetWidth())
        {
            listVoisine.Add(GetNode(nodeActuel.x + 1, nodeActuel.y));

            if (nodeActuel.y - 1 >= 0) listVoisine.Add(GetNode(nodeActuel.x + 1, nodeActuel.y - 1));

            if (nodeActuel.y + 1 < grid.GetHeight()) listVoisine.Add(GetNode(nodeActuel.x + 1, nodeActuel.y + 1));
        }

        if (nodeActuel.y - 1 >= 0) listVoisine.Add(GetNode(nodeActuel.x, nodeActuel.y - 1));
        if (nodeActuel.y + 1 < grid.GetHeight()) listVoisine.Add(GetNode(nodeActuel.x, nodeActuel.y + 1));
     
        
        return listVoisine;

    }

    private PathNodes GetNode(int x, int y) { 
        return grid.GetGridObject(x, y);
    }

    private List<PathNodes> CalculePath(PathNodes nodeFin)
    {
        List<PathNodes> chemin = new List<PathNodes>();
        chemin.Add(nodeFin);
        PathNodes nodeActuel = nodeFin;
        while(nodeActuel.vientDeNode != null)
        {
            chemin.Add(nodeActuel.vientDeNode);
            nodeActuel = nodeActuel.vientDeNode;

        }
        chemin.Reverse();
        return chemin;

    }

    private int CalculDistanceCout(PathNodes a, PathNodes b)
    {
        int xDistance = Mathf.Abs(a.x - b.x);
        int yDistance = Mathf.Abs(a.y - b.y);
        int restant = Mathf.Abs(xDistance - yDistance);
        return COUT_MOUV_DIAGO * Mathf.Min(xDistance, yDistance) + COUT_MOUV_DROIT * restant;
    }

    private PathNodes GetPlusBasCoutFNode(List<PathNodes> listPathNode)
    {
        PathNodes plusbasCoutF = listPathNode[0];
        for(int i = 1; i < listPathNode.Count; i++)
        {
            if(listPathNode[i].fCout < plusbasCoutF.fCout)
            {
                plusbasCoutF = listPathNode[i];
            }
        }
        return plusbasCoutF;
    }
}
