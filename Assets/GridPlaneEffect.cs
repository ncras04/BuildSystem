using UnityEngine;

public class GridPlaneEffect : MonoBehaviour
{
    [SerializeField] Transform Cursor;

    MeshRenderer render;

    private void Start()
    {
        render = GetComponent<MeshRenderer>();
    }
    void Update()
    {
        render.material.SetVector("_CursorPosition", Cursor.position);
    }
}
