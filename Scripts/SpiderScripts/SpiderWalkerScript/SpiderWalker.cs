using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWalker : MonoBehaviour {

	public float speed = 1f;

	private Rigidbody2D rb;

	[SerializeField]
	private Transform startPos, endPos;

	private bool collision;

	void Awake(){
		rb = GetComponent<Rigidbody2D>();
	}
	

	void FixedUpdate () {
		Move();
		ChangeDirection();
	}

	void Move (){
	rb.velocity = new Vector2(transform.localScale.x, 0) * speed;
	}

	void ChangeDirection (){
		collision = Physics2D.Linecast (startPos.position, endPos.position, 1 << LayerMask.NameToLayer ("Ground")); // get the collision between spiderwalker and ground

		Debug.DrawLine(startPos.position, endPos.position, Color.green);

		if (!collision) {
			Vector3 temp = transform.localScale;
			if (temp.x == 1f) {
				temp.x = -1f;
			} else {
				temp.x = 1f;
			}
			transform.localScale = temp;
		}
	}

	void OnCollisionEnter2D(Collision2D target){
		if(target.gameObject.tag == "Player"){
			Destroy(target.gameObject);
		}
	}



}
