using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Folder : MonoBehaviour
{
	public Text folderLabel;
	public string nameFolder;
	public Folder parentFolder;
	public List<Folder> subfolders;
	public List<File> files;

	private ComputerFileManager myExplorerManagement;

	public void SetFolderProperties(string folderName, Folder parent, ComputerFileManager myExpManagement)
	{
		nameFolder = folderName;
		folderLabel.text = folderName;
		parentFolder = parent;
		myExplorerManagement = myExpManagement;
	}

/*	public void SetFolderProperties(string folderName, string parentName, List<Folder> subfoldersNames)
	{
		nameFolder = folderName;
		parent = parentName;
		subfolders = new List<Folder>(subfoldersNames.Count);
		subfolders.Clear();
		subfolders.AddRange(subfoldersNames);
	}*/

	public void AddSubfolder(Folder newFolder)
	{		
		subfolders.Add(newFolder);
	}

	public void AddFiles(File file)
	{
		files.Add(file);
	}

	public void CreateSubfolder(string newFolder, Folder parent, GameObject folderPrefab)
	{		
		GameObject createdGameObject = (GameObject)Instantiate(folderPrefab, myExplorerManagement.pcFilesHolder.transform);
		createdGameObject.name = newFolder;
		createdGameObject.GetComponent<Folder>().SetFolderProperties(newFolder, parent, myExplorerManagement);
		subfolders.Add(createdGameObject.GetComponent<Folder>());
	}

	public void ShowMyContents()
	{
		myExplorerManagement.ResetFolderAndFiles();
		myExplorerManagement.currentWindowLabel.text = nameFolder;
		myExplorerManagement.currentFolder = this;

		Vector3 itemPosition = new Vector3(0f, 0f, 0f);

		foreach(Folder folder in subfolders)
		{
			folder.gameObject.transform.SetParent(myExplorerManagement.folderHolder.transform);
			folder.transform.localPosition = itemPosition;
			itemPosition = nextPosition(itemPosition);
		}

		foreach(File file in files)
		{
			file.gameObject.transform.SetParent(myExplorerManagement.fileHolder.transform);
			file.transform.localPosition = itemPosition;
			itemPosition = nextPosition(itemPosition);
		}
	}

	private Vector3 nextPosition(Vector3 previousPosition)
	{
		Vector3 nextPos;
		if(previousPosition.x < 700)
			nextPos = new Vector3(previousPosition.x + 100f, previousPosition.y, 0f);
		else
			nextPos = new Vector3(0f, previousPosition.y - 100f, 0f);

		return nextPos;
	}
}
