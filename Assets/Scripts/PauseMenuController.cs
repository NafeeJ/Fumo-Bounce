using UnityEngine;
using UnityEngine.Rendering;
using TMPro;
using System.Collections.Generic;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu = null;
    [SerializeField] private TMP_Dropdown dropdown = null;

    private SpawnObject mySpawnObj;

    void Start()
    {
        mySpawnObj = FindObjectOfType<SpawnObject>();

        //Adding objects to dropdown menu
        List<string> options = new List<string>();
        options.Add("Random");
        foreach(GameObject obj in SceneController.objs)
        {
            options.Add(obj.name);
        }
        AddDropdownOptions(dropdown, options);

        Resume();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (SceneController.gamePaused)
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

    //Resume() and Pause() work by switching timeScale and active state of Pause Menu.
    //OnDemandRendering used to create better performance by skipping every other frame in pause menu.

    public void Resume()
    {
        OnDemandRendering.renderFrameInterval = 1;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        pauseMenu.transform.Find("ResumeButton").transform.localScale = new Vector3(1f, 1f, 1f);
        SceneController.gamePaused = false;
    }

    public void Pause()
    {
        OnDemandRendering.renderFrameInterval = 2;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        SceneController.gamePaused = true;
    }

    public void AddDropdownOptions(TMP_Dropdown dropdown, List<string> options)
    {
        dropdown.ClearOptions();
        dropdown.AddOptions(options);
    }

    //Set up in dropdown of the Unity Editor. If the selection is 0, the user chose random so tells SpawnObject to make spawnRandom true and returns. 
    //Otherwise, sets the objToSpawn to be the the object chosen using the index of the dropdown.
    public void SelectObj(int selection)
    {
        mySpawnObj.spawnRandom = selection == 0;
        if (selection == 0) return;
        mySpawnObj.objToSpawn = SceneController.objs[selection - 1];
    }

    public void OpenGitHub()
    {
        Application.OpenURL("https://github.com/NafeeJ/Fumo-Bounce"); //GitHub repo link here
    }
}
