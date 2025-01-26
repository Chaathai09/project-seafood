using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDataController : MonoBehaviour
{
    public List<NPCDialogue> NPCDialogues = new List<NPCDialogue>();
    // Start is called before the first frame update
    public bool isTalkInThisLevel = false;

    [System.Serializable]
    public struct NPCDialogue{
        public TextAsset fileToRead;
        public bool isRead;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
