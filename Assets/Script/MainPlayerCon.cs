using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DIALOGUE;
using Unity.VisualScripting;

public class MainPlayerCon : MonoBehaviour
{
    GameObject player;
    public float InputCooldown = 2f;
    private float nextAllowedTime = 0f;
    [SerializeField] Animator animator;
    [SerializeField] float speed;
    [SerializeField] GameObject sprite;
    [SerializeField] EventColliderTrigger eventColliderTrigger;
    [SerializeField] GameObject transitionScene;
    [SerializeField] GameObject dialogueBox;
    private bool isFacingRight = true;
    private bool isOverrideInteract = false;
    private void Awake()
    {
        player = this.gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isOverrideInteract = !dialogueBox.activeSelf;
        if (isOverrideInteract)
        {
            Interact();
            Move();
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                PromptAdvance();
            }
        }
    }

    void Move()
    {
        float movement = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        player.transform.Translate(new Vector2(movement, 0f));

        animator.SetBool("IsMove", Mathf.Abs(movement) > 0 ? true : false);

        if (movement > 0 && !isFacingRight)
            Flip();
        else if (movement < 0 && isFacingRight)
            Flip();
    }

    void Interact()
    {
        if (Time.time >= nextAllowedTime)
        {
            if (Input.GetKeyUp(KeyCode.Z))
            {
                if (eventColliderTrigger.triggerTag == "Seat")
                {
                    if (!transitionScene.activeSelf)
                    {
                        transitionScene.SetActive(true);
                        isOverrideInteract = true;
                    }
                }
                else if (eventColliderTrigger.triggerTag == "NPC")
                {
                    isOverrideInteract = false;
                    NPCDataController currentNPC = eventColliderTrigger.thisNpcData;
                    if (currentNPC != null)
                    {
                        //Debug.Log(currentNPC.gameObject.name);
                        if (!currentNPC.isTalkInThisLevel)
                        {
                            currentNPC.isTalkInThisLevel = true;
                            Talk(currentNPC.NPCDialogues[0].fileToRead);
                        }
                    }
                }
                nextAllowedTime = Time.time + InputCooldown;
            }

        }
    }

    void Talk(TextAsset dialogue)
    {
        dialogueBox.SetActive(true);
        List<string> lines = FileManager.ReadTextAsset(dialogue);

        DialogueSystem.instance.Say(lines);
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = sprite.transform.localScale;
        scale.x *= -1;
        sprite.transform.localScale = scale;
    }

    public void PromptAdvance()
    {
        DialogueSystem.instance.OnUserPrompt_Next();
    }
}
