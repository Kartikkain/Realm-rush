using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{

    public void RestartLevel()
    {
        int currentscene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentscene);
        Time.timeScale = 1;
    }

    public void mainmenu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
        Time.timeScale = 1;
    }

    public void loadnamescene(string name)
    {
        SceneManager.LoadSceneAsync(name);
    }
    public void nextlevel()
    {
        int currentscene = SceneManager.GetActiveScene().buildIndex;
        currentscene++;
        int numberofScences = SceneManager.sceneCountInBuildSettings;
        if(currentscene < numberofScences-1)
        {
            SceneManager.LoadSceneAsync(currentscene);
            Time.timeScale = 1;
        }
        else
        {
            loadnamescene("Main Menu");
            Time.timeScale = 1;
        }
    }

   
    public void QuitGame()
    {
        Application.Quit();
    }
}
