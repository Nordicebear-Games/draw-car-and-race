using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject car; 

    private Vector3 offset;           

    private void Start()
    {
        calculateOffset();
    }

    private void calculateOffset()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - car.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = new Vector3(car.transform.position.x + offset.x,
                                        -3f,
                                        car.transform.position.z + offset.z);
    }
}
