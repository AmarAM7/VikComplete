using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarbarianBehaviour : MonoBehaviour
{
	public Transform player;
	public float MoveSpeed = 4;
	public float attackDistance = 1.3f;
	public float jumpDistance = 1.3f;
	public float chaseDistance = 1.3f;

	private Animator myAnimator;
	private CharacterController controller;

	bool isGrounded = true;
	private float verticalVel;
	private Vector3 moveVector;

	void Start()
	{
		myAnimator = GetComponent<Animator>();
		controller = GetComponent<CharacterController>();
		player = GameObject.FindGameObjectWithTag("Player").transform;
		//StartCoroutine(GoLeft());
	}

	void Update()
	{
		transform.LookAt(player);

		//If you don't need the character grounded then get rid of this part.
		isGrounded = controller.isGrounded;
		if (isGrounded)
		{
			verticalVel -= 0;
		}
		else
		{
			verticalVel -= .05f * Time.deltaTime;
		}
		moveVector = new Vector3(0, verticalVel, 0);
		controller.Move(moveVector);


		if (!isGrounded)
		{
			transform.Translate(new Vector3(0f, -10f, 0f) * Time.deltaTime);
		}

		if (Vector3.Distance(transform.position, player.position) >= chaseDistance)
		{
			transform.position += transform.forward * MoveSpeed * Time.deltaTime;
			myAnimator.SetBool("walking", true);

		}
		else
		{
			if (Vector3.Distance(transform.position, player.position) <= chaseDistance)
			{
				myAnimator.SetBool("walking", false);
			}

		}


		if (Vector3.Distance(transform.position, player.position) <= attackDistance)
		{

			myAnimator.SetBool("isAttacking", true);
		}
		else
		{
			
			myAnimator.SetBool("IsAttacking", false);
		}
	}


	/*IEnumerator GoLeft()
	{
		// This will wait 1 second like Invoke could do, remove this if you don't need it
		yield return new WaitForSeconds(10);


		float timePassed = 0;
		while (timePassed < 3)
		{
			// Code to go left here
			timePassed += Time.deltaTime;

			yield return null;
		}
	}*/
}
