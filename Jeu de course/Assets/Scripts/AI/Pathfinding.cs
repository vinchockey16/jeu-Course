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

    public Pathfinding(int width, int height, Vector3 vecteur)
    {
   
        grid = new Grid<PathNodes>(width, height, 30f, vecteur, (Grid<PathNodes> g, int x, int y) => new PathNodes(g, x , y));
    }

    public Grid<PathNodes> GetGrid()
    {
        return grid;
    }

    public List<PathNodes> FindPath(int startX, int startY, int endX, int endY, int map, int aleatoire)
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
            for (int y = 0; y <= 4; y++)
            {
                listFerme.Add(grid.GetGridObject(7, y));
            }

            for (int y = 5; y <= 32; y++)
            {
                listFerme.Add(grid.GetGridObject(0, y));
            }

            for (int y = 0; y <= 4; y++)
            {
                listFerme.Add(grid.GetGridObject(2, y));
            }
            listFerme.Add(grid.GetGridObject(1, 4));
            listFerme.Add(grid.GetGridObject(1, 5));
            listFerme.Add(grid.GetGridObject(8, 4));
            listFerme.Add(grid.GetGridObject(8, 5));

            for (int y = 5; y <= 15; y++)
            {
                listFerme.Add(grid.GetGridObject(9, y));
            }

            listFerme.Add(grid.GetGridObject(10, 15));

            for (int x = 10; x <= 15; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 16));
            }

            for (int y = 21; y <= 27; y++)
            {
                listFerme.Add(grid.GetGridObject(5, y));
            }
            for (int y = 8; y <= 20; y++)
            {
                listFerme.Add(grid.GetGridObject(5, y));
            }
            for (int x = 6; x <= 11; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 20));
            }

            listFerme.Add(grid.GetGridObject(11, 21));

            for (int y = 21; y <= 28; y++)
            {
                listFerme.Add(grid.GetGridObject(12, y));
            }

            listFerme.Add(grid.GetGridObject(12, 20));

            listFerme.Add(grid.GetGridObject(13, 28));
            listFerme.Add(grid.GetGridObject(13, 29));
            listFerme.Add(grid.GetGridObject(14, 29));
            /**/listFerme.Add(grid.GetGridObject(9, 16));

            listFerme.Add(grid.GetGridObject(5, 28));
            listFerme.Add(grid.GetGridObject(5, 29));
            listFerme.Add(grid.GetGridObject(6, 29));

            for (int x = 6; x <= 35; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 30));
            }

            listFerme.Add(grid.GetGridObject(1, 32));
            listFerme.Add(grid.GetGridObject(1, 33));
            listFerme.Add(grid.GetGridObject(2, 33));

            for (int x = 2; x <= 36; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 34));
            }

            for (int y = 16; y <= 24; y++)
            {
                listFerme.Add(grid.GetGridObject(16, y));
            }
            for (int y = 23; y <= 25; y++)
            {
                listFerme.Add(grid.GetGridObject(17, y));
            }
            listFerme.Add(grid.GetGridObject(18, 25));

            for (int y = 9; y <= 25; y++)
            {
                listFerme.Add(grid.GetGridObject(19, y));
            }
            listFerme.Add(grid.GetGridObject(20, 9));
            listFerme.Add(grid.GetGridObject(20, 8));
            listFerme.Add(grid.GetGridObject(21, 8));

            for (int x = 21; x <= 27; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 7));
            }

            listFerme.Add(grid.GetGridObject(27, 8));
            listFerme.Add(grid.GetGridObject(28, 8));
            listFerme.Add(grid.GetGridObject(29, 8));

            for (int x = 29; x <= 33; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 9));
            }

            listFerme.Add(grid.GetGridObject(33, 10));
            listFerme.Add(grid.GetGridObject(34, 10));
            listFerme.Add(grid.GetGridObject(34, 11));

            listFerme.Add(grid.GetGridObject(35, 11));
            listFerme.Add(grid.GetGridObject(35, 12));
            listFerme.Add(grid.GetGridObject(35, 13));

            for (int x = 35; x <= 54; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 14));
            }

            for (int y = 14; y <= 25; y++)
            {
                listFerme.Add(grid.GetGridObject(23, y));
            }

            for (int y = 8; y <= 28; y++)
            {
                listFerme.Add(grid.GetGridObject(4, y));
            }

            listFerme.Add(grid.GetGridObject(20, 25));

            listFerme.Add(grid.GetGridObject(24, 14));
            listFerme.Add(grid.GetGridObject(24, 13));
            listFerme.Add(grid.GetGridObject(25, 11));
            listFerme.Add(grid.GetGridObject(26, 11));
            listFerme.Add(grid.GetGridObject(27, 13));
            listFerme.Add(grid.GetGridObject(28, 13));
            /**/listFerme.Add(grid.GetGridObject(18, 26));

            for (int x = 24; x <= 27; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 12));
            }

            listFerme.Add(grid.GetGridObject(23, 13));
            for (int x = 27; x <= 30; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 14));
            }

            for (int x = 23; x <= 38; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 26));
            }

            listFerme.Add(grid.GetGridObject(38, 25));
            listFerme.Add(grid.GetGridObject(39, 25));
            listFerme.Add(grid.GetGridObject(38, 24));
            listFerme.Add(grid.GetGridObject(37, 24));

            listFerme.Add(grid.GetGridObject(40, 25));

            for (int x = 26; x <= 37; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 23));
            }

            listFerme.Add(grid.GetGridObject(37, 22));

            for (int y = 15; y <= 22; y++)
            {
                listFerme.Add(grid.GetGridObject(25, y));
            }

            listFerme.Add(grid.GetGridObject(26, 15));
            listFerme.Add(grid.GetGridObject(26, 14));
            listFerme.Add(grid.GetGridObject(27, 14));

            listFerme.Add(grid.GetGridObject(36, 33));
            listFerme.Add(grid.GetGridObject(36, 32));
            listFerme.Add(grid.GetGridObject(37, 32));

            for (int x = 37; x <= 39; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 31));
            }

            for (int x = 39; x <= 42; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 30));
            }

            listFerme.Add(grid.GetGridObject(42, 29));
            listFerme.Add(grid.GetGridObject(43, 29));
            listFerme.Add(grid.GetGridObject(43, 28));
            

            for (int y = 22; y <= 28; y++)
            {
                listFerme.Add(grid.GetGridObject(44, y));
            }

            for (int y = 20; y <= 22; y++)
            {
                listFerme.Add(grid.GetGridObject(43, y));
            }

            listFerme.Add(grid.GetGridObject(42, 20));

            for (int x = 30; x <= 42; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 19));
            }

            for (int x = 30; x <= 54; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 18));
            }

            listFerme.Add(grid.GetGridObject(34, 14));

            for (int y = 0; y <= 3; y++)
            {
                listFerme.Add(grid.GetGridObject(5, y));
            }

            if (aleatoire == 1)
            {
                for (int x = 6; x <= 8; x++)
                {
                    listFerme.Add(grid.GetGridObject(x, 8));
                }
            }else if(aleatoire == 2)
            {
                for (int x = 20; x <= 22; x++)
                {
                    listFerme.Add(grid.GetGridObject(x, 25));
                }
                listFerme.Add(grid.GetGridObject(18, 26));
                listFerme.Add(grid.GetGridObject(19, 26));
            }

        }
        if (map == 2)
        {
            for (int y = 0; y <= 13; y++)
            {
                listFerme.Add(grid.GetGridObject(56, y));
            }

            listFerme.Add(grid.GetGridObject(55, 13));
            listFerme.Add(grid.GetGridObject(55, 14));
            listFerme.Add(grid.GetGridObject(54, 14));
            listFerme.Add(grid.GetGridObject(54, 15));
            listFerme.Add(grid.GetGridObject(53, 15));

            for (int x = 51; x <= 58; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 16));
            }

            listFerme.Add(grid.GetGridObject(58, 17));
            listFerme.Add(grid.GetGridObject(59, 17));
            listFerme.Add(grid.GetGridObject(59, 18));

            for (int y = 18; y <= 32; y++)
            {
                listFerme.Add(grid.GetGridObject(60, y));
            }

            listFerme.Add(grid.GetGridObject(61, 25));
            listFerme.Add(grid.GetGridObject(59, 32));
            listFerme.Add(grid.GetGridObject(59, 33));
            listFerme.Add(grid.GetGridObject(58, 33));

            for (int x = 18; x <= 58; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 34));
            }

            for (int y = 0; y <= 11; y++)
            {
                listFerme.Add(grid.GetGridObject(51, y));
            }

            for (int x = 35; x <= 50; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 11));
            }

            listFerme.Add(grid.GetGridObject(35, 12));
            listFerme.Add(grid.GetGridObject(34, 12));
            listFerme.Add(grid.GetGridObject(36, 12));
            listFerme.Add(grid.GetGridObject(35, 13));

            for (int x = 32; x <= 34; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 13));
            }

            listFerme.Add(grid.GetGridObject(32, 12));
            listFerme.Add(grid.GetGridObject(32, 11));
            listFerme.Add(grid.GetGridObject(31, 11));
            listFerme.Add(grid.GetGridObject(31, 10));
            listFerme.Add(grid.GetGridObject(31, 9));

            for (int y = 5; y <= 9; y++)
            {
                listFerme.Add(grid.GetGridObject(30, y));
            }

            listFerme.Add(grid.GetGridObject(29, 5));
            listFerme.Add(grid.GetGridObject(29, 4));
            listFerme.Add(grid.GetGridObject(28, 4));
          /**/  listFerme.Add(grid.GetGridObject(35, 12));

            for (int x = 26; x <= 28; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 3));
            }
            for (int x = 6; x <= 26; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 2));
            }

            listFerme.Add(grid.GetGridObject(6, 3));
            listFerme.Add(grid.GetGridObject(5, 3));
            listFerme.Add(grid.GetGridObject(5, 4));
            listFerme.Add(grid.GetGridObject(4, 4));
            listFerme.Add(grid.GetGridObject(4, 5));
            listFerme.Add(grid.GetGridObject(8, 8));
            listFerme.Add(grid.GetGridObject(8, 9));

            for (int y = 5; y <= 9; y++)
            {
                listFerme.Add(grid.GetGridObject(3, y));
            }

            for (int y = 9; y <= 11; y++)
            {
                listFerme.Add(grid.GetGridObject(4, y));
            }

            listFerme.Add(grid.GetGridObject(5, 11));

            for (int x = 5; x <= 16; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 12));
            }

            for (int x = 8; x <= 25; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 7));
            }

            for (int y = 8; y <= 10; y++)
            {
                listFerme.Add(grid.GetGridObject(25, y));
            }

           /**/ listFerme.Add(grid.GetGridObject(26, 7));
            listFerme.Add(grid.GetGridObject(26, 10));
            listFerme.Add(grid.GetGridObject(26, 11));
            listFerme.Add(grid.GetGridObject(27, 11));
            listFerme.Add(grid.GetGridObject(27, 12));

            for (int y = 13; y <= 24; y++)
            {
                listFerme.Add(grid.GetGridObject(27, y));
            }

            listFerme.Add(grid.GetGridObject(28, 24));
            listFerme.Add(grid.GetGridObject(28, 25));
            listFerme.Add(grid.GetGridObject(29, 25));
            listFerme.Add(grid.GetGridObject(29, 26));
            listFerme.Add(grid.GetGridObject(30, 26));
            /**/listFerme.Add(grid.GetGridObject(41, 27));
            /**/listFerme.Add(grid.GetGridObject(41, 28));

            for (int x = 30; x <= 40; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 27));
            }

            listFerme.Add(grid.GetGridObject(40, 28));

            for (int x = 36; x <= 47; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 16));
            }

            for (int x = 34; x <= 36; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 17));
            }

            for (int x = 32; x <= 34; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 18));
            }

            for (int y = 19; y <= 22; y++)
            {
                listFerme.Add(grid.GetGridObject(32, y));
            }

            for (int y = 17; y <= 19; y++)
            {
                listFerme.Add(grid.GetGridObject(47, y));
            }
            listFerme.Add(grid.GetGridObject(48, 19));

            for (int x = 48; x <= 55; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 20));
            }
           /**/ listFerme.Add(grid.GetGridObject(56, 20));

            for (int y = 21; y <= 29; y++)
            {
                listFerme.Add(grid.GetGridObject(56, y));
            }
            listFerme.Add(grid.GetGridObject(57, 24));
            listFerme.Add(grid.GetGridObject(57, 25));

            for (int x = 45; x <= 55; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 29));
            }

            for (int x = 33; x <= 42; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 22));
            }

            for (int x = 42; x <= 44; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 23));
            }

            listFerme.Add(grid.GetGridObject(44, 24));
            listFerme.Add(grid.GetGridObject(44, 25));

            for (int y = 25; y <= 28; y++)
            {
                listFerme.Add(grid.GetGridObject(45, y));
            }
            listFerme.Add(grid.GetGridObject(40, 28));

            for (int x = 20; x <= 40; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 29));
            }

            for (int x = 17; x <= 19; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 8));
            }
            listFerme.Add(grid.GetGridObject(19, 9));

            for (int y = 9; y <= 28; y++)
            {
                listFerme.Add(grid.GetGridObject(20, y));
            }

            for (int y = 13; y <= 17; y++)
            {
                listFerme.Add(grid.GetGridObject(16, y));
            }
            listFerme.Add(grid.GetGridObject(18, 33));
            listFerme.Add(grid.GetGridObject(17, 33));
            listFerme.Add(grid.GetGridObject(17, 32));

            for (int y = 22; y <= 32; y++)
            {
                listFerme.Add(grid.GetGridObject(16, y));
            }

            for (int x = 9; x <= 15; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 17));
            }
            for (int x = 11; x <= 15; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 22));
            }

            listFerme.Add(grid.GetGridObject(9, 18));
            listFerme.Add(grid.GetGridObject(8, 18));
            listFerme.Add(grid.GetGridObject(8, 19));

            for (int y = 19; y <= 26; y++)
            {
                listFerme.Add(grid.GetGridObject(7, y));
            }

            for (int y = 23; y <= 29; y++)
            {
                listFerme.Add(grid.GetGridObject(11, y));
            }

            listFerme.Add(grid.GetGridObject(10, 29));
            listFerme.Add(grid.GetGridObject(10, 30));
            listFerme.Add(grid.GetGridObject(9, 30));

            for (int x = 12; x <= 16; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 21));
            }

            for (int x = 0; x <= 6; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 26));
            }

            for (int x = 0; x <= 9; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 31));
            }

            for (int y = 0; y <= 4; y++)
            {
                listFerme.Add(grid.GetGridObject(52, y));
            }

            for (int y = 0; y <= 4; y++)
            {
                listFerme.Add(grid.GetGridObject(54, y));
            }

            if (aleatoire == 1)
            {
                for (int y = 12; y <= 15; y++)
                {
                    listFerme.Add(grid.GetGridObject(47, y));
                }
            }else if(aleatoire == 2)
            {
                for (int x = 28; x <= 31; x++)
                {
                    listFerme.Add(grid.GetGridObject(x, 13));
                }

                for (int x = 48; x <= 50; x++)
                {
                    listFerme.Add(grid.GetGridObject(x, 16));
                }
            }
        }

        if(map == 3)
        {
            for (int y = 0; y <= 8; y++)
            {
                listFerme.Add(grid.GetGridObject(7, y));
            }
            for (int y = 0; y <= 8; y++)
            {
                listFerme.Add(grid.GetGridObject(8, y));
            }
            for (int y = 0; y <= 11; y++)
            {
                listFerme.Add(grid.GetGridObject(3, y));
            }
            for (int y = 0; y <= 5; y++)
            {
                listFerme.Add(grid.GetGridObject(5, y));
            }

            listFerme.Add(grid.GetGridObject(4, 11));
            listFerme.Add(grid.GetGridObject(4, 12));
            listFerme.Add(grid.GetGridObject(5, 12));

            for (int x = 5; x <= 10; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 13));
            }

            listFerme.Add(grid.GetGridObject(10, 12));
            listFerme.Add(grid.GetGridObject(11, 12));
            listFerme.Add(grid.GetGridObject(11, 11));

            for (int y = 5; y <= 11; y++)
            {
                listFerme.Add(grid.GetGridObject(12, y));
            }

            listFerme.Add(grid.GetGridObject(9, 2));
            listFerme.Add(grid.GetGridObject(9, 1));
            listFerme.Add(grid.GetGridObject(10, 1));

            for (int x = 10; x <= 32; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 0));
            }

            for (int x = 13; x <= 16; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 5));
            }

            for (int y = 6; y <= 11; y++)
            {
                listFerme.Add(grid.GetGridObject(16, y));
            }
            listFerme.Add(grid.GetGridObject(17, 11));
            listFerme.Add(grid.GetGridObject(17, 12));
            listFerme.Add(grid.GetGridObject(18, 12));
            listFerme.Add(grid.GetGridObject(18, 13));
            listFerme.Add(grid.GetGridObject(19, 13));

            for (int x = 21; x <= 30; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 5));
            }
            for (int x = 21; x <= 30; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 9));
            }
            for (int y = 6; y <= 8; y++)
            {
                listFerme.Add(grid.GetGridObject(21, y));
            }
            for (int y = 6; y <= 8; y++)
            {
                listFerme.Add(grid.GetGridObject(30, y));
            }

            for (int x = 19; x <= 47; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 14));
            }

            listFerme.Add(grid.GetGridObject(32, 1));
            listFerme.Add(grid.GetGridObject(33, 1));
            listFerme.Add(grid.GetGridObject(33, 2));

            for (int y = 2; y <= 9; y++)
            {
                listFerme.Add(grid.GetGridObject(34, y));
            }

            for (int x = 35; x <= 46; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 9));
            }
            listFerme.Add(grid.GetGridObject(46, 8));
            listFerme.Add(grid.GetGridObject(47, 8));

            for (int x = 47; x <= 59; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 7));
            }

            listFerme.Add(grid.GetGridObject(47, 13));
            listFerme.Add(grid.GetGridObject(48, 13));
            listFerme.Add(grid.GetGridObject(48, 12));
            listFerme.Add(grid.GetGridObject(49, 12));

            for (int x = 49; x <= 57; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 11));
            }

            listFerme.Add(grid.GetGridObject(54, 10));
            listFerme.Add(grid.GetGridObject(55, 10));
            listFerme.Add(grid.GetGridObject(54, 8));
            listFerme.Add(grid.GetGridObject(55, 8));

            for (int y = 4; y <= 6; y++)
            {
                listFerme.Add(grid.GetGridObject(59, y));
            }

            listFerme.Add(grid.GetGridObject(60, 6));
            listFerme.Add(grid.GetGridObject(60, 5));
            listFerme.Add(grid.GetGridObject(61, 5));

            for (int x = 61; x <= 67; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 2));
            }

            for (int x = 57; x <= 61; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 12));
            }
            for (int x = 61; x <= 63; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 11));
            }
            listFerme.Add(grid.GetGridObject(63, 10));

            for (int x = 63; x <= 65; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 9));
            }

            listFerme.Add(grid.GetGridObject(64, 8));
            listFerme.Add(grid.GetGridObject(64, 7));
            listFerme.Add(grid.GetGridObject(65, 10));
            listFerme.Add(grid.GetGridObject(65, 11));
            listFerme.Add(grid.GetGridObject(63, 7));
            listFerme.Add(grid.GetGridObject(65, 7));

            for (int y = 11; y <= 17; y++)
            {
                listFerme.Add(grid.GetGridObject(66, y));
            }

            listFerme.Add(grid.GetGridObject(67, 3));
            listFerme.Add(grid.GetGridObject(68, 3));
            listFerme.Add(grid.GetGridObject(68, 4));

            for (int y = 4; y <= 9; y++)
            {
                listFerme.Add(grid.GetGridObject(69, y));
            }

            listFerme.Add(grid.GetGridObject(70, 9));
            listFerme.Add(grid.GetGridObject(70, 10));

            for (int y = 10; y <= 20; y++)
            {
                listFerme.Add(grid.GetGridObject(71, y));
            }

            listFerme.Add(grid.GetGridObject(70, 20));
            listFerme.Add(grid.GetGridObject(70, 21));
            listFerme.Add(grid.GetGridObject(69, 21));

            for (int x = 57; x <= 69; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 22));
            }

            for (int x = 40; x <= 65; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 17));
            }

            listFerme.Add(grid.GetGridObject(54, 18));
            listFerme.Add(grid.GetGridObject(53, 18));
            listFerme.Add(grid.GetGridObject(53, 19));

            for (int y = 19; y <= 22; y++)
            {
                listFerme.Add(grid.GetGridObject(52, y));
            }

            for (int y = 23; y <= 29; y++)
            {
                listFerme.Add(grid.GetGridObject(57, y));
            }

            for (int x = 41; x <= 48; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 22));
            }

            for (int y = 23; y <= 25; y++)
            {
                listFerme.Add(grid.GetGridObject(48, y));
            }

            for (int y = 25; y <= 28; y++)
            {
                listFerme.Add(grid.GetGridObject(49, y));
            }

            for (int x = 50; x <= 52; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 26));
            }

            for (int x = 50; x <= 52; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 27));
            }

            listFerme.Add(grid.GetGridObject(56, 29));
            listFerme.Add(grid.GetGridObject(56, 30));
            listFerme.Add(grid.GetGridObject(55, 30));
            listFerme.Add(grid.GetGridObject(55, 31));
            listFerme.Add(grid.GetGridObject(54, 31));

            for (int x = 49; x <= 54; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 32));
            }

            listFerme.Add(grid.GetGridObject(49, 33));
            listFerme.Add(grid.GetGridObject(48, 33));

            for (int x = 43; x <= 48; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 34));
            }

            listFerme.Add(grid.GetGridObject(43, 35));
            listFerme.Add(grid.GetGridObject(42, 35));

            for (int x = 21; x <= 42; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 36));
            }

            listFerme.Add(grid.GetGridObject(47, 28));
            listFerme.Add(grid.GetGridObject(48, 28));

            for (int x = 43; x <= 47; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 29));
            }

            for (int x = 41; x <= 43; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 30));
            }

            for (int x = 24; x <= 41; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 31));
            }

            listFerme.Add(grid.GetGridObject(39, 18));
            listFerme.Add(grid.GetGridObject(40, 18));

            for (int x = 34; x <= 39; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 19));
            }

            listFerme.Add(grid.GetGridObject(34, 20));
            listFerme.Add(grid.GetGridObject(33, 20));

            for (int x = 28; x <= 33; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 21));
            }

            listFerme.Add(grid.GetGridObject(28, 22));
            listFerme.Add(grid.GetGridObject(27, 22));

            for (int x = 22; x <= 27; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 23));
            }
            for (int x = 20; x <= 22; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 24));
            }

            listFerme.Add(grid.GetGridObject(20, 25));
            listFerme.Add(grid.GetGridObject(19, 25));

            listFerme.Add(grid.GetGridObject(40, 23));
            listFerme.Add(grid.GetGridObject(41, 23));

            for (int x = 35; x <= 40; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 24));
            }

            for (int x = 33; x <= 35; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 25));
            }

            for (int x = 29; x <= 33; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 26));
            }

            for (int x = 27; x <= 29; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 27));
            }
            for (int x = 24; x <= 27; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 28));
            }

            listFerme.Add(grid.GetGridObject(24, 29));
            listFerme.Add(grid.GetGridObject(24, 30));

            listFerme.Add(grid.GetGridObject(21, 35));
            listFerme.Add(grid.GetGridObject(20, 35));
            listFerme.Add(grid.GetGridObject(20, 34));

            for (int y = 30; y <= 34; y++)
            {
                listFerme.Add(grid.GetGridObject(19, y));
            }

            for (int x = 0; x <= 19; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 26));
            }

            for (int x = 0; x <= 18; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 30));
            }

            if(aleatoire == 1)
            {
                for (int x = 17; x <= 20; x++)
                {
                    listFerme.Add(grid.GetGridObject(x, 5));
                }
            }
            else if(aleatoire == 2)
            {
                for (int x = 49; x <= 51; x++)
                {
                    listFerme.Add(grid.GetGridObject(x, 22));
                }
            }
            else if (aleatoire == 3)
            {
                for (int x = 17; x <= 20; x++)
                {
                    listFerme.Add(grid.GetGridObject(x, 5));
                }
                for (int x = 49; x <= 51; x++)
                {
                    listFerme.Add(grid.GetGridObject(x, 22));
                }
            }
        }

        if(map == 4)
        {
            for (int y = 16; y <= 24; y++)
            {
                listFerme.Add(grid.GetGridObject(31, y));
            }

            for (int y = 16; y <= 24; y++)
            {
                listFerme.Add(grid.GetGridObject(36, y));
            }

            for (int x = 24; x <= 30; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 24));
            }

            for (int x = 37; x <= 43; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 24));
            }

            for (int y = 15; y <= 23; y++)
            {
                listFerme.Add(grid.GetGridObject(24, y));
            }

            for (int y = 15; y <= 23; y++)
            {
                listFerme.Add(grid.GetGridObject(43, y));
            }

            for (int x = 25; x <= 42; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 15));
            }

            for (int x = 22; x <= 45; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 29));
            }

            listFerme.Add(grid.GetGridObject(45, 28));
            listFerme.Add(grid.GetGridObject(46, 28));
            listFerme.Add(grid.GetGridObject(46, 27));

            listFerme.Add(grid.GetGridObject(22, 28));
            listFerme.Add(grid.GetGridObject(21, 28));
            listFerme.Add(grid.GetGridObject(21, 27));

            listFerme.Add(grid.GetGridObject(32, 24));

            for (int x = 24; x <= 31; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 25));
            }

            for (int x = 36; x <= 43; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 25));
            }

            for (int y = 13; y <= 27; y++)
            {
                listFerme.Add(grid.GetGridObject(20, y));
            }

            for (int y = 13; y <= 27; y++)
            {
                listFerme.Add(grid.GetGridObject(47, y));
            }

            listFerme.Add(grid.GetGridObject(45, 12));
            listFerme.Add(grid.GetGridObject(46, 12));
            listFerme.Add(grid.GetGridObject(46, 13));

            listFerme.Add(grid.GetGridObject(22, 12));
            listFerme.Add(grid.GetGridObject(21, 12));
            listFerme.Add(grid.GetGridObject(21, 13));

            for (int x = 22; x <= 31; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 11));
            }

            for (int x = 36; x <= 45; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 11));
            }

            for (int y = 8; y <= 10; y++)
            {
                listFerme.Add(grid.GetGridObject(36, y));
            }

            listFerme.Add(grid.GetGridObject(31, 10));
            listFerme.Add(grid.GetGridObject(31, 9));

            listFerme.Add(grid.GetGridObject(35, 8));
            listFerme.Add(grid.GetGridObject(35, 7));

            for (int y = 7; y <= 9; y++)
            {
                listFerme.Add(grid.GetGridObject(30, y));
            }

            for (int y = 5; y <= 7; y++)
            {
                listFerme.Add(grid.GetGridObject(34, y));
            }

            for (int y = 3; y <= 7; y++)
            {
                listFerme.Add(grid.GetGridObject(29, y));
            }
            for (int y = 1; y <= 3; y++)
            {
                listFerme.Add(grid.GetGridObject(30, y));
            }

            listFerme.Add(grid.GetGridObject(31, 1));
            listFerme.Add(grid.GetGridObject(32, 1));

            for (int x = 32; x <= 57; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 0));
            }

            for (int x = 35; x <= 55; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 5));
            }

            listFerme.Add(grid.GetGridObject(57, 1));
            listFerme.Add(grid.GetGridObject(58, 1));
            listFerme.Add(grid.GetGridObject(58, 2));

            for (int y = 2; y <= 5; y++)
            {
                listFerme.Add(grid.GetGridObject(59, y));
            }

            for (int y = 6; y <= 8; y++)
            {
                listFerme.Add(grid.GetGridObject(55, y));
            }

            listFerme.Add(grid.GetGridObject(56, 8));
            listFerme.Add(grid.GetGridObject(56, 9));
            listFerme.Add(grid.GetGridObject(57, 9));

            for (int x = 60; x <= 62; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 5));
            }

            for (int x = 57; x <= 60; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 10));
            }

            listFerme.Add(grid.GetGridObject(62, 6));
            listFerme.Add(grid.GetGridObject(63, 6));
            listFerme.Add(grid.GetGridObject(63, 7));

            for (int y = 11; y <= 27; y++)
            {
                listFerme.Add(grid.GetGridObject(60, y));
            }

            for (int y = 7; y <= 30; y++)
            {
                listFerme.Add(grid.GetGridObject(64, y));
            }

            for (int x = 56; x <= 59; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 27));
            }

            listFerme.Add(grid.GetGridObject(56, 28));
            listFerme.Add(grid.GetGridObject(55, 28));

            for (int x = 50; x <= 55; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 29));
            }

            listFerme.Add(grid.GetGridObject(50, 30));
            listFerme.Add(grid.GetGridObject(49, 30));

            listFerme.Add(grid.GetGridObject(63, 30));

            listFerme.Add(grid.GetGridObject(57, 28));
            listFerme.Add(grid.GetGridObject(51, 30));

            for (int x = 59; x <= 63; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 31));
            }

            for (int x = 17; x <= 48; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 32));
            }

            for (int x = 5; x <= 13; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 32));
            }

            for (int x = 57; x <= 59; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 32));
            }
            for (int x = 55; x <= 57; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 33));
            }
            for (int x = 51; x <= 55; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 34));
            }
            for (int x = 49; x <= 51; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 35));
            }

            for (int x = 2; x <= 49; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 36));
            }

            for (int x = 18; x <= 49; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 31));
            }

            for (int x = 5; x <= 13; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 31));
            }

            listFerme.Add(grid.GetGridObject(2, 35));

            for (int y = 33; y <= 35; y++)
            {
                listFerme.Add(grid.GetGridObject(1, y));
            }

            for (int y = 4; y <= 33; y++)
            {
                listFerme.Add(grid.GetGridObject(0, y));
            }

            for (int y = 6; y <= 30; y++)
            {
                listFerme.Add(grid.GetGridObject(5, y));
            }

            for (int x = 9; x <= 11; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 30));
            }

            listFerme.Add(grid.GetGridObject(9, 29));
            listFerme.Add(grid.GetGridObject(9, 28));

            for (int y = 24; y <= 28; y++)
            {
                listFerme.Add(grid.GetGridObject(8, y));
            }

            listFerme.Add(grid.GetGridObject(17, 31));
            listFerme.Add(grid.GetGridObject(4, 31));

            listFerme.Add(grid.GetGridObject(18, 30));
            listFerme.Add(grid.GetGridObject(18, 29));
            listFerme.Add(grid.GetGridObject(17, 29));
            listFerme.Add(grid.GetGridObject(17, 28));
            listFerme.Add(grid.GetGridObject(16, 28));
            listFerme.Add(grid.GetGridObject(16, 27));
            listFerme.Add(grid.GetGridObject(15, 27));

            for (int x = 13; x <= 15; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 26));
            }

            listFerme.Add(grid.GetGridObject(15, 25));
            listFerme.Add(grid.GetGridObject(16, 25));
            listFerme.Add(grid.GetGridObject(16, 24));
            listFerme.Add(grid.GetGridObject(17, 24));
            listFerme.Add(grid.GetGridObject(17, 23));

            listFerme.Add(grid.GetGridObject(13, 27));
            listFerme.Add(grid.GetGridObject(13, 17));

            for (int y = 19; y <= 23; y++)
            {
                listFerme.Add(grid.GetGridObject(18, y));
            }

            for (int y = 22; y <= 24; y++)
            {
                listFerme.Add(grid.GetGridObject(9, y));
            }

            listFerme.Add(grid.GetGridObject(10, 22));
            listFerme.Add(grid.GetGridObject(11, 22));

            for (int x = 11; x <= 13; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 21));
            }

            for (int x = 9; x <= 11; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 20));
            }

            listFerme.Add(grid.GetGridObject(9, 19));
            listFerme.Add(grid.GetGridObject(9, 18));

            for (int y = 14; y <= 18; y++)
            {
                listFerme.Add(grid.GetGridObject(8, y));
            }

            listFerme.Add(grid.GetGridObject(9, 14));
            listFerme.Add(grid.GetGridObject(9, 13));
            listFerme.Add(grid.GetGridObject(8, 13));
            listFerme.Add(grid.GetGridObject(8, 12));
            listFerme.Add(grid.GetGridObject(7, 12));

            for (int x = 11; x <= 13; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 11));
            }

            listFerme.Add(grid.GetGridObject(13, 10));
            listFerme.Add(grid.GetGridObject(13, 9));
            listFerme.Add(grid.GetGridObject(12, 9));
            listFerme.Add(grid.GetGridObject(12, 8));

            for (int y = 6; y <= 8; y++)
            {
                listFerme.Add(grid.GetGridObject(11, y));
            }

            listFerme.Add(grid.GetGridObject(17, 19));
            listFerme.Add(grid.GetGridObject(17, 18));
            listFerme.Add(grid.GetGridObject(16, 18));
            listFerme.Add(grid.GetGridObject(16, 17));
            listFerme.Add(grid.GetGridObject(15, 17));

            for (int x = 13; x <= 15; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 16));
            }

            for (int x = 15; x <= 17; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 15));
            }

            listFerme.Add(grid.GetGridObject(17, 14));
            listFerme.Add(grid.GetGridObject(17, 13));

            for (int y = 9; y <= 13; y++)
            {
                listFerme.Add(grid.GetGridObject(18, y));
            }

            for (int y = 6; y <= 9; y++)
            {
                listFerme.Add(grid.GetGridObject(17, y));
            }

            for (int y = 6; y <= 7; y++)
            {
                listFerme.Add(grid.GetGridObject(16, y));
            }

            for (int x = 6; x <= 10; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 6));
            }

            for (int x = 18; x <= 28; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 6));
            }

            listFerme.Add(grid.GetGridObject(1, 4));
            listFerme.Add(grid.GetGridObject(1, 3));
            listFerme.Add(grid.GetGridObject(2, 3));

            for (int x = 2; x <= 28; x++)
            {
                listFerme.Add(grid.GetGridObject(x, 2));
            }

            for (int y = 3; y <= 5; y++)
            {
                listFerme.Add(grid.GetGridObject(28, y));
            }

            if(aleatoire == 1)
            {
                for (int y = 26; y <= 28; y++)
                {
                    listFerme.Add(grid.GetGridObject(31, y));
                }
            }
            else if (aleatoire == 2)
            {
                for (int y = 26; y <= 28; y++)
                {
                    listFerme.Add(grid.GetGridObject(31, y));
                }
                for (int x = 14; x <= 16; x++)
                {
                    listFerme.Add(grid.GetGridObject(x, 31));
                }
            }
            else if(aleatoire == 3)
            {
                for (int x = 14; x <= 16; x++)
                {
                    listFerme.Add(grid.GetGridObject(x, 31));
                }
            }
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
