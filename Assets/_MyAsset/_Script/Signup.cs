using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Signup : MonoBehaviour {
	public Text FIRST_NAME,LAST_NAME,EMAIL,PASSWORD;
	public void SignupFunction(){
		print ("Scene2_Signup");
		GlobalVariable.FIRST_NAME = FIRST_NAME.text; 
		GlobalVariable.LAST_NAME = LAST_NAME.text;
		GlobalVariable.EMAIL = EMAIL.text;
		GlobalVariable.PASSWORD = PASSWORD.text;
		Application.LoadLevel ("Scene2_Registration");
	}
}
