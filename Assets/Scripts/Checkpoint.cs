using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (transform.parent.GetChild(0) == transform)
        {
            Destroy(gameObject);
        }
    }
}
