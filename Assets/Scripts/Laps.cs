using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Laps : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI laps;
    [SerializeField] private Timer timer;
    [SerializeField] private CarController car;
    [SerializeField] private GameObject winPanel;
    private int lap = 0;

    private void Start()
    {
        OnFinishCross();
    }

    public void OnFinishCross()
    {
        if (lap == transform.childCount && transform.GetChild(lap - 1).childCount == 0)
        {
            int seconds = (int)timer.time;
            timer.enabled = false;
            car.enabled = false;
            winPanel.SetActive(true);
            return;
        }
        lap++;
        laps.text = lap + "/" + transform.childCount;
        transform.GetChild(lap - 1).gameObject.SetActive(true);
    }
}
