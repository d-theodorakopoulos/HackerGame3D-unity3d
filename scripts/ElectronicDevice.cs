using UnityEngine;
using UnityEngine.UI;

public class ElectronicDevice : MonoBehaviour
{
	[Header("PC stuff")]
	public GameObject playerSit;
	public GameObject deviceBase;
	public Canvas pcGUICanvas;
	public ComputerOS deviceOS;

	[Header("Monitor Stuff")]
	public Canvas monitorCanvas;

	private bool playerIsSitting = false;

	void Awake()
	{
		RaycastHit hit;

		if(Physics.Raycast(playerSit.transform.position, Vector3.down,out hit,1f))
		{
			hit.transform.GetComponent<Node>().iHaveObject = playerSit;
			hit.transform.GetComponent<Node>().isNodeWithInteraction = true;
		}

		if(Physics.Raycast(deviceBase.transform.position, Vector3.down,out hit,1f))
		{
			hit.transform.GetComponent<Node>().iHaveObject = deviceBase;
		}
	}

	public void UseDevice()
	{
		GameManager.main.playerIsUsingSth = true;
		pcGUICanvas.enabled = false;
		monitorCanvas.enabled = true;
		MonitorPC.current.activePC = this.deviceOS;
		MonitorPC.current.CanvasEnabled();
	}

	void OnTriggerEnter(Collider collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			playerIsSitting = true;
		}
	}

	void OnTriggerExit(Collider collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			playerIsSitting = false;
		}
	}

	void OnMouseEnter()
	{
		if(playerIsSitting && !pcGUICanvas.enabled && !GameManager.main.playerIsUsingSth)
			Debug.Log("Click to Use!");
	}

	void OnMouseDown()
	{
		if(playerIsSitting && !GameManager.main.playerIsUsingSth)
			pcGUICanvas.enabled = !pcGUICanvas.enabled;
	}
}