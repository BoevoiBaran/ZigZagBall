using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleSystem : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps;

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if(!ps.isPlaying)
        {
            Destroy(gameObject);
        }
    }

}
