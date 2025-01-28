using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private float followSpeed;

    void Update()
    {
        Quaternion targetRotation = target.rotation;
        targetRotation.z = 0;
        targetRotation.x = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, followSpeed * Time.deltaTime);
    }
}
