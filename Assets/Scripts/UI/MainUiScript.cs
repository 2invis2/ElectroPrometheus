using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUiScript : MonoBehaviour
{

    public GameObject PauseUI;
    public bool isInGame = false;
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            PauseUIEnable();
        }
    }

    public void PauseUIEnable()
    {
        if (isInGame)
        {
            if (PauseUI.activeSelf)
            {
                PauseUI.SetActive(false);
            }
            else
            {
                PauseUI.SetActive(true);
            }
        }
        
    }
    public void StartGame()
    {
        isInGame = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
    public void RestartLvl()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SampleScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }


}
