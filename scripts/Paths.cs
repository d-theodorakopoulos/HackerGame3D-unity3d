using UnityEngine;
using System.Collections.Generic;

public class Paths : MonoBehaviour
{
	public List<Path> pathsToOtherRooms;
}

[System.Serializable]
public class Path 
{
	public GameObject destination;
	public List<Room> path = new List<Room>();
}
