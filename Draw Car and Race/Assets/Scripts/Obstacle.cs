using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float rotateSide;

    private void Start()
    {
        rotateSide = Random.value <= 0.5f ? 1 : -1;
    }

    private void FixedUpdate()
    {
        rotateObstacle();
    }

    private void rotateObstacle()
    {
        gameObject.transform.Rotate(new Vector3(0, 0, Random.Range(0f, 360f)) * (Time.fixedDeltaTime * rotateSide) * 0.5f);
    }
}
