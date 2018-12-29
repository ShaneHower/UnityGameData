using System;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TextBoxManager : MonoBehaviour {

    // Game Objects
    public GameObject textBox;
    public GameObject playerOptions;

    // Scripts
    public PlayerDiagChoice diagChoice;

    // Text
    public Text regTxt;
    public Text optionTxt;

    // Other Data Types
    public string path;
    public string objName;
    public bool displayOptions;
    private int numLines;
    private int i;
    private string[] lines;

	// Use this for initialization
	void Start () {
        i = 0;
        diagChoice = playerOptions.GetComponent<PlayerDiagChoice>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!displayOptions)
        {
            DisplayTxt(regTxt);
        }
        else if (displayOptions)
        {
            // bugs here see objDialogue.
            DisplayTxt(optionTxt);
            YesOrNo();
        }
    }



    private void DisplayTxt(Text txt)
    {
        // Fetches txt file by name, sets each line to the UI text
        if (i == 0)
        {
            path = String.Format("Assets/TxtFiles/{0}Text.txt", objName);
            lines = File.ReadAllLines(path);
            numLines = lines.Length;
            txt.text = lines[i];
            i += 1;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            if (i < numLines)
            {
                txt.text = lines[i];
                i += 1;
            }
            else
            {
                i = 0;
                textBox.SetActive(false);
            }
        }
    }

    private void YesOrNo()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
        diagChoice.interName = objName;
    }

}
