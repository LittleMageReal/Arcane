using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenyController : MonoBehaviour
{
    [SerializeField] private GameObject Second;
    [SerializeField] private TMP_Text LoadText;
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SecondMeny();
        }
       
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void SecondMeny()
    {
       Second.SetActive(true);
    }

    public void OnCloseMeny()
    {
        Second.SetActive(false);
    }

    public void OnClickConnect()
    {
        SceneManager.LoadSceneAsync("GameScene");
        LoadText.text = "Loading";
    }

    public void OnClickMain()
    {
        SceneManager.LoadSceneAsync("MainScene");
    }
}

