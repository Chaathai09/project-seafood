using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DIALOGUE
{
    public class ConversationManager
    {
        private DialogueSystem dialogueSystem => DialogueSystem.instance;
        private Coroutine process = null;
        private TextArchitect architect = null;
        private bool userPrompt = false;
        public ConversationManager(TextArchitect architect)
        {
            this.architect = architect;
            dialogueSystem.onUserPrompt_Next += OnUserPrompt_Next;
        }
        public bool isRunning => process != null;

        private void OnUserPrompt_Next()
        {
            userPrompt = true;
        }
        public void StartConversation(List<string> conversation)
        {
            StopConversation();
            process = dialogueSystem.StartCoroutine(RunningConversation(conversation));
        }

        public void StopConversation()
        {
            if (!isRunning)
                return;

            dialogueSystem.StopCoroutine(process);
            process = null;
        }

        IEnumerator RunningConversation(List<String> conversation)
        {
            for (int i = 0; i < conversation.Count; i++)
            {
                if (string.IsNullOrWhiteSpace(conversation[i]))
                    continue;
                DIALOGUELINE line = DialogueParser.Parse(conversation[i]);
                if (line.hasDialogue)
                {
                    yield return Line_RunDialogue(line);
                }
                if (line.hasCommands)
                {
                    yield return Line_RunCommands(line);
                }
            }
            yield return new WaitForSeconds(1);
        }

        IEnumerator Line_RunDialogue(DIALOGUELINE line)
        {
            if (line.hasSpeaker)
                dialogueSystem.ShowSpeakerName(line.speaker);
            else
                dialogueSystem.HideSpeakerName();

            yield return BuildLineSegments(line.dialogue);

            //Wait for User Input
            yield return WaitForUserInput();
        }

        IEnumerator BuildDialogue(string dialogue, bool append = false)
        {
            if(!append)
                architect.Build(dialogue);
            else
                architect.Append(dialogue);

            architect.Build(dialogue);
            while (architect.isBuilding)
            {
                if (userPrompt)
                {
                    if (!architect.speedUp)
                        architect.speedUp = true;
                    else
                        architect.ForceComplete();
                    userPrompt = false;
                }
                yield return null;
            }
        }

        IEnumerator BuildLineSegments(DIALOGUEDATA line)
        {
            for (int i = 0; i < line.segments.Count; i++)
            {
                DIALOGUEDATA.DIALOGUE_SEGMENT segment = line.segments[i];
                yield return WaitForDialogueSegmentSignalToBeTriggered(segment);
                yield return BuildDialogue(segment.dialogue, segment.appendText);
            }
        }

        IEnumerator WaitForDialogueSegmentSignalToBeTriggered(DIALOGUEDATA.DIALOGUE_SEGMENT segment)
        {
            switch (segment.startSignal)
            {
                case DIALOGUEDATA.DIALOGUE_SEGMENT.StartSignal.C:
                case DIALOGUEDATA.DIALOGUE_SEGMENT.StartSignal.A:
                    yield return WaitForUserInput();
                    break;
                case DIALOGUEDATA.DIALOGUE_SEGMENT.StartSignal.WC:
                case DIALOGUEDATA.DIALOGUE_SEGMENT.StartSignal.WA:
                    yield return new WaitForSeconds(segment.signalDelay);
                    break;
                default:
                    break;
            }
        }

        IEnumerator Line_RunCommands(DIALOGUELINE line)
        {
            Debug.Log(line.commands);
            yield return null;
        }

        IEnumerator WaitForUserInput()
        {
            while (!userPrompt)
                yield return null;
            userPrompt = false;
        }
    }
}
