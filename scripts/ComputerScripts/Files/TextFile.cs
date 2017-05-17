using UnityEngine;

public class TextFile : File
{
	public string plainText = "";

	public void OpenFile()
	{
		TextEditorManager.mainWindow.EnableWindow(this);
		TextEditorManager.mainWindow.plainText.text = plainText;
	}
}

