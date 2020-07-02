using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFumo : MonoBehaviour
{

    public FumoController cirno;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SpawnCirno()
    {
        Instantiate(cirno, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }

    public void Clear()
    {
        FumoController[] fumos = FindObjectsOfType<FumoController>();

        foreach (FumoController fumo in fumos)
        {
            Destroy(fumo.gameObject); // :(
        }
    }
}
