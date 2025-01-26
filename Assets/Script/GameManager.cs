using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DIALOGUE;

public class GameManager : MonoBehaviour
{
    public GameInfoObj gameInfo;
    public GameObject dialogueBox;
    public GameObject endScene;
    public TextAsset intro;
    bool isLevelSuccess;
    // Start is called before the first frame update
    void Awake()
    {
        if(gameInfo.currentLevel > 5){
            endScene.SetActive(true);
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

        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("NPC")){
            NPCDataController npc = obj.GetComponent<NPCDataController>();
            npc.isTalkInThisLevel = false;
        }
    }
}
