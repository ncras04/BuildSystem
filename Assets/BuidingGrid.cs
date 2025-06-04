using System.IO;
using UnityEngine;

public class BuildingGrid
{
    public int[,] grid;

    public int gridSize = 20;
    public int unitSize = 1;
    public BuildingGrid()
    {
        grid = new int[gridSize, gridSize];

        for (int y = 0; y < gridSize; y++)
        {
            for (int x = 0; x < gridSize; x++)
            {
                grid[y, x] = gridSize * y + x;
            }
        }
    }

    public bool SelectPiece(Vector3 _clickedPoint, ref Vector2Int _selectedGridPiece, out int _tileInfo)
    {
        if ((_clickedPoint.x > 0) && (_clickedPoint.x < gridSize * unitSize) &&
            (_clickedPoint.z > 0) && (_clickedPoint.z < gridSize * unitSize))
        {
            Vector2Int clickedTile = new Vector2Int((int)_clickedPoint.x, (int)_clickedPoint.z);
            _selectedGridPiece = clickedTile;

            _tileInfo = grid[clickedTile.x, clickedTile.y];
            return true;
        }

        _tileInfo = -1;
        return false;
    }
}
