using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileCon : MonoBehaviour
{
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate((Vector2.up * speed) * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<CityBombCondition>().IsHit();
        Destroy(this.gameObject);
    }
}
