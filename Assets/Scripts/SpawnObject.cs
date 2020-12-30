using UnityEngine;
using UnityEngine.UI;

public class SpawnObject : MonoBehaviour
{
    public GameObject objToSpawn;
    public Vector2 positionToSpawn;
    public bool spawnRandom;

    [SerializeField] private Scrollbar sizeScrollbar = null;
    [SerializeField] private Toggle randomSizeToggle = null;

    private float sizeToSpawn;
    private float sizeMultiplier;

    public void Start()
    {
        spawnRandom = true;
    }

    public void InstantiateObject()
    {
        //If the user chose random from dropdown menu, choose a random object from the array.
        if (spawnRandom)
        {
            objToSpawn = SceneController.objs[Random.Range(0, SceneController.objs.Length)];
        }

        //If the user chose random from size panel, use a random value from 0.5 - 1.5 to multiply with (if it was 0 - 1 it would just get smaller).
        //Otherwise just get the value from the scrollbar + 0.5 (default from scrollbar is 0.5 so adding 0.5 would normalize it to 1).
        switch (randomSizeToggle.isOn)
        {
            case true:
                sizeMultiplier = Random.Range(0.5f, 1.5f);
                break;
            case false:
                sizeMultiplier = sizeScrollbar.value + 0.5f;
                break;
        }

        //Loop through the indices of the objects
        for (int i = 0; i < SceneController.objs.Length; i++)
        {
            //If an objects name is equal to the name of the object the user wants to spawn, set the size to spawn equal to current index from the object sizes array * multiplier
            if (objToSpawn.name == SceneController.objs[i].name)
            {
                sizeToSpawn = SceneController.objSizes[i] * sizeMultiplier;
                break;
            }
        }

        //Change object scale to new scale (this consequently changes the prefab and needs to be fixed on exit in SceneController) and spawn object
        objToSpawn.transform.localScale = new Vector3(sizeToSpawn, sizeToSpawn, 0f);
        Instantiate(objToSpawn, positionToSpawn, Quaternion.identity);
    }

    //Fades away all objects
    public void Clear()
    {
        ObjectController[] objs = FindObjectsOfType<ObjectController>();

        foreach (ObjectController obj in objs)
        {
            StartCoroutine(obj.DisappearObjectCoroutine());
        }
    }
}
