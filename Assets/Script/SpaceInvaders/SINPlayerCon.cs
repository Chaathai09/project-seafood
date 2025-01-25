using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SINPlayerCon : MonoBehaviour
{
    [SerializeField] float speed;
    Transform tempPos;
    [SerializeField] GameObject ammoprefap;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tempPos = this.transform;
        tempPos.Translate(new Vector2(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0f));
        tempPos.position = new Vector2(Mathf.Clamp(tempPos.position.x, -8.5f, 8.5f), tempPos.position.y);
        this.transform.position = tempPos.position;

        if (Input.GetKeyDown(KeyCode.Z))
        {
            ShotAmmo();
        }
    }

    void ShotAmmo()
    {
        Instantiate(ammoprefap, this.transform.position, Quaternion.identity);
    }
}
