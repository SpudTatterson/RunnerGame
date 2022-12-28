using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public GameObject HUD;
    public GameObject Deathcanvas;
    public GameObject pauseCanvas;
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void keepgoing()
    {
        Time.timeScale = 1;
        
        pauseCanvas.SetActive(false);
    }
}
