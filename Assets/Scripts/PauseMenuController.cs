using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject cirno;
    public GameObject alice;

    private bool gamePaused;
    private SpawnFumo mySpawnFumo;

    // Start is called before the first frame update
    void Start()
    {
        mySpawnFumo = FindObjectOfType<SpawnFumo>();
        Resume();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (gamePaused)
            {
                case true:
                    Resume();
                    break;
                case false:
                    Pause();
                    break;
            }
        }
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        gamePaused = false;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        gamePaused = true;
    }

    public void SelectFumo(int selection)
    {
        switch (selection)
        {
            case 0:
                mySpawnFumo.fumoToSpawn = cirno;
                break;
            case 1:
                mySpawnFumo.fumoToSpawn = alice;
                break;
        }
    }
}
