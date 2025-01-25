using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorCon : MonoBehaviour, CityBombCondition
{
    [SerializeField] float speed;
    [SerializeField] int hp;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate((Vector2.down * speed) * Time.deltaTime);
    }

    public void SetMeteor(float size)
    {
        this.transform.localScale = new Vector3(size, size, size);
        hp = (int)Mathf.Round(hp * size);
        speed /= size;
    }

    public void IsHit()
    {
        RemoveHP();
    }

    void RemoveHP()
    {
        hp--;
        if (hp <= 0)
            Destroy(this.gameObject);
    }
}
