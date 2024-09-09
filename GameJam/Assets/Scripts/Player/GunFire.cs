using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFire : MonoBehaviour
{
    [Header("Gun")]
    public GameObject pistol;
    public Animator animator;
    public float damage = 20f;
    public float range = 100f;
    public bool is_pistol = false;

    public Camera cam;
    public ParticleSystem particle;
    public ParticleSystem hit_particle;

    void Start()
    {
        particle.Stop();
    }

    void Update()
    {
        if (is_pistol)
        {
			if (Input.GetMouseButtonUp(0))
			{
				if (pistol.activeSelf) Shoot();
			}

			if (Input.GetKey(KeyCode.R) && !animator.GetCurrentAnimatorStateInfo(0).IsName("reload"))
			{
				animator.Play("reload");
			}

			if (Input.GetMouseButtonDown(1) && !animator.GetCurrentAnimatorStateInfo(0).IsName("reload"))
			{
				animator.Play("zoom");
			}

			if (Input.GetMouseButtonUp(1))
			{
				animator.Play("Idle");
			}
		}
    }

    private void Shoot()
    {
        RaycastHit hit;

        particle.Play();

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            var z = Instantiate(hit_particle, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(z.gameObject, 2);
        }
    }
}
