using UnityEngine;

public class SpawnFumo : MonoBehaviour
{
    public GameObject fumoToSpawn;
    public bool spawnRandom;

    private FumoController[] fumos;

    public void Start()
    {
        spawnRandom = true;
        fumos = Resources.LoadAll<FumoController>("Prefabs/FumoPrefabs");
    }
    public void InstantiateFumo()
    {
        if (spawnRandom)
        {
            fumoToSpawn = fumos[Random.Range(0, fumos.Length)].gameObject;
        }

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
