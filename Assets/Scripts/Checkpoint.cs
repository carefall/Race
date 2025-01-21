using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (transform.parent.GetChild(0) == transform)
        {
            if (transform.parent.childCount == 1) Destroy(transform.parent.gameObject);
            else Destroy(gameObject);
        }
    }
}
