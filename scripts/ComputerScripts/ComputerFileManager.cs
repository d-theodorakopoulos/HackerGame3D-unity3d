using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class ComputerFileManager : MonoBehaviour
{
	[Header("Monitor Stuff")]
	public Text currentWindowLabel;
	public GameObject folderHolder;
	public GameObject fileHolder;

	[Header("Initialization Stuff")]
	public GameObject pcFilesHolder;
	public GameObject folderPrefab;
	public GameObject textFilePrefab;
	public GameObject imageFilePrefab;

	[HideInInspector]
	public Folder currentFolder;

	private Folder rootFolder;

	void Start()
	{
		CreateBaseFiles();
	}

	public void ResetToRootFolder()
	{
		currentFolder = rootFolder;
	}

	private void CreateBaseFiles()
	{
		Folder root = CreateFolder(gameObject.name+ " Explorer", null);
		rootFolder = root;

		root.AddSubfolder(CreateFolder(gameObject.name+ " JimDocs", root));

		Folder jimData = CreateFolder(gameObject.name+ " JimDAta", root);

		root.AddSubfolder(jimData);
		jimData.CreateSubfolder(gameObject.name+ " Yoo", jimData, folderPrefab);
		root.AddFiles(CreateFile(gameObject.name+ " Risk", FileType.txt));
		jimData.AddFiles(CreateFile(gameObject.name+ " Risk2", FileType.jpeg));

		currentFolder = root;
	}
	private Folder CreateFolder(string folderName, Folder parentName)
	{		
		GameObject createdFolder = (GameObject)Instantiate(folderPrefab, pcFilesHolder.transform);
		createdFolder.name = folderName;

		Folder createdFolderScript = createdFolder.GetComponent<Folder>();
		createdFolderScript.SetFolderProperties(folderName, parentName, this);

		return createdFolderScript;
	}

	private File CreateFile(string fileName ,FileType type)
	{		
		GameObject createdFile;
		File createdFileScript;

		if(type == FileType.jpeg)
		{	
			createdFile = (GameObject)Instantiate(imageFilePrefab, pcFilesHolder.transform);
			createdFileScript = (File)createdFile.GetComponent<ImageFile>();
			createdFileScript.SetFilesProperties(fileName, FileType.jpeg);
		}
		else if(type == FileType.txt)
		{	
			createdFile = (GameObject)Instantiate(textFilePrefab, pcFilesHolder.transform);
			createdFileScript = (File)createdFile.GetComponent<TextFile>();
			createdFileScript.SetFilesProperties(fileName, FileType.txt);
		}
		else //FileType.sys
		{	
			createdFile = (GameObject)Instantiate(textFilePrefab, pcFilesHolder.transform);
			createdFileScript = (File)createdFile.GetComponent<SystemFile>();
			createdFileScript.SetFilesProperties(fileName, FileType.sys);
		}

		createdFile.name = fileName;

		return createdFileScript;
	}

	public void GotoPreviousFolder()
	{
		if (currentFolder == null || currentFolder.nameFolder == gameObject.name+ " Explorer")
		{
			Debug.Log("No Prior Folder!");
			return;
		}
		else
		{
			currentFolder.parentFolder.ShowMyContents();
		}
	}

	public void ResetFolderAndFiles()
	{
		Transform child;

		while(folderHolder.transform.childCount > 0 || fileHolder.transform.childCount > 0)
		{
			if(folderHolder.transform.childCount > 0)
			{	
				child = folderHolder.transform.GetChild(0);
				child.SetParent(pcFilesHolder.transform); 
			}

			if(fileHolder.transform.childCount > 0)
			{	
				child = fileHolder.transform.GetChild(0);
				child.SetParent(pcFilesHolder.transform); 
			}
		}
	}
}

//createdFolder.GetComponent<Button>().onClick.AddListener(delegate { TestFunction();});