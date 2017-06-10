using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Security;
using System.Collections;

public class RegisterPhp : MonoBehaviour {
	private string SecretKey = "123456";
	private string RegisterPHP_Url = "http://immersivemedia.ph/bookmdphp/bl_Register.php";
	private bool isRegister = true;
	private string 	FACEBOOK_ID,FIRST_NAME, LAST_NAME,EMAIL,PASSWORD;


	// Use this for initialization
	void Start () {

		//StartCoroutine(RegisterProcess());
		//		Debug.Log ("Nice Zero");
	}

	void Update(){
		FACEBOOK_ID = GlobalVariable.FACEBOOK_ID;
		FIRST_NAME =  GlobalVariable.FIRST_NAME;
		LAST_NAME =  GlobalVariable.LAST_NAME;
		EMAIL = GlobalVariable.EMAIL;
		PASSWORD = GlobalVariable.PASSWORD;
		if(FACEBOOK_ID != null){
			PASSWORD = "";
		}

		if (isRegister == true && FIRST_NAME != null&& LAST_NAME != null&& PASSWORD != null) {
			if(EMAIL == null){
				EMAIL = "";
			}
			if(FACEBOOK_ID == null){
				FACEBOOK_ID = "";
			}
			StartCoroutine (RegisterProcess ());
		} else{
			//Debug.Log ("Not Yet....");
		}
	}

	IEnumerator RegisterProcess()
	{
		//		if (isRegister)
		//			yield return null;

		yield return new WaitForSeconds(5);
		//isRegister = true;
		//		bl_LoginManager.UpdateDescription("Registering...");
		Debug.Log ("Registering...");
		//Used for security check for authorization to modify database
		string hash = Md5Sum(FACEBOOK_ID + PASSWORD + SecretKey).ToLower();

		//Assigns the data we want to save
		//Where -> Form.AddField("name" = matching name of value in SQL database
		WWWForm mForm = new WWWForm();
		mForm.AddField("FACEBOOK_ID", FACEBOOK_ID); // adds the player name to the form
		mForm.AddField("FIRST_NAME", FIRST_NAME); // adds the player password to the form
		mForm.AddField("LAST_NAME", LAST_NAME); // adds the kill total to the form
		mForm.AddField("EMAIL", EMAIL); // adds the death Total to the form
		mForm.AddField("PASSWORD", PASSWORD); // adds the score Total to the form
		mForm.AddField("hash", hash); // adds the security hash for Authorization

		//Creates instance of WWW to runs the PHP script to save data to mySQL database
		WWW www = new WWW(RegisterPHP_Url, mForm);
		Debug.Log("Processing...");
		yield return www;

		Debug.Log("" + www.text);
		if (www.text == "Done")
		{
			Debug.Log("Registered Successfully.");
			Application.LoadLevel ("Scene3_Calendar");//MainMenu
			//this.GetComponent<bl_LoginManager>().ShowLogin();
			//bl_LoginManager.UpdateDescription("Registered Successfully, Login Now");
		}
		else
		{
			Debug.Log("This is an Error"+www.text);
			//			bl_LoginManager.UpdateDescription(www.text);

		}
		isRegister = false;
		//		Debug.Log ("Nice Finish Register...");
	}

	public string Md5Sum(string input)
	{
		System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
		byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
		byte[] hash = md5.ComputeHash(inputBytes);

		StringBuilder sb = new StringBuilder();
		for (int i = 0; i < hash.Length; i++) { sb.Append(hash[i].ToString("X2")); }
		return sb.ToString();
	}

}
