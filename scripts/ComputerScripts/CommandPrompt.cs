using UnityEngine;
using UnityEngine.UI;

public class CommandPrompt : MonoBehaviour
{
	public InputField commandPromptInputText;
	public Text commandPromptTextField;

	void OnEnable()
	{
		commandPromptTextField.text = "Command Prompt 1.2 \n" + "Operating System 1998\n";
	}

	public void ExecuteCommand()
	{
		if(commandPromptInputText.text == "show commands")
			ShowAllCommands();
		else if(commandPromptInputText.text == "show computerIP")
			ShowComputerIP();
	}

	public void OpenWindow()
	{
		if(gameObject.activeSelf)
			CloseWindow();
		
		gameObject.SetActive(true);
	}

	public void CloseWindow()
	{
		gameObject.SetActive(false);
	}

	private void ShowAllCommands()
	{
		commandPromptTextField.text += "show commands\nshow computerIP\n";
	}

	private void ShowComputerIP()
	{
		commandPromptTextField.text += "\nThe computer IP is : " + MonitorPC.current.activePC.ipAdress;
	}
}
