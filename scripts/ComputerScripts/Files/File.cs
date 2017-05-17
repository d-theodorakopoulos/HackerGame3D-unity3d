using UnityEngine;
using UnityEngine.UI;

public enum FileType { jpeg ,txt ,sys};

public class File : MonoBehaviour
{
	public Text fileLabel;
	public string fileName;
	public string fullName {get {return fileName +"."+type.ToString();}}

	private FileType type;

	public void SetFilesProperties(string n, FileType _type)
	{
		fileName = n; 
		type = _type;
		fileLabel.text = fullName;
	}


	/*public void AddFile(string fileName,FileType _type, string folderName, GameObject filePrefab)
	{
		GameObject createdFile = (GameObject)Instantiate(filePrefab,transform.parent);
		createdFile.GetComponent<File>().SetFilesProperties(fileName, _type, folderName, myExplorerManagement);
	}*/
}
