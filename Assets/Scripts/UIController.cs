using System.Collections;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI countDown;
    [SerializeField] CarController car;
    [SerializeField] GameObject red, yellow, green, timer;


    private void Start()
    {
        StartCoroutine("Countdown");
    }

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(1);
        countDown.SetActive(true);
        yield return new WaitForSeconds(1);
        red.SetActive(true);
        countDown.text = "2";
        yield return new WaitForSeconds(1);
        red.SetActive(false);
        yellow.SetActive(true);
        countDown.text = "1";
        yield return new WaitForSeconds(1);
        yellow.SetActive(false);
        green.SetActive(true);
        countDown.text = "START";
        timer.SetActive(true);
        car.enabled = true;
        yield return new WaitForSeconds(0.5f);
        green.SetActive(false);
        countDown.SetActive(false);
    }

}
