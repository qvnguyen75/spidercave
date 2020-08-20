using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {


	private Transform player;

	public float minX, maxX;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player").transform; // find the player's transform
	}
	
	// Update is called once per frame
	void Update () {
		if(player != null){

			Vector3 temp = transform.position;
			temp.x = player.transform.position.x;

			if(temp.x < minX){
				temp.x = minX;
			}
			if(temp.x > maxX){
				temp.x = maxX;
			}

			temp.y = player.position.y + 2.4f;
			transform.position = temp;
		}
	}
}
