using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    public static ParticleManager Instance;
    [SerializeField] List<GameObject> particleList = new();

    private void Awake()
    {
        Instance = this;
    }

    public void AddParticle(int particleIndex, Vector2 position)
    {
        GameObject go = Instantiate(particleList[particleIndex], position, Quaternion.identity);
        go.transform.SetParent(this.transform);
    }
}
