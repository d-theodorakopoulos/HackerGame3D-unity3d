using UnityEngine;

public class ComputerOS : MonoBehaviour 
{
	[Header("OS properties")]
	public string deviceUserName = "admin";
	public string devidePassWord = "admin1";
	public string ipAdress = "192.168.1.1";

	private string typedUserName;
	private string typedPassWord;
	private bool userAuthorized;


	public bool LogIn()
	{
		if(deviceUserName == typedUserName && devidePassWord == typedPassWord)
		{
			Debug.Log("Access Granted!");
			userAuthorized = true;
			return true;
		}
		else
		{
			Debug.Log("Wrong Credentials...");
			return false;
		}
	}

	public void setCredentials(string username, string pass)
	{
		typedUserName = username;
		typedPassWord = pass;
	}

	public void ShutDownOS()
	{
		GetComponent<ElectronicDevice>().monitorCanvas.enabled = false;
		GameManager.main.playerIsUsingSth = false;
		this.enabled = false;
	}

	public bool IsUserAuthorized()
	{
		return userAuthorized;
	}
}
