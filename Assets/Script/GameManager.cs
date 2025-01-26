using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject UICanvas;
    public GameObject[] NPCPrefabs = new GameObject[5];
    bool isLevelSuccess;
    // Start is called before the first frame update
    void Start()
    {
        OnNewLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnNewLevel(){
        AudioManager.Instance.PlaySFX(0);
    }
}
