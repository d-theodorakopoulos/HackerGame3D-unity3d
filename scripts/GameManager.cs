using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameObject selectedNode;
	public MouseUI mouseUI;
	public static GameManager main;

	[HideInInspector]
	public bool playerIsMoving = false;
	[HideInInspector]
	public bool playerIsUsingSth = false;

	private Node selectedNodeScript;

	void Awake()
	{
		if(main == null)
			main = this;
		else
			Debug.Log("problem with second instance!");
	}

	public void SelectNode(GameObject node,Node nodeScript)
	{
		selectedNode = node;
		selectedNodeScript = nodeScript;
		mouseUI.ToggleCanvas();
		mouseUI.MoveMouseUI(selectedNode.transform.position);
	}

	public void UnselecteNode()
	{
		selectedNodeScript.ChangeNodeColor(selectedNodeScript.basicColor);
		selectedNode = null;
		selectedNodeScript = null;
		mouseUI.ToggleCanvas();
	}
}
