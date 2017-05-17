using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneAfterClick : MonoBehaviour {

	// public string StringName;
	// Use this for initialization
	public void ChangeScene (string StringName) {
		Application.LoadLevel(StringName);
	}
}
