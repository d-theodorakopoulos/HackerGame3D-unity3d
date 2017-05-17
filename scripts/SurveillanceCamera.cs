using UnityEngine;
using System.Collections;

public class SurveillanceCamera : MonoBehaviour 
{
	public float sightAngle = 45f;
	public float viewRange = 10f;
	public int scanRate = 2;
	public Light spotLight;
	public GameObject lens;
	public GameObject player;

	public GameObject cameraCenter;

	void Awake()
	{
		player = GameObject.Find("Player");
		cameraCenter.transform.localPosition *= viewRange;
	}

	void Update()
	{
		if(Mathf.FloorToInt(Time.time) % scanRate == 0)
			CameraScaning();
	}

	private void CameraScaning()
	{
		Vector3 playerDistance = cameraCenter.transform.position - player.transform.position;

		if(Vector3.Magnitude(playerDistance) < 3.5f)
		{
			spotLight.color = Color.red;
		}
		else
		{
			spotLight.color = Color.green;
		}
	}

	public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
	{ 

		if (!angleIsGlobal)
		{ 
			angleInDegrees += transform.eulerAngles.y; 
		} 

		//Debug.Log(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad) + " "+Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
		//Debug.Log(transform.eulerAngles.x );
		return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), -Mathf.Sin(transform.eulerAngles.x * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad)); 
	} 

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawLine(transform.position, cameraCenter.transform.position);
		Gizmos.DrawLine(cameraCenter.transform.position, player.transform.position);
	}
}
