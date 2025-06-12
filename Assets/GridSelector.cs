using UnityEngine;

public class GridSelector : MonoBehaviour
{
    public Vector2Int selectedGridPiece = Vector2Int.one * -1;
    public BuildingGrid grid = new();
    public Transform cursor;
    public Transform selectedGridTile;

    public GameObject buildingPrefab;
    private Building m_selectedBuilding;

    private void Awake()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
            m_selectedBuilding = Instantiate(buildingPrefab,
                new Vector3(selectedGridTile.position.x + 0.5f, selectedGridTile.position.y, selectedGridTile.position.z + 0.5f),
                Quaternion.identity, selectedGridTile).GetComponent<Building>();

        if (Input.GetKeyDown(KeyCode.C))
            Destroy(m_selectedBuilding.gameObject);

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height, 0));
        if (Physics.Raycast(ray, out RaycastHit hit, float.MaxValue, 1 << 6))
        {
            cursor.position = hit.point;

            if (Input.GetMouseButtonDown(0))
                selectedGridTile.position = new Vector3((int)hit.point.x + 0.5f, 0.0f, (int)hit.point.z + 0.5f);

            grid.SelectPiece(hit.point, ref selectedGridPiece, out Building building);

            if (m_selectedBuilding != false)
            {
                if (!selectedGridTile.gameObject.activeSelf)
                    selectedGridTile.gameObject.SetActive(true);

                selectedGridTile.position = new Vector3(selectedGridPiece.x, 0.0f, selectedGridPiece.y);

                if (Input.mouseScrollDelta.y > 0)
                    m_selectedBuilding.transform.localRotation *= Quaternion.Euler(new Vector3(0, 90, 0));
                if (Input.mouseScrollDelta.y < 0)
                    m_selectedBuilding.transform.localRotation *= Quaternion.Euler(new Vector3(0, -90, 0));


                if (building == false)
                {
                    m_selectedBuilding.SetTint(true);
                    if (Input.GetMouseButton(0))
                    {
                        grid.PlacePiece(m_selectedBuilding, selectedGridPiece);
                        m_selectedBuilding = null;
                    }
                }
                else
                    m_selectedBuilding.SetTint(false);
            }
            else if (selectedGridTile.gameObject.activeSelf)
                selectedGridTile.gameObject.SetActive(false);

        }

    }
}