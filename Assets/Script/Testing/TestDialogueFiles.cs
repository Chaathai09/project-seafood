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

            //Test Command
            /*foreach(string line in lines){
                if(string.IsNullOrWhiteSpace(line))
                    continue;

                Debug.Log(line);

                DIALOGUELINE dl = DialogueParser.Parse(line);
                for(int i = 0; i < dl.commandData.commands.Count ; i++){
                    COMMANDDATA.Command command = dl.commandData.commands[i];
                    Debug.Log($"Command [{i}] '{command.name}' has arguments [{string.Join(", ", command.arguments)}]");
                }
            }*/

            /*for(int i = 0; i < lines.Count; i++){
                string line = lines[i];

                if(string.IsNullOrWhiteSpace(line))
                    continue;

                DIALOGUELINE dl = DialogueParser.Parse(line);

                Debug.Log($"{dl.speaker.name} as [{(dl.speaker.displayName)}] IS MC? {dl.speaker.isMC}");

                List<(int l, string ex)> expr = dl.speaker.CastExpressions;
                for(int c = 0 ; c < expr.Count; c++){
                    Debug.Log($"[Layer[{expr[c].l}] = '{expr[c].ex}']");
                }
            }*/

            /*foreach(string line in lines){
                if(string.IsNullOrEmpty(line))
                    continue;

                Debug.Log($"Segmenting Line: '{line}'");
                DIALOGUELINE dlLine = DialogueParser.Parse(line);

                int i = 0;
                foreach(DIALOGUEDATA.DIALOGUE_SEGMENT segment in dlLine.dialogue.segments){
                    Debug.Log($"Segment [{i++}] = '{segment.dialogue}' [signal={segment.startSignal.ToString()}{(segment.signalDelay > 0 ? $" { segment.signalDelay}" : $"")}]");
                }
            }*/

            //DialogueSystem.instance.Say(lines);
        }
}
