using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalMenu : MonoBehaviour {

	public void InfoShow(string Debug){
		print ("Debug Output: "+Debug);
		Scene scene = SceneManager.GetActiveScene();
		if(Debug == "GlobalMenu_Appointment" && scene.name != "Scene7_Appointment"){FuncAppointment();}
		if(Debug == "GlobalMenu_Account" && scene.name != "Scene4_Account"){FuncAccount();}
		if(Debug == "GlobalMenu_Calendar" && scene.name != "Scene3_Calendar"){FuncCalendar();}
		if(Debug == "GlobalMenu_Search" && scene.name != "Scene5_Search"){FuncSearch();}
		if(Debug == "GlobalMenu_Notification" && scene.name != "Scene6_Notification"){FuncNotification();}
	}
	private void FuncAppointment(){
		print ("FuncAppointment");
		Application.LoadLevel("Scene5_Search");
	}

	private void FuncAccount(){
		print ("FuncAccount");
		Application.LoadLevel("Scene4_Account");
	}

	private void FuncCalendar(){
		print ("FuncCalendar");
		Application.LoadLevel("Scene3_Calendar");
	}

	private void FuncSearch(){
		print ("FuncSearch");
		Application.LoadLevel("Scene5_Search");
	}

	private void FuncNotification(){
		print ("FuncNotification");
		Application.LoadLevel("Scene6_Notification");
	}
}
