using UnityEngine;

public class SceneController : MonoBehaviour
{
    private SpawnFumo mySpawnFumo;

    void Start()
    {
        //QualitySettings.vSyncCount = 1;
        mySpawnFumo = FindObjectOfType<SpawnFumo>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            mySpawnFumo.InstantiateFumo();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            mySpawnFumo.Clear();
        }
    }
}
