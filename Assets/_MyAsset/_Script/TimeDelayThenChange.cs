using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeDelayThenChange : MonoBehaviour {

	public float TimeDelay; 
	// Use this for initialization
	void Start () {
		StartCoroutine(ExecuteAfterTime(TimeDelay));
	}
	
	IEnumerator ExecuteAfterTime(float time)
	 {
	     yield return new WaitForSeconds(time);
	 
	     // Code to execute after the delay
	     Application.LoadLevel("Scene2");
	 }
}
