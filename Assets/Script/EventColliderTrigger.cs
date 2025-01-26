using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventColliderTrigger : MonoBehaviour
{
    [SerializeField] GameObject textBalloon;
    [SerializeField] GameObject timeBalloon;
    public string triggerTag = "";
    public NPCDataController thisNpcData;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "NPC")
        {
            triggerTag = "NPC";
            thisNpcData = other.gameObject.transform.parent.gameObject.GetComponent<NPCDataController>();
            //Debug.Log(other.gameObject.transform.parent.gameObject.name);
            timeBalloon.SetActive(false);
            textBalloon.SetActive(true);
        }
        if (other.tag == "Seat")
        {
            triggerTag = "Seat";
            timeBalloon.SetActive(true);
            textBalloon.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        triggerTag = "";
        thisNpcData = null;
        timeBalloon.SetActive(false);
        textBalloon.SetActive(false);
    }
}
