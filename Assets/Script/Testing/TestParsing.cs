using System.Collections;
using System.Collections.Generic;
using DIALOGUE;
using UnityEngine;

namespace TESTING
{
    public class TestParsing : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            /*string line = "Speaker \"Dialogue \\\"Goes\\\" in Here!\" Command(arguments here)";
            DialogueParser.Parse(line);*/
            SendFiletoParse();
        }

        // Update is called once per frame
        void SendFiletoParse()
        {
            List<string> lines = FileManager.ReadTextAsset("testFile",false);
            foreach(string line in lines){
                DIALOGUELINE dl = DialogueParser.Parse(line);
            }
        }
    }
}
