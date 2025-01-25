using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSGameManager : MonoBehaviour
{
    static public MSGameManager Instance;
    [SerializeField] GameObject meteorPrefap;
    [SerializeField] float spawnDelay;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartInvoke()
    {
        InvokeRepeating("SpawnMeteor", 0f, spawnDelay);
    }
    public void StopInvoke()
    {
        CancelInvoke();
    }

    public void SpawnMeteor()
    {
        GameObject temp = Instantiate(meteorPrefap, new Vector2(Random.Range(-6f, 6f), 8f), Quaternion.identity);
        float randomSize = Random.Range(1f, 5f);
        temp.GetComponent<MeteorCon>().SetMeteor(randomSize);
    }
}
