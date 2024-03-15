using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;


    public GameObject canvasMenuUI;
    public GameObject pauseMenuUI;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused) 
            {
                Resume();
            }else
            {
                Pause();
            }
        }

    }

    public void Resume()
    {
        canvasMenuUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;

        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audio in audios)
        {
            audio.UnPause();
        }

    }

    private void Pause()
    {
        canvasMenuUI.SetActive(true);
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        AudioSource[] audios = FindObjectsOfType<AudioSource>();

        foreach (AudioSource audio in audios)
        {
            audio.Pause();
        }
        
    }
}
