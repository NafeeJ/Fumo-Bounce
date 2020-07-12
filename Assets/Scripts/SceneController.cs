using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private SpawnFumo mySpawnFumo;

    // Start is called before the first frame update
    void Start()
    {
        mySpawnFumo = FindObjectOfType<SpawnFumo>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            mySpawnFumo.SpawnCirno();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            mySpawnFumo.Clear();
        }
    }
}
