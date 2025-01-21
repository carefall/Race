using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{

    [SerializeField] Button ng, cont;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("level")) cont.interactable = false;
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("level", 1);
        PlayerPrefs.Save();
        StartCoroutine("LoadLevel");
    }

    public void Continue()
    {
        StartCoroutine("LoadLevel");
    }

    public IEnumerator LoadLevel()
    {
        ng.interactable = false;
        cont.interactable = false;
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene("Level" + PlayerPrefs.GetInt("level"), LoadSceneMode.Single);
    }

}
