using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerCon : MonoBehaviour
{
    GameObject siPlayer;
    [SerializeField] float speed;

    private void Awake()
    {
        siPlayer = this.gameObject;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        siPlayer.transform.Translate(new Vector2((Input.GetAxisRaw("Horizontal") * speed) * Time.deltaTime, 0f));
    }
}
