using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DIALOGUE
{
    public class DIALOGUELINE
    {
        public string speaker;
        public DIALOGUEDATA dialogue;
        public string commands;
        public bool hasSpeaker => speaker != string.Empty;
        public bool hasDialogue => dialogue.hasDialogue;
        public bool hasCommands => commands != string.Empty;

        public DIALOGUELINE(string speaker, string dialogue, string commands){
            this.speaker = speaker;
            this.dialogue = new DIALOGUEDATA(dialogue);
            this.commands = commands;
        }
    }
}
