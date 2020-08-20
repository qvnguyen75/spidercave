using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelTimer: MonoBehaviour {

	private Slider slider;

	private GameObject player;

	public float time = 10f;

	private float timeBurn = 1f;

	void Awake ()
	{
		GetReferences();

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!player) {
			return;
		}
		if (time > 0) {
			time -= timeBurn * Time.deltaTime;
			slider.value = time;
		} else {
			GetComponent<GameplayController>().PlayerDied();
			Destroy(player);
		}
	}




	// Get references of player and slider
	void GetReferences(){
		player = GameObject.Find("Player");
		slider = GameObject.Find("TimeSlider").GetComponent<Slider>();

		slider.minValue = 0f;
		slider.maxValue = time;
		slider.value = slider.maxValue;


	}
}
