using UnityEngine;

public class CameraControl : MonoBehaviour 
{
	[Header("Script stuff")]
	public GameObject pointOfInterest;
	public GameManager gameManager;

	[Header("Camera Properties")]
	public float panSpeed = 5f;
	public float mouseDeadzone = 0.1f;
	public float scrollSpeed = 10;
	public float minY = 10;
	public float maxY = 80;

	private Vector3 currentMouseLocation;

	void Update() 
	{
		if(gameManager.playerIsUsingSth)
		{
			return;
		}

		if(Input.GetMouseButton(2))
		{
			if (Input.GetAxis("Mouse X") > mouseDeadzone)
				transform.Translate(Vector3.right * Time.deltaTime * panSpeed,Space.World);
			else if (Input.GetAxis("Mouse X") < -mouseDeadzone)
				transform.Translate(Vector3.left * Time.deltaTime * panSpeed,Space.World);

			if (Input.GetAxis("Mouse Y") > mouseDeadzone)
				transform.Translate(Vector3.forward * Time.deltaTime * panSpeed,Space.World);
			else if (Input.GetAxis("Mouse Y") < -mouseDeadzone)
				transform.Translate(Vector3.back * Time.deltaTime * panSpeed,Space.World);
		}

		if(Input.GetMouseButton(1))
		{
			if (Input.GetAxis("Mouse X") > mouseDeadzone)
				pointOfInterest.transform.Rotate(0f, 5f,0f);
			else if (Input.GetAxis("Mouse X") < -mouseDeadzone)
				pointOfInterest.transform.Rotate(0f,-5f,0f);
		}

		if(Input.GetAxis("Mouse ScrollWheel") != 0)
		{
			float scroll = Input.GetAxis("Mouse ScrollWheel");

			Vector3 pos = transform.position;

			pos.y -= scroll * 500 * scrollSpeed * Time.deltaTime;
			pos.y = Mathf.Clamp(pos.y, minY, maxY);

			transform.position = pos;
		}
	}
		
}
