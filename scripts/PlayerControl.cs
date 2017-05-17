using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerControl : MonoBehaviour 
{
	public GameManager gameManager;
	public float playerSpeed = 10f;
	public int AvailableMoves = 3;

	private float offsetY = 1.5f;
	private Room currentRoom;
	private List<Vector3> waypoints = new List<Vector3>();

	void Awake()
	{
		currentRoom = GameObject.Find("GuestRoom").GetComponent<Room>();	
	}

	public void MoveToNode()
	{
		Room destinationRoom =  gameManager.selectedNode.transform.parent.GetComponent<Room>();

		if(gameManager.playerIsMoving)
		{
			Debug.Log("Wait the Player is moving!");
			return;
		}

		if(CalculateDistance() > AvailableMoves)
		{
			gameManager.UnselecteNode();
			Debug.Log("Cant walk too far");
			return;
		}

		if(currentRoom == destinationRoom)
		{	
			StartCoroutine(MovePlayer(gameManager.selectedNode));
			gameManager.UnselecteNode();
		}
		else if(currentRoom.HasExit(destinationRoom))
		{
			StartCoroutine(MoveToNextRoom(destinationRoom));
		}
		else
		{
			Debug.Log(destinationRoom.name + " "+"is to far!");
		}
	}

	private IEnumerator MovePlayer(GameObject destination)
	{
		gameManager.playerIsMoving = true;
		Vector3 destinationPosition = destination.transform.position;

		Vector3 destinationX = new Vector3(destinationPosition.x, destinationPosition.y + offsetY, transform.position.z);
		while(Vector3.Distance(transform.position, destinationX) > 0.1f)
		{
			Vector3 dir = destinationX - transform.position;
			transform.Translate(dir * Time.deltaTime * playerSpeed, Space.World);
			yield return new WaitForFixedUpdate();
		}

		Vector3 destinationZ = new Vector3(transform.position.x, destinationPosition.y + offsetY, destinationPosition.z);
		while(Vector3.Distance(transform.position, destinationZ)  > 0.1f)
		{
			Vector3 dir = destinationZ - transform.position;
			transform.Translate(dir * Time.deltaTime * playerSpeed, Space.World);
			yield return new WaitForFixedUpdate();
		}

		transform.position = new Vector3(destinationPosition.x, offsetY, destinationPosition.z);

		gameManager.playerIsMoving = false;
	}

	private IEnumerator MoveToNextRoom(Room nextRoom)
	{
		MoveToExitDoor(currentRoom.GetExit(nextRoom));
		while(gameManager.playerIsMoving)
		{	
			yield return null;
		}
		
		OpenDoor(nextRoom);
		while(gameManager.playerIsMoving)
		{	
			yield return null;
		}

		StartCoroutine(MovePlayer(gameManager.selectedNode.gameObject));

		gameManager.UnselecteNode();
		currentRoom = nextRoom;
	}

	private void MoveToExitDoor(Exit exit)
	{
		StartCoroutine(MovePlayer(exit.exitNode));
	}

	public void OpenDoor(Room nextRoom)
	{
		GameObject nodeAfterOpeningDoor = nextRoom.GetExit(currentRoom).exitNode;

		StartCoroutine(MovePlayer(nodeAfterOpeningDoor));
	}

	private int CalculateDistance()
	{
		Vector3 selectedNodePosition = gameManager.selectedNode.transform.position;
		float distanceX = Mathf.Abs((selectedNodePosition.x - transform.position.x) /2.5f);
		float distanceZ = Mathf.Abs((selectedNodePosition.z - transform.position.z) /2.5f);

		return Mathf.RoundToInt(distanceX + distanceZ);
	}
		
	public void Examine()
	{
		Debug.Log("This is a "+ gameManager.selectedNode.ToString());
	}


}
