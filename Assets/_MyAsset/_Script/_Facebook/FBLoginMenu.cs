﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Facebook.Unity;
using Facebook.Unity.Example;
using System;
using UnityEngine.UI;

public class FBLoginMenu : MonoBehaviour {

	void Awake(){
		FB.Init (SetInit, OnHidenUnity);
	}

	void SetInit(){
		if (FB.IsLoggedIn) {
			Debug.Log ("FB is logged is");
			CrashReport ("FB is logged in");
		} else {
			Debug.Log ("FB is not logged in");
			CrashReport ("FB is not logged in");
		}
		DealWithFBMenus (FB.IsLoggedIn);
	}

	void OnHidenUnity(bool isGameShown){
		if (!isGameShown) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}

	public void FBLogin(){
		List<string> permissions = new List<string> ();
		permissions.Add ("public_profile");
		permissions.Add ("email");
		permissions.Add ("user_friends");
//		permissions.Add ("user_email");
//		permissions.Add ("user_relationships");
//		permissions.Add ("user_hometown");

		FB.LogInWithReadPermissions (permissions, AuthCallBack);
	}

	void AuthCallBack(IResult result){
		if (result.Error != null) {
			Debug.Log (result.Error);
        } else {
			if (FB.IsLoggedIn) {
				Debug.Log ("FB is logged in");
				CrashReport ("FB is logged in");
			} else {
				Debug.Log ("FB is not logged in");
				CrashReport ("FB is not logged in");
			}
			DealWithFBMenus (FB.IsLoggedIn);
        }
	}
		

	public void DealWithFBMenus(bool isLoggedIn){
		if (isLoggedIn) {
			//FB.API ("/me?fields=email" , HttpMethod.GET, DisplayEmail);
			FB.API ("/me?fields=email,first_name,last_name,name,gender,id" , HttpMethod.GET, DisplayInfo);
//			FB.API ("/me/picture?type=square&height=128&width=128", HttpMethod.GET, DisplayProfile);
//			FB.API ("/me?fields=user_hometown" , HttpMethod.GET, Displayhometown);

			Application.LoadLevel ("Scene2_FBRegistration");	

		} 
	}

	private void DisplayInfo(IResult result){
		if (result.Error == null) {
			GlobalVariable.FACEBOOK_ID = result.ResultDictionary ["id"]+"";
			GlobalVariable.FIRST_NAME = result.ResultDictionary ["first_name"]+"";
			GlobalVariable.LAST_NAME = result.ResultDictionary ["last_name"]+"";
			GlobalVariable.EMAIL = result.ResultDictionary ["email"]+"";


			PlayerPrefs.SetString("FACEBOOK_ID", GlobalVariable.FACEBOOK_ID);
			PlayerPrefs.SetString("FIRST_NAME", GlobalVariable.FIRST_NAME);
			PlayerPrefs.SetString("LAST_NAME", GlobalVariable.LAST_NAME);
			PlayerPrefs.SetString("EMAIL", GlobalVariable.EMAIL);


			print ("Hellow WORLD "+ result.RawResult);
			Debug.Log (result.Error);
		} else {
			Debug.Log (result.Error);
		}
	}
		

	private void DisplayEmail(IResult result){
		if (result.Error == null) {
			Debug.Log (result.Error);
		} else {
			Debug.Log (result.Error);
		}
	}

	private void Displayhometown(IResult result){
		if (result.Error == null) {
//			Location.text = "Location: " + result.ResultDictionary["user_hometown"];
			Debug.Log (result.Error);
		} else {
			Debug.Log (result.Error);
		}
	}

	private void DisplayProfile(IGraphResult result){
		if (result.Texture != null) {
//			ProfilePic.sprite = Sprite.Create (result.Texture, new Rect (0, 0, 128, 128), new Vector2 ());
			// FBGlobalVar.ProfilePic = Sprite.Create (result.Texture, new Rect (0, 0, 128, 128), new Vector2 ());
		} else {
			Debug.Log (result.Error);
		}
	}


	private void CrashReport(string Data){
//		ReportMessage.text = Data;
	}


}