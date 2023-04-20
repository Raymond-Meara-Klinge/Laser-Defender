using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    float waitLoad = 1f;

    public void LoadGame()
    {
        LoadScene("Game");
    }

    public void LoadMenu()
    {
        LoadScene("Main Menu");
    }

    public void LoadGO()
    {
        StartCoroutine(WaitLoad("Game Over", waitLoad));
    }

    void LoadScene(string scene)
    {
        SceneManager.LoadScene (scene);
    }

    public void Quit()
    {
        Debug.Log("WTF Man?");
        Application.Quit();
    }

    IEnumerator WaitLoad(string scene, float delay)
    {
        yield return new WaitForSeconds(delay);
        LoadScene (scene);
    }
}
