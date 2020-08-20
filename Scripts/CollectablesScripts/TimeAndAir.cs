using System.Collections;
using System.Collections.Generic;
using UnityEngine;	

public class TimeAndAir : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D target)
	{
		if (target.tag == "Player") {
			if (gameObject.tag == "Air") {
				GameObject.Find ("GameplayController").GetComponent<AirTimer> ().air += 5f;
			} else {
				GameObject.Find ("GameplayController").GetComponent<LevelTimer> ().time += 5f;
			}
			Destroy(gameObject);
		}
	} 
}
