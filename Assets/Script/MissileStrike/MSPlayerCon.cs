using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MSPlayerCon : MonoBehaviour
{
    [SerializeField] float turnSpeed;
    [SerializeField] GameObject missilePrefap, missileSpawnPoint;
    [SerializeField] float deleyTime;
    bool canShot = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(new Vector3(0f, 0f, Input.GetAxisRaw("Horizontal")), -turnSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Z) && canShot)
        {
            canShot = false;
            StartCoroutine(ShotAmmo());
        }
    }

    IEnumerator ShotAmmo()
    {
        Instantiate(missilePrefap, missileSpawnPoint.transform.position, this.transform.rotation);
        yield return new WaitForSeconds(deleyTime);
        canShot = true;
    }
}
