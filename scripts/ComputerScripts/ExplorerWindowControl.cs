using UnityEngine;

public class ExplorerWindowControl : MonoBehaviour 
{
	private ComputerFileManager activePcFileManager; 

	public void GotoPreviousFolder()
	{
		activePcFileManager.GotoPreviousFolder();
	}

	public void CloseWindow()
	{
		gameObject.SetActive(false);
		activePcFileManager.ResetToRootFolder();
		activePcFileManager.ResetFolderAndFiles();
		activePcFileManager = null;
	}

	public void OpenWindow()
	{
		if(gameObject.activeSelf)
			CloseWindow();
		
		gameObject.SetActive(true);
		activePcFileManager = MonitorPC.current.activePC.gameObject.GetComponent<ComputerFileManager>();
		activePcFileManager.currentFolder.ShowMyContents();
	}
}
