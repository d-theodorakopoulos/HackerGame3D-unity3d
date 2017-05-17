using UnityEngine;
using UnityEngine.UI;

public class ImageFile : File 
{
	public Sprite image;

	public void OpenFile()
	{
		ImageViewerManager.mainWindow.EnableWindow(this);
		ImageViewerManager.mainWindow.image.sprite = image;
	}
}
