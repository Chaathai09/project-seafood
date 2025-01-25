using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SIEnemyAI2 : SIEnemyAI
{
    [SerializeField] GameObject ammo, ammoWan;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    override public IEnumerator ShotDelay()
    {
        yield return new WaitForSeconds(shotDelay);

        StartCoroutine(ShotWaning());
    }

    IEnumerator ShotWaning()
    {
        ammoWan.SetActive(true);
        yield return new WaitForSeconds(1f);
        ammoWan.SetActive(false);
        ammo.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        ammo.SetActive(false);
        
        StartCoroutine(ShotDelay());
    }
}
