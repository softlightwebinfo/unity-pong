using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridHelper : MonoBehaviour
{
    public static int w = 15;
    public static int h = 15;
    public static Cell[,] cells = new Cell[w, h];

    public static void UncoverAllTheMines()
    {
        foreach (Cell c in cells)
        {
            if (c.hasMine)
            {
                c.loadTexture(0);
            }
        }
    }

    public static bool HasMineAt(int x, int y)
    {
        if (x >= 0 && y >= 0 && x < w && y < h)
        {
            //Dentro del grid
            Cell cell = cells[x, y];
            return cell.hasMine;
        }
        // Fuera del Grid
        return false;
    }

    public static int CountAdjacentMines(int x, int y)
    {
        int count = 0;

        if (HasMineAt(x - 1, y - 1)) count++;//Abajo izquierda
        if (HasMineAt(x - 1, y)) count++;//Abajo centro
        if (HasMineAt(x - 1, y + 1)) count++;//Abajo derecha
        if (HasMineAt(x, y - 1)) count++;//Medio izquierda
        if (HasMineAt(x, y + 1)) count++;//Medio derecha
        if (HasMineAt(x + 1, y - 1)) count++;//Arriba Izquierda
        if (HasMineAt(x + 1, y)) count++;//Arriba centro
        if (HasMineAt(x + 1, y + 1)) count++;//Arriba derecha

        return count;
    }

    public static void FloodFillUncover(int x, int y, bool[,] visited)
    {
        if (x >= 0 && y >= 0 && x < w && y < h)
        {
            if (visited[x, y]) return;

            int adjacentMines = CountAdjacentMines(x, y);

            cells[x, y].loadTexture(adjacentMines);

            if (adjacentMines > 0) return;

            visited[x, y] = true;

            FloodFillUncover(x - 1, y, visited);//Visitamos izquierda
            FloodFillUncover(x + 1, y, visited);//Visitamos derecha
            FloodFillUncover(x, y - 1, visited);//Visitamos abajo
            FloodFillUncover(x, y + 1, visited);//Visitamos arriba

            FloodFillUncover(x - 1, y - 1, visited);
            FloodFillUncover(x - 1, y + 1, visited);
            FloodFillUncover(x + 1, y - 1, visited);
            FloodFillUncover(x + 1, y + 1, visited);
        }
    }
}
