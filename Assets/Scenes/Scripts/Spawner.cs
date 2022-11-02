using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject AIPrefab;
    public int AIToSpawn;
    [SerializeField]
    private List<GameObject> NPCs = new List<GameObject>();
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private Waypoint MallEntrance;
    [SerializeField]
    private float RoundTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("NPCSpawn");
    }

    IEnumerator NPCSpawn()
    {
        yield return new WaitForSeconds(RoundTime);
        int val = Random.Range(0, 10);
        if (val <= 3)
        {
            SpawnEnemy();
        }
        else
        {
            SpawnNPC();
        }
    }

    void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemy);
        Waypoint Pos = MallEntrance;
        newEnemy.transform.position = Pos.GetPosition();//Pos.transform.position;
        newEnemy.GetComponent<WaypointNavigation>().currentWaypoint = Pos;
        StartCoroutine("NPCSpawn");
    }

    void SpawnNPC()
    {
        GameObject NPC = Instantiate(NPCs[Random.Range(0, NPCs.Count)]);
        Waypoint Pos = MallEntrance;
        NPC.transform.position = Pos.GetPosition();//Pos.transform.position;
        NPC.GetComponent<WaypointNavigation>().currentWaypoint = Pos;
        StartCoroutine("NPCSpawn");
    }

    /*IEnumerator Spawn()
    {
        int count = 0;
        while (count < AIToSpawn)
        {

            GameObject obj = Instantiate(AIPrefab);
            Transform child = transform.GetChild(Random.Range(0, transform.childCount - 1));
            obj.GetComponent<WaypointNavigation>().currentWaypoint = child.GetComponent<Waypoint>();
            obj.transform.position = child.position;

            yield return new WaitForEndOfFrame();

            count++;

        }
    }*/
}
