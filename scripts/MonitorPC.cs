using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MonitorPC : MonoBehaviour 
{
	public ComputerOS activePC;

	[Header("Monitor Stuff")]
	public InputField passwordField;
	public InputField usernameField;
	public GameObject logInMenu;
	public GameObject desktopMenu;
	public MonitorAnimations monitorAnimations;

	private bool results;

	public static MonitorPC current;

	void Awake()
	{
		current = this;
	}

	public void CanvasEnabled()
	{
		if(activePC.IsUserAuthorized())
		{
			logInMenu.SetActive(false);
			desktopMenu.SetActive(true);
		}
		else
		{
			desktopMenu.SetActive(false);
			logInMenu.SetActive(true);
			monitorAnimations.InitialAnimation();
			ResetInputFields();
		}
	}

	public void StoreCredentials()
	{
		activePC.setCredentials(usernameField.text.ToString(), passwordField.text.ToString());
	}

	public void LogInButton()
	{
		results = activePC.LogIn();
		monitorAnimations.LogInAnimation(results, usernameField.text.ToString());
		StartCoroutine(WaitForAnimation());
	}

	public void ShutDownButton()
	{
		activePC.ShutDownOS();
	}

	private void ChangeToDesktop()
	{
		logInMenu.SetActive(false);
		desktopMenu.SetActive(true);
		monitorAnimations.DesktopFadeIn();
	}

	private void ResetInputFields()
	{
		passwordField.text = "";
		passwordField.placeholder.enabled = true;

		usernameField.text = "";
		usernameField.placeholder.enabled = true;
	}

	private IEnumerator WaitForAnimation()
	{
		while(monitorAnimations.anim.isPlaying)
		{
			yield return null;
		}
		Debug.Log("Finish");
		if(results)
		{
			ChangeToDesktop();
		}
	}
}
