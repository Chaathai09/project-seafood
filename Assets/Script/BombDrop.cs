using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDrop : MonoBehaviour
{
    [SerializeField] float speed;

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate((Vector2.down * speed) * Time.deltaTime);

        if (this.transform.position.y <= -5f)
            Destroy(this.gameObject);
    }
}
