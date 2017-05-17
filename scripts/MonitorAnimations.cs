using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MonitorAnimations : MonoBehaviour 
{
	public Text warningMessage;
	public Text wellcomeMessage;

	public Animation anim;
	public AnimationClip accessGranted;
	public AnimationClip accessDenied;
	public AnimationClip initState;
	public AnimationClip desktopFadeIn;

	public void LogInAnimation(bool isRightCredentials,string userName)
	{
		if(isRightCredentials)
		{
			warningMessage.text = "Access Granted!";
			anim.Play(accessGranted.name);
			wellcomeMessage.text = "Wellcome "+ userName;
		}
		else
		{
			warningMessage.text = "Access Denied!";
			anim.Play(accessDenied.name);
		}
	}

	public void InitialAnimation()
	{
		anim.Play(initState.name);
	}

	public void DesktopFadeIn()
	{
		anim.Play(desktopFadeIn.name);
	}
}
