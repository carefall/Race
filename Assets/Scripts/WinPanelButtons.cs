using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanelButtons : MonoBehaviour
{
    [SerializeField] Animator anim;

    public void Menu()
    {
        int level = PlayerPrefs.GetInt("level") + 1;
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.Save();
        StartCoroutine("LoadLevel", "Menu");
    }

    public void Next()
    {
        int level = PlayerPrefs.GetInt("level") + 1;
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.Save();
        StartCoroutine("LoadLevel", "Level" + level);
    }

    public IEnumerator NextLevel(string scene)
    {
        anim.Play("FadeNoSound");
        yield return new WaitForSeconds(1.2f);
        SceneManager.LoadScene(scene);
    }
}
