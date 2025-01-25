using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityBombBuilding : MonoBehaviour
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
        // Debug.Log("is hit");
        other.gameObject.GetComponent<CityBombCondition>().IsHit();
        OnHit();
    }

    void OnHit()
    {
        //play ani
        CitybombGameManager.Instance.AddScore();
        ParticleManager.Instance.AddParticle(0, this.transform.position);
        Destroy(this.gameObject);
    }
}
