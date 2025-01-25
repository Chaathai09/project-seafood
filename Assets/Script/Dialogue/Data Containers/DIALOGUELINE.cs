using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DIALOGUE
{
    public class DIALOGUELINE
    {
        public SPEAKERDATA speaker;
        public DIALOGUEDATA dialogue;
        public COMMANDDATA commandData;
        public bool hasSpeaker => speaker != null;
        public bool hasDialogue => dialogue != null;
        public bool hasCommands => commandData != null;

        public DIALOGUELINE(string speaker, string dialogue, string commands){
            this.speaker = (string.IsNullOrWhiteSpace(speaker) ? null: new SPEAKERDATA(speaker));
            this.dialogue = (string.IsNullOrWhiteSpace(dialogue) ? null: new DIALOGUEDATA(dialogue));
            this.commandData = (string.IsNullOrWhiteSpace(commands) ? null: new COMMANDDATA(commands));
        }
    }
}
