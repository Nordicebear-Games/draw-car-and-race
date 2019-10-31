using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void FixedUpdate()
    {
        rotateObstacle();
    }

    private void rotateObstacle()
    {
        gameObject.transform.Rotate(new Vector3(0, 0, Random.Range(0f, 360f)) * Time.fixedDeltaTime * 0.5f);
    }
}
