using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SIAmmo : MonoBehaviour
{
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate((Vector2.right * speed) * Time.deltaTime);

        if (this.transform.position.x >= 10f)
            Destroy(this.gameObject);
    }
}
