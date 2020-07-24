using UnityEngine;

public class SpawnFumo : MonoBehaviour
{
    public GameObject fumoToSpawn;

    public void InstantiateFumo()
    {
        Instantiate(fumoToSpawn, new Vector3(0f, 0f, 0f), Quaternion.identity);
    }

    public void Clear()
    {
        FumoController[] fumos = FindObjectsOfType<FumoController>();

        foreach (FumoController fumo in fumos)
        {
            StartCoroutine(fumo.DisappearFumoCoroutine());
        }
    }
}
