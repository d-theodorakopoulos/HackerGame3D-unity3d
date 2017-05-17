using UnityEngine;
using UnityEngine.UI;

public class TextEditorManager : MonoBehaviour 
{
	[Header("Window Control")]
	public Text windowHeader;
	public Text plainText;
	public static TextEditorManager mainWindow;

	void Awake() 
	{
		if(mainWindow == null)
			mainWindow = this;
		else
			Debug.Log("Problem with second instance!");

		gameObject.SetActive(false);
	}

	public void EnableWindow(TextFile openingFile)
	{
		if(gameObject.activeSelf)
			CloseWindow();
		
		gameObject.SetActive(true);
		windowHeader.text += " :: "+ openingFile.fullName;
	}

	public void CloseWindow()
	{
		gameObject.SetActive(false);
		windowHeader.text = "Text Editor";
	}

}
