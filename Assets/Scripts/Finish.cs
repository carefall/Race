using UnityEngine;

public class Finish : MonoBehaviour
{

    [SerializeField] private Laps laps;

    private void OnTriggerEnter(Collider other)
    {
        if (laps.transform.childCount == 0)
        {
            // win
        }
        else if (laps.transform.GetChild(0).childCount == 0)
        {
            laps.OnFinishCross();
        }
    }

}
