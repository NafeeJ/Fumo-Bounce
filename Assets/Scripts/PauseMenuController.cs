using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu = null;

    [SerializeField] private GameObject alice = null;
    [SerializeField] private GameObject chen = null;
    [SerializeField] private GameObject cirno = null;
    [SerializeField] private GameObject flandre = null;
    [SerializeField] private GameObject marisa = null;
    [SerializeField] private GameObject patchouli = null;
    [SerializeField] private GameObject ran = null;
    [SerializeField] private GameObject reimu = null;
    [SerializeField] private GameObject remilia = null;
    [SerializeField] private GameObject sakuya = null;
    [SerializeField] private GameObject yukari = null;

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
