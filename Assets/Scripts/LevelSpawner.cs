using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public static bool StartGame = false;
    public GameObject Template;
    public GameObject TemplateEmpty;
    public GameObject SpawnTo;
    private float DistanceTravelled = 0;

    private void Start()
    {
        GameObject Spawned = Instantiate(TemplateEmpty, SpawnTo.transform);
        Spawned.transform.parent = transform;
        SpawnTo.transform.position += new Vector3(0, 0, -9.25f);
        GameObject Spawned1 = Instantiate(TemplateEmpty, SpawnTo.transform);
        Spawned1.transform.parent = transform;
        SpawnTo.transform.position += new Vector3(0, 0, -9.25f);
        GameObject Spawned2 = Instantiate(TemplateEmpty, SpawnTo.transform);
        Spawned2.transform.parent = transform;
        SpawnTo.transform.position += new Vector3(0, 0, -9.25f);
        GameObject Spawned3 = Instantiate(TemplateEmpty, SpawnTo.transform);
        Spawned3.transform.parent = transform;
    }

    public void Update()
    {
        if(BirdMovement.Crashed || !StartGame)
        {
            return;
        }
        transform.position += new Vector3(0, 0, 3 * Time.deltaTime);
        if(transform.position.z - DistanceTravelled >= 9.25)
        {
            DistanceTravelled = transform.position.z;
            GameObject Spawned = Instantiate(Template, SpawnTo.transform);
            Spawned.transform.parent = transform;
        }
    }
    public static void StartGameBtn(){
        StartGame = true;
    }
}