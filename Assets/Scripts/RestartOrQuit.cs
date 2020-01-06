using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//更换场景

public class RestartOrQuit : MonoBehaviour {

	// Use this for initialization
	public void Restart () {
        SceneManager.LoadScene("MainScene");
	}
	
	// Update is called once per frame
	public void QuitGame () {
        Application.Quit();
	}
}
