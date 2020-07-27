using System;
using UnityEngine;
using UnityEngine.UIElements;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseMenu;

    [SerializeField]
    private GameObject alice;
    [SerializeField]
    private GameObject chen;
    [SerializeField]
    private GameObject cirno;
    [SerializeField]
    private GameObject flandre;
    [SerializeField]
    private GameObject marisa;
    [SerializeField]
    private GameObject patchouli;
    [SerializeField]
    private GameObject ran;
    [SerializeField]
    private GameObject reimu;
    [SerializeField]
    private GameObject remilia;
    [SerializeField]
    private GameObject sakuya;
    [SerializeField]
    private GameObject yukari;

    private bool gamePaused;
    private SpawnFumo mySpawnFumo;

    void Start()
    {
        mySpawnFumo = FindObjectOfType<SpawnFumo>();
        Resume();
    }

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
        pauseMenu.transform.Find("ResumeButton").transform.localScale = new Vector3(1f, 1f, 1f);
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
        if (selection != 0)
        {
            mySpawnFumo.spawnRandom = false;
        }

        switch (selection)
        {
            case 0:
                mySpawnFumo.spawnRandom = true;
                break;
            case 1:
                mySpawnFumo.fumoToSpawn = alice;
                break;
            case 2:
                mySpawnFumo.fumoToSpawn = chen;
                break;
            case 3:
                mySpawnFumo.fumoToSpawn = cirno;
                break;
            case 4:
                mySpawnFumo.fumoToSpawn = flandre;
                break;
            case 5:
                mySpawnFumo.fumoToSpawn = marisa;
                break;
            case 6:
                mySpawnFumo.fumoToSpawn = patchouli;
                break;
            case 7:
                mySpawnFumo.fumoToSpawn = ran;
                break;
            case 8:
                mySpawnFumo.fumoToSpawn = reimu;
                break;
            case 9:
                mySpawnFumo.fumoToSpawn = remilia;
                break;
            case 10:
                mySpawnFumo.fumoToSpawn = sakuya;
                break;
            case 11:
                mySpawnFumo.fumoToSpawn = yukari;
                break;
        }
    }
}
