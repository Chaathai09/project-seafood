using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DIALOGUE;

public class MainPlayerCon : MonoBehaviour
{
    GameObject player;
    [SerializeField] Animator animator;
    [SerializeField] float speed;
    [SerializeField] SpriteRenderer spriteRenderer;
    private bool isFacingRight = true;

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
        float movement = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
        player.transform.Translate(new Vector2(movement, 0f));

        animator.SetBool("IsMove",Mathf.Abs(movement) > 0? true:false );
        
        if(movement > 0 && !isFacingRight)
            Flip();
        else if(movement < 0 && isFacingRight)
            Flip();

        if(Input.GetKeyDown(KeyCode.Z)){
            PromptAdvance();
        }
        
    }

    void Flip(){
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void PromptAdvance(){
        DialogueSystem.instance.OnUserPrompt_Next();
    }
}
