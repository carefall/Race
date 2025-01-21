using TMPro;
using UnityEngine;

public class Laps : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI laps;
    private int lap = 0;

    private void Start()
    {
        OnFinishCross();
    }

    public void OnFinishCross()
    {
        lap++;
        laps.text = lap + "/" + transform.childCount;
    }
}
