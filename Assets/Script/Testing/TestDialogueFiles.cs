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
            foreach(string line in lines){
                if(string.IsNullOrEmpty(line))
                    continue;

                Debug.Log($"Segmenting Line: '{line}'");
                DIALOGUELINE dlLine = DialogueParser.Parse(line);

                int i = 0;
                foreach(DIALOGUEDATA.DIALOGUE_SEGMENT segment in dlLine.dialogue.segments){
                    Debug.Log($"Segment [{i++}] = '{segment.dialogue}' [signal={segment.startSignal.ToString()}{(segment.signalDelay > 0 ? $" { segment.signalDelay}" : $"")}]");
                }
            }
            DialogueSystem.instance.Say(lines);
        }
}
