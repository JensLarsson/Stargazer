using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConsoleBehaviour : MonoBehaviour
{
    public KeyCode openConsole;
    public GameObject window;
    public TMP_InputField inputField;
    public TextMeshProUGUI text;
    string command = null;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if(Input.GetKeyDown(openConsole))
        {
            window.SetActive(!window.activeSelf);
        }
    }

    public void OnCommand()
    {
        if (inputField.isFocused)
        {
            print("derp");
            command = inputField.text;

            bool success = TextCommandManager.ExecuteCommand(command);
            if (success)
            {
                text.text += "\n" + command;
            }
            else
            {
                text.text += "\n" + "Not a command";
            }

            inputField.text = "";
        }
    }

}
