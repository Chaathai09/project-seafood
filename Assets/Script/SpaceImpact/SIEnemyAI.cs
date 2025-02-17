using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class SIEnemyAI : MonoBehaviour, CityBombCondition
{
    [SerializeField] float speed;
    [SerializeField] GameObject ammoprefap;
    public float shotDelay;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void EnemyMove()
    {
        this.transform.Translate((Vector2.up * speed) * Time.deltaTime);

        if (this.transform.position.y > 4f && speed >= 0f)
        {
            speed *= -1f;
        }
        if (this.transform.position.y < -4f && speed <= 0f)
        {
            speed *= -1f;
        }
    }

    public void ShotAmmo()
    {
        StartCoroutine(ShotDelay());
    }

    public void IsHit()
    {
        SIGameManager.Instance.AddScore();
    }

    virtual public IEnumerator ShotDelay()
    {
        GameObject temp = Instantiate(ammoprefap, this.transform.position, Quaternion.Euler(0f, 180f, 0f));
        temp.tag = "EnemyObj";
        temp.gameObject.GetComponent<SIAmmo>().ammoFrom = "EnemyObj";
        yield return new WaitForSeconds(shotDelay);
        StartCoroutine(ShotDelay());
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "EnemyObj")
        {
            other.gameObject.GetComponent<CityBombCondition>().IsHit();
        }
    }
}
