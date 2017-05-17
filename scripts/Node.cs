using UnityEngine;
using System.Collections;

public class Node : MonoBehaviour 
{
	[Header("Script Stuff")]
	public GameObject iHaveObject = null;
	public bool isNodeWithInteraction = false;

	[Header("Node's Properties")]
	public Color basicColor;
	public Color hoverColor;
	public Color selectedColor;
	public Color PlayerPosition;

	void Awake()
	{
		ChangeNodeColor(basicColor);
	}

	void Start()
	{
		if(iHaveObject != null && !isNodeWithInteraction)
			GetComponent<BoxCollider>().enabled = false;
	}

	public void MouseDown()
	{
		if(GameManager.main.playerIsUsingSth)
		{
			Debug.Log("Player is using Something!");
			return;
		}
		if(GameManager.main.playerIsMoving)
		{
			Debug.Log("You can not select the node!");
			return;
		}
		
		if(GameManager.main.selectedNode == null)
		{
			GameManager.main.SelectNode(this.gameObject,this);
			ChangeNodeColor(selectedColor);
		}
		else if(GameManager.main.selectedNode == this.gameObject)
		{
			GameManager.main.UnselecteNode();
			ChangeNodeColor(basicColor);
		}
	}

	void OnMouseEnter()
	{
		if(GameManager.main.playerIsUsingSth)
		{
			return;
		}
		if(GameManager.main.selectedNode == null)
			ChangeNodeColor(hoverColor);
	}

	void OnMouseExit()
	{
		if(GameManager.main.playerIsUsingSth)
		{
			return;
		}
		if(GameManager.main.selectedNode == null)
			ChangeNodeColor(basicColor);
	}
		
	public void ChangeNodeColor(Color color)
	{
		GetComponent<MeshRenderer>().material.color = color;
	}
}
