using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{

    public void loadMain()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void quitGame()
    {
        Application.Quit();
    }

<<<<<<< Updated upstream
    public void openPauseMenu()
    {

    }

    public void resume()
    {

    }

=======
>>>>>>> Stashed changes
}
