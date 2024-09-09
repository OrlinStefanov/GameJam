using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class Movement : MonoBehaviour
{
    [Header("Player")]
    public GameObject cam;
    public float speed;
    public float jump_hight;

    private CharacterController controller;
    private Vector3 velocity;
    private float gravity = -9.81f;

    private bool is_water = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

	bool IsUnderwater()
	{
		return transform.position.y < 18;
	}

	void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space))
        {
            velocity.y -= jump_hight * Time.deltaTime;
        }

        if (!IsUnderwater())
        {
            if (!is_water) { velocity.y = 0; is_water = true; }

			velocity.y += gravity * Time.deltaTime;
			controller.Move(velocity * Time.deltaTime);
		} else
        {
            is_water = false;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                velocity.y += gravity * Time.deltaTime;
				controller.Move(velocity / 10 * Time.deltaTime);
			} else
            {
				if (cam.transform.localRotation.x < -0.2 || cam.transform.localRotation.x > 0.2)
				{
					if (cam.transform.localRotation.x > -0.7)
					{
						velocity.y += gravity * Time.deltaTime;
					}
					else if (cam.transform.localRotation.x < 0.7)
					{
						velocity.y -= gravity * Time.deltaTime;
					}

					controller.Move(velocity / 100 * Time.deltaTime);
				}
			}            
		}
    }
}