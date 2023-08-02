using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SpawnTubes : MonoBehaviour
{
    public GameObject Tubes;
    public GameObject Spawner1,Spawner2;
    public GameObject[] soundPrefabs;
    public string[] texts;
    private void Start()
    {
        float RandomFloat1 = Random.Range(-1.85f,-0.75f);
        Spawner1.transform.position = new Vector3(Spawner1.transform.position.x, RandomFloat1, Spawner1.transform.position.z);
        GameObject tube1 = Instantiate(Tubes, Spawner1.transform);
        UpdateText(tube1);
        float RandomFloat2 = Random.Range(-1.85f,-0.75f);
        Spawner2.transform.position = new Vector3(Spawner2.transform.position.x, RandomFloat2, Spawner2.transform.position.z);
        GameObject tube2 = Instantiate(Tubes, Spawner2.transform);
        UpdateText(tube2);
    }

    private void UpdateText(GameObject obstacle)
    {
        int randomIndex = Random.Range(0, texts.Length);
        obstacle.transform.GetChild(2).GetComponent<TMPro.TextMeshPro>().text = texts[randomIndex];
        GameObject soundPrefab = soundPrefabs[randomIndex];
        GameObject sound = Instantiate(soundPrefab, obstacle.transform.GetChild(1).GetChild(2));
    }
}
