using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sirenix.Serialization;
using Unity.Mathematics;
using UnityEngine;

public class GridManager : SerializedMonoBehaviour
{
    [TableMatrix(SquareCells = true)/*(DrawElementMethod = nameof(DrawTile))*/,OdinSerialize]
    private GameObject[,] _grid=new GameObject[50,50];

    private Tile DrawTile(Rect rect, Tile tile)
    {
        UnityEditor.EditorGUI.DrawRect(rect,Color.blue);
        return tile; 
    }

    [Button]
    private void InitializeGrid()
    {
        for (int x = 0; x<_grid.GetLength(0); x++)
        for (int y = 0; y<_grid.GetLength(1); y++)
        {
            GameObject tile = _grid[x, y];
            if (tile==null)continue;
            {
                Vector3 pos = new(x, y, 0f);
                Instantiate(tile, pos, Quaternion.identity);
            }
        }
        
    }
}

[Serializable]
public class Tile
{
    [SerializeField] private Vector2Int _coords;
    public Vector2Int Coords => _coords;
     

    public Tile(Vector2Int coords)
    {
        _coords = coords; 
    }
}
