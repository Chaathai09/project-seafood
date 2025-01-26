using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  DIALOGUE;
using Unity.VisualScripting;

public class TestDialogueFiles : MonoBehaviour
{
    [SerializeField] private TextAsset fileToRead = null;
        void Start()
        {

            StartConversation();
        }
        void StartConversation()
        {
            List<string> lines = FileManager.ReadTextAsset(fileToRead);

            DialogueSystem.instance.Say(lines);
        }
}
