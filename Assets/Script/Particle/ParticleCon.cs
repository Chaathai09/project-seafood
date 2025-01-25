using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCon : MonoBehaviour
{
    public void OnEndAni()
    {
        Destroy(this.gameObject);
    }
}
