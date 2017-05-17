using UnityEngine;
using UnityEngine.UI;

public class MouseUI : MonoBehaviour
{
	public Canvas uiCanvas;

	public void MoveMouseUI(Vector3 nodePosition)
	{
		transform.position = nodePosition;
	}

	public void ToggleCanvas()
	{
		uiCanvas.enabled = !uiCanvas.enabled;
	}
}
