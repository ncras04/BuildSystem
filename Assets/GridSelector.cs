using UnityEngine;

public class GridSelector : MonoBehaviour
{
    public Vector2Int selectedGridPiece = Vector2Int.one * -1;
    public BuildingGrid grid = new();
    public Transform cursor;
    public Transform selectedGridTile;

    Ray shotRay;

    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height, 0));
        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, 1 << 6))
        {
            if (hit.collider.CompareTag("Grid"))
            {
                cursor.position = hit.point;

                if (Input.GetMouseButtonDown(0))
                {
                    grid.SelectPiece(hit.point, ref selectedGridPiece, out int _);
                    selectedGridTile.position = new Vector3(selectedGridPiece.x + 0.5f, 0.0f, selectedGridPiece.y + 0.5f);
                }
            }
        }

        shotRay = ray;
    }
}