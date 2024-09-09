using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    [Header("Gun")]
    public float damage = 20f;
    public float range = 100f;

    public Camera cam;
    public ParticleSystem particle;

    void Start()
    {
        particle.Stop();
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;

        particle.Play();

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {

        }
    }
}
