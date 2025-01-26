using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SINEnemyCon : MonoBehaviour, CityBombCondition
{
    public SINEnemyGroupCon enemyGroupCon;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.x >= 8f || this.transform.position.x <= -8f)
        {
            enemyGroupCon.isTimeToFilp = true;
        }
        if (this.transform.position.y <= -3f)
        {
            enemyGroupCon.isRun = false;
            this.enabled = false;
        }
    }

    public void IsHit()
    {
        SINGameManager.Instance.AddScore();
        ParticleManager.Instance.AddParticle(1, this.transform.position);
        Destroy(this.gameObject);
    }
}
