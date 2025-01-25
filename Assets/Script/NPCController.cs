using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NPCController : MonoBehaviour
{
    public GameObject[] NPCPrefabs = new GameObject[4];
    public List<Transform> spawnLocations = new List<Transform>();
    private List<Transform> locationTemp;
    // Start is called before the first frame update
    void Start()
    {
        SpawnNPC();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnNPC(){
        locationTemp = spawnLocations;
        foreach(GameObject obj in NPCPrefabs){
            int spawnIndex = Random.Range(0,locationTemp.Count);
            GameObject NPC = Instantiate(obj);
            NPC.GetComponent<Transform>().position = new Vector2(locationTemp[spawnIndex].position.x,NPC.GetComponent<Transform>().position.y);
            Vector3 scale = NPC.GetComponent<Transform>().localScale;
            scale.x *= Random.Range(0,2) == 0? -1:1;
            NPC.GetComponent<Transform>().localScale = scale;

            NPC.GetComponent<Transform>().GetChild(0).GetComponent<Animator>().SetBool("isSit",Random.Range(0,2) == 0? true:false);

            locationTemp.RemoveAt(spawnIndex);
        }
    }

}
