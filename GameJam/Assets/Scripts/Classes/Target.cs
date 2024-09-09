using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
	public float health;

	public void Hit(float damage)
	{
		health -= damage;
	}

	public void Die()
	{
		Destroy(gameObject);
	}
}
