using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
	public Transform player;
	public float MoveSpeed = 4;
	public int MaxDist = 10;
	public int MinDist = 5;
	public int MinDistance = 2;

	private Animator myAnimator;
	private CharacterController controller;

	bool isGrounded = true;
	private float verticalVel;
	private Vector3 moveVector;

	void Start()
    {
		myAnimator = GetComponent<Animator>();
		controller = GetComponent<CharacterController>();
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

		if (Vector3.Distance(transform.position, player.position) >= MinDist)
		{
			transform.position += transform.forward * MoveSpeed * Time.deltaTime;
			myAnimator.SetBool("jumping", true);

		}
		else
        {
			if (Vector3.Distance(transform.position, player.position) <= MaxDist)
            {
				myAnimator.SetBool("jumping", false);
			}
				
		}


		if (Vector3.Distance(transform.position, player.position) <= MinDistance)
		{

			myAnimator.SetBool("attacking", true);
		}
		else
		{
			
			myAnimator.SetBool("attacking", false);
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

