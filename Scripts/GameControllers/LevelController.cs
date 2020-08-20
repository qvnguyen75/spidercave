using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour {

	public void PlayGame ()
	{
		SceneManager.LoadScene(2);

	}

	public void LoadLevelMenu ()
	{
		SceneManager.LoadScene(1);

	}


	public void BackToMenu ()
	{
		SceneManager.LoadScene(0);

	}
}
