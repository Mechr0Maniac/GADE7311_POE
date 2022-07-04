using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BoardSpace
{
    GRASS,
    HILL1,
    HILL2,
    HILL3,
    ROCKY,
    RUINFLOOR,
    RUINWALL
}

public class BoardGenerate
{
    private int width, height, originX, originY;

    public int Width
    {
        get { return width; }
    }

    public int Height
    {
        get { return height; }
    }
    public int X
    {
        get { return originX; }
    }
    public int Y
    {
        get { return originY; }
    }


    private BoardSpace[,] tiles;

    public BoardSpace[,] Tiles
    {
        get { return tiles; }
        set { tiles = value; }
    }

    public BoardGenerate(int w, int h, string[] s)
    {
        width = w;
        height = h;
        originX = Mathf.FloorToInt(width / 2);
        originY = Mathf.FloorToInt(height / 2);
        tiles = new BoardSpace[width, height];
        CreateBoard(s);
    }
    public void CreateBoard(string[] s)
    {
          
        char[] map;
        for (int j = 0; j < width; j++)
        {
            map = s[j].ToCharArray();
            for (int i = 0; i < height; i++)
            {
               int x = Random.Range(0,width);
               int y = Random.Range(0,height);
                int rx = Random.Range(0,width-4);
               int ry = Random.Range(0,height-4);
                switch (map[i])
                {
                 

                    case 'G': tiles[x, y] = BoardSpace.GRASS; break;
                    case 'H': tiles[x, y] = BoardSpace.HILL1; break;
                    case 'I': tiles[x, y] = BoardSpace.HILL2; break;
                    case 'J': tiles[x, y] = BoardSpace.HILL3; break;
                    case 'R': tiles[j, i] = BoardSpace.ROCKY; break;
                    case 'F': tiles[x, y] = BoardSpace.RUINFLOOR; break;
                    case 'W': tiles[rx, ry] = BoardSpace.RUINWALL; break;
                }
            }
        }
    }
}