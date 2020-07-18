using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private SpawnFumo mySpawnFumo;

    // Start is called before the first frame update
    void Start()
    {
        //QualitySettings.vSyncCount = 1;
        mySpawnFumo = FindObjectOfType<SpawnFumo>();
    }

    // Update is called once per frame
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
