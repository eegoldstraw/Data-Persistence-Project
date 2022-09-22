using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class NameScript : MonoBehaviour
{
    public TMP_InputField textOutput;
    // Start is called before the first frame update
    void Start()
    {
        var userInput = gameObject.GetComponent<TMP_InputField>();
        //textOutput = input.text;
        
        Debug.Log(userInput.text);
        //InputField.EndEditEvent se = new InputField.EndEditEvent();
        //se.AddListener(SubmitName);
       // input.onEndEdit = se;

        //or simply use the line below, 
        //input.onEndEdit.AddListener(SubmitName);  // This also works
    }

    private void SubmitName(string arg0)
    {
        Debug.Log(arg0);
    }
}



