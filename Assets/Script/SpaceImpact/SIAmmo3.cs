using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SIAmmo3 : MonoBehaviour, CityBombCondition
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "EnemyObj")
        {
            other.gameObject.GetComponent<CityBombCondition>().IsHit();
            // Destroy(this.gameObject);
        }
    }
    public void IsHit()
    {

    }
}
