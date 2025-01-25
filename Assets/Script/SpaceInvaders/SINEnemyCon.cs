using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SINEnemyCon : MonoBehaviour, CityBombCondition
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IsHit()
    {
        SINGameManager.Instance.AddScore();
        Destroy(this.gameObject);
    }
}
