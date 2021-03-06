using UnityEngine;
using UnityEngine.UI;

public class ImageViewerManager : MonoBehaviour
{
	[Header("Window Control")]
	public Text windowHeader;
	public Image image;
	public static ImageViewerManager mainWindow;

	void Awake() 
	{
		if(mainWindow == null)
			mainWindow = this;
		else
			Debug.Log("Problem with second instance!");

		gameObject.SetActive(false);
	}

	public void EnableWindow(ImageFile openingFile)
	{
		if(gameObject.activeSelf)
			CloseWindow();
		
		gameObject.SetActive(true);
		windowHeader.text += " :: "+ openingFile.fullName;
	}

	public void CloseWindow()
	{
		gameObject.SetActive(false);
		windowHeader.text = "Image Viewer";
	}

}