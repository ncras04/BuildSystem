using UnityEngine;

public class Building : MonoBehaviour
{

    [SerializeField] Color[] tints;

    [SerializeField] Material m_opaqueMat;
    [SerializeField] MeshRenderer render;

    private void Awake()
    {
        render = GetComponent<MeshRenderer>();
    }

    public void SetTint(bool _isPlacable)
    {
        int color = _isPlacable ? 0 : 1;

        render.material.SetColor("_tint", tints[color]);
        render.material.SetFloat("_transparency", 0.2f + (color * 0.5f));
    }

    public void PlaceBuilding()
    {
        transform.SetParent(null);
        render.material = m_opaqueMat;
    }

}
