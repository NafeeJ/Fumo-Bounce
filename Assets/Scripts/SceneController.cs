using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class SceneController : MonoBehaviour
{
    private SpawnObject mySpawnObj;

    //Array of objects to bounce
    public static GameObject[] objs;
    //Scales of objects
    public static float[] objSizes;
    public static bool gamePaused;
    public static bool mouseOverObject;

    void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = Screen.currentResolution.refreshRate;

        mySpawnObj = FindObjectOfType<SpawnObject>();

        objs = Resources.LoadAll<GameObject>("Prefabs/FumoPrefabs"); //INSERT PATH OF OBJECT PREFABS;
        objSizes = new float[objs.Length];
        objSizes[0] = 0.5f; //alice
        objSizes[1] = 0.5f; //chen
        objSizes[2] = 0.5f; //cirno
        objSizes[3] = 0.5f; //flandre
        objSizes[4] = 0.65f; //marisa
        objSizes[5] = 0.5f; //patchouli
        objSizes[6] = 0.6f; //ran
        objSizes[7] = 0.5f; //reimu
        objSizes[8] = 0.5f; //remilia
        objSizes[9] = 0.5f; //sakuya
        objSizes[10] = 0.5f; //yukari
    }

    void Update()
    {
        if (!gamePaused)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                mySpawnObj.positionToSpawn = new Vector2(0, 0);
                mySpawnObj.InstantiateObject();
            }
            else if (Input.GetMouseButtonDown(0) && !mouseOverObject && !IsPointerOverUIObject())
            {
                mySpawnObj.positionToSpawn = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mySpawnObj.InstantiateObject();
            }
            
        }

        if (Input.GetKeyDown(KeyCode.C) && !gamePaused)
        {
            mySpawnObj.Clear();
        }
    }

    private void OnApplicationQuit()
    {
        //Resets prefab scales
        for (int i = 0; i < objSizes.Length; i++)
        {
            objs[i].transform.localScale = new Vector3(objSizes[i], objSizes[i], 0f);
        }
    }

    public static bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
}
