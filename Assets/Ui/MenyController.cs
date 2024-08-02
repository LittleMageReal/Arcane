using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenyController : MonoBehaviour
{
    public GameObject Second;
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Second.SetActive(true);
        }
       
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void OnCloseMeny()
    {
        Second.SetActive(false);
    }

    public void OnClickConnect()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void OnClickMain()
    {
        SceneManager.LoadScene("MainScene");
    }
}

