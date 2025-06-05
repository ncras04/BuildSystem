using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class BuildingGrid
{
    public Building[,] grid;

    public int gridSize = 20;
    public int unitSize = 1;
    public BuildingGrid()
    {
        grid = new Building[gridSize, gridSize];
    }

    public bool SelectPiece(Vector3 _clickedPoint, ref Vector2Int _selectedGridPiece, out Building _tileInfo)
    {
        if ((_clickedPoint.x > 0) && (_clickedPoint.x < gridSize * unitSize) &&
            (_clickedPoint.z > 0) && (_clickedPoint.z < gridSize * unitSize))
        {
            Vector2Int clickedTile = new Vector2Int((int)_clickedPoint.x, (int)_clickedPoint.z);
            _selectedGridPiece = clickedTile;

            _tileInfo = grid[clickedTile.x, clickedTile.y];
            return true;
        }

        _tileInfo = null;
        return false;
    }

    public bool PlacePiece(Building _piece, Vector2Int _selectedGridPiece)
    {
        _piece.PlaceBuilding();
        grid[_selectedGridPiece.x, _selectedGridPiece.y] = _piece;
        return true;
    }
}
