using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    //public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void LateUpdate()
    {

        Vector3 newPos = target.position + offset;
        newPos.z = transform.position.z;
        transform.position = newPos;

        //Vector3 desiredPosition = target.position + offset;
        //Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        //transform.position = smoothedPosition;

        //transform.LookAt(target);
    }
}
