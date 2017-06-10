using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalMenuEnableDisable : MonoBehaviour {

	private string CurrentScene;
	public GameObject[] btnDisable;
	public GameObject[] btnEnable;

	// Use this for initialization
	void Start () {
		Scene scene = SceneManager.GetActiveScene();
		Debug.Log("Active scene is '" + scene.name + "'.");
		DisableAll ();
		if(scene.name == "Scene3_Calendar"){
			btnEnable [1].SetActive (true);
			btnDisable [1].SetActive (false);
		}

		if(scene.name == "Scene4_Account"){
			btnEnable [0].SetActive (true);
			btnDisable [0].SetActive (false);
		}

		if(scene.name == "Scene5_Search"){
			btnEnable [2].SetActive (true);
			btnDisable [2].SetActive (false);
		}

		if(scene.name == "Scene6_Notification"){
			btnEnable [3].SetActive (true);
			btnDisable [3].SetActive (false);
		}
	}

	void DisableAll(){
		btnDisable [0].SetActive (true);
		btnDisable [1].SetActive (true);
		btnDisable [2].SetActive (true);
		btnDisable [3].SetActive (true);

		btnEnable [0].SetActive (false);
		btnEnable [1].SetActive (false);
		btnEnable [2].SetActive (false);
		btnEnable [3].SetActive (false);

	}
}
