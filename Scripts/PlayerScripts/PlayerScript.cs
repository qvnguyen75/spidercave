using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public float moveForce = 20f, jumpForce = 700f, maxVelocity = 4f;

	private Rigidbody2D rb;
	private Animator anim;
	private bool grounded = true;


	void Awake () {
		InitializeVariables();
	}
	

	void FixedUpdate () {
		PlayerWalkKeyboard();
	}	


	void InitializeVariables(){
		rb = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}


	void PlayerWalkKeyboard ()
	{

		float forceX = 0f;
		float forceY = 0f;
		float vel = Mathf.Abs (rb.velocity.x);
		float h = Input.GetAxisRaw ("Horizontal");

		if (h > 0) { // if moving right
			if (vel < maxVelocity) { //here comes the speed
				if (grounded) {
					forceX = moveForce;
				} else { // some controle while in the air
					forceX = moveForce * 1.1f;
				}
			}

			Vector3 scale = transform.localScale;
			scale.x = 1f;
			transform.localScale = scale;
			anim.SetBool("IsWalking", true);

		} else if(h < 0){

			if (vel < maxVelocity) { //here comes the speed

				if (grounded) {
					forceX = -moveForce;
				} else { // add some more control while in the air
					forceX = -moveForce * 1.1f;
				}
			}

			Vector3 scale = transform.localScale;
			scale.x = -1f;
			transform.localScale = scale;
			anim.SetBool("IsWalking", true);

		}


		else if(h == 0){ //
			anim.SetBool("IsWalking", false);
		}

		if(Input.GetKey(KeyCode.Space)){
			if(grounded){
				grounded = false;
				forceY = jumpForce;
			}
		}


		rb.AddForce(new Vector2(forceX, forceY));

	}

	void OnCollisionEnter2D (Collision2D target){
		if(target.gameObject.tag == "Ground"){
			grounded = true;
		}
	}


	public void BouncePlayerWithBouncy (float force)
	{
		if(grounded){
			grounded = false;
			rb.AddForce(new Vector2(0,force));
		}
	}













	/*public void Jump(){
		if(grounded){
			grounded = false;
			rb.AddForce(new Vector2(0, jumpForce));
		}
	}*/


}















































