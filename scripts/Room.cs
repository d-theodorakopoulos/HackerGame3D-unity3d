using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour 
{
	public Exit[] exits;

	public Exit GetExit(Room room)
	{
		for (int i = 0; i < exits.Length; i++)
		{
			if(exits[i].goToRoom.name == room.gameObject.name)
				return exits[i];
		}
		return null;
	}

	public bool HasExit(Room room)
	{
		for (int i = 0; i < exits.Length; i++)
		{
			if(exits[i].goToRoom.name == room.gameObject.name)
				return true;
		}
		return false;
	}
}

[System.Serializable]
public class Exit
{
	public GameObject goToRoom;
	public GameObject exitNode;
}