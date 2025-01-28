using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private TextMeshProUGUI text;
    [HideInInspector] public float time = 0;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        time += Time.deltaTime;
        int minutes = (int) time / 60;
        int seconds = (int) time % 60;
        text.text = (minutes > 9 ? minutes : "0" + minutes) + ":" + (seconds > 9? seconds : "0" + seconds);
    }
}
