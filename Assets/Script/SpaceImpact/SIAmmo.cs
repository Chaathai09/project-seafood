using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SIAmmo : MonoBehaviour, CityBombCondition
{
    [SerializeField] float speed;
    public string ammoFrom;    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Translate((Vector2.right * speed) * Time.deltaTime);

        if (this.transform.position.x >= 10f || this.transform.position.x <= -10f)
            Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != ammoFrom)
        {
            other.gameObject.GetComponent<CityBombCondition>().IsHit();
            Destroy(this.gameObject);
        }
    }

    public void IsHit()
    {

    }
}
