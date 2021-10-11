using UnityEngine;

public class MazeRenderer : MonoBehaviour
{
    [SerializeField]
    [Range(1, 50)]
    private int width = 10;

    [SerializeField]
    [Range(1, 50)]
    private int height = 10;

    [SerializeField] private float size = 1f;

    [SerializeField] private Transform wallPrefab = null;

    [SerializeField] private GameObject finishPrefab = null;

    [SerializeField] private GameObject player = null;

    [SerializeField] private GameObject floor = null;

    private void Awake()
    {
        var maze = MazeGenerator.Generate(width, height);
        Draw(maze);
    }

    private void Draw(WallState[,] maze)
    {
        var floorPosition = new Vector3(width / 4, 1, height / 4);
        floor.transform.localScale = floorPosition;

        var playerPosition = new Vector3(-width / 2, 1, height / 2.5f);
        player.transform.position = playerPosition;

        Vector3 finishPosition = new Vector3(width / 2.5f, 0, -height / 2.0f);
        finishPrefab.transform.position = finishPosition;

        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < height; ++j)
            {
                var cell = maze[i, j];
                var position = new Vector3(-width / 2 + i, 0, -height / 2 + j);

                if (cell.HasFlag(WallState.UP))
                {
                    Transform topWall = Instantiate(wallPrefab, transform);
                    topWall.position = position + new Vector3(0, 0, size / 2);
                    topWall.localScale = new Vector3(size, topWall.localScale.y, topWall.localScale.z);
                }

                if (cell.HasFlag(WallState.LEFT))
                {
                    Transform leftWall = Instantiate(wallPrefab, transform);
                    leftWall.position = position + new Vector3(-size / 2, 0, 0);
                    leftWall.localScale = new Vector3(size, leftWall.localScale.y, leftWall.localScale.z);
                    leftWall.eulerAngles = new Vector3(0, 90, 0);
                }

                if (i == width - 1)
                {
                    if (cell.HasFlag(WallState.RIGHT))
                    {
                        Transform rightWall = Instantiate(wallPrefab, transform);
                        rightWall.position = position + new Vector3(+size / 2, 0, 0);
                        rightWall.localScale = new Vector3(size, rightWall.localScale.y, rightWall.localScale.z);
                        rightWall.eulerAngles = new Vector3(0, 90, 0);
                    }
                }

                if (j == 0)
                {
                    if (cell.HasFlag(WallState.DOWN))
                    {
                        Transform bottomWall = Instantiate(wallPrefab, transform);
                        bottomWall.position = position + new Vector3(0, 0, -size / 2);
                        bottomWall.localScale = new Vector3(size, bottomWall.localScale.y, bottomWall.localScale.z);
                    }
                }
            }
        }
    }
}