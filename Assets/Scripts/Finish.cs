using UnityEngine;

public class Finish : MonoBehaviour
{

    [SerializeField] private Laps laps;

    private void OnTriggerEnter(Collider other)
    {
        laps.OnFinishCross();
    }

}
