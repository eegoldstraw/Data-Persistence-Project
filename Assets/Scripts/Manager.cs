using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class Manager : MonoBehaviour
{
    public static Manager Instance;
    [SerializeField] GameObject userInputField;
    public string playerName;
    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    public void GetName()
    {
        playerName = userInputField.GetComponent<TMP_InputField>().text;
        
        Debug.Log("The players name is "+playerName);
    }     
   public void StartGame()
    {
        GetName();
        SceneManager.LoadScene(0);
       
    }
}
