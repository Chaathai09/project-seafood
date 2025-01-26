using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DIALOGUE;

public class GameManager : MonoBehaviour
{
    public List<GameObject> NPCPrefabs = new List<GameObject>();
    public GameInfoObj gameInfo;
    public GameObject dialogueBox;
    public TextAsset intro;
    bool isLevelSuccess;
    // Start is called before the first frame update
    void Awake()
    {
        NPCPrefabs.Clear();
        foreach(GameObject onj in GameObject.FindWithTag("NPC").GetComponent<GameObject>()){

        }
        OnNewLevel();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnNewLevel()
    {
        AudioManager.Instance.PlaySFX(0);
        if (!gameInfo.isPlayIntro)
        {
            dialogueBox.SetActive(true);
            List<string> lines = FileManager.ReadTextAsset(intro);

            DialogueSystem.instance.Say(lines);
            gameInfo.isPlayIntro = true; ;
        }

        for(int i = 0;i < NPCPrefabs.Length;i++){
            NPCDataController npc = NPCPrefabs[i].GetComponent<NPCDataController>();
            npc.isTalkInThisLevel = false;
        }
    }
}
