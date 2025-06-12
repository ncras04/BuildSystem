using UnityEngine;

public class AgentBehaviour : MonoBehaviour
{
    public static Vector2[,] grid;

    public Vector3 direction;
    public float speed;

    public float changeSpeed;

    private void Awake()
    {
        grid = new Vector2[10, 10];

        grid[0, 0] = new Vector2(1, 0);
        grid[1, 0] = new Vector2(1, 0);
        grid[2, 0] = new Vector2(0, 1);
        grid[2, 1] = new Vector2(0, 1);
        grid[2, 2] = new Vector2(0, 1);
        grid[2, 3] = new Vector2(0, 1);
        grid[2, 4] = new Vector2(0, 1);
        grid[2, 5] = new Vector2(1, 0);
        grid[3, 5] = new Vector2(1, 0);
        grid[4, 5] = new Vector2(1, 0);
        grid[5, 5] = new Vector2(1, 0);


    }
    void Start()
    {

    }

    void Update()
    {
        Vector2 tileDir = grid[(int)transform.position.x, (int)transform.position.z];

        var t = Vector2.Distance(new Vector2(direction.x, direction.z), tileDir);
        t = 1 - Mathf.Clamp01(t);
        t = Mathf.Clamp01(speed * changeSpeed + t * speed * changeSpeed);

        float newDirX = Mathf.Lerp(direction.x, tileDir.x, t);
        float newDirY = Mathf.Lerp(direction.z, tileDir.y, t);

        direction = new Vector3(newDirX, 0, newDirY);

        transform.position += speed * Time.deltaTime * direction;
    }
}
