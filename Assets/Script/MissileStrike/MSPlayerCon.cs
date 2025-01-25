using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSPlayerCon : MonoBehaviour
{
    [SerializeField] float turnSpeed;
    [SerializeField] GameObject missilePrefap, missileSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(0f, 0f, Input.GetAxisRaw("Horizontal")), -turnSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Z))
        {
            ShotAmmo();
        }
    }

    void ShotAmmo()
    {
        Instantiate(missilePrefap, missileSpawnPoint.transform.position, this.transform.rotation);
    }
}
