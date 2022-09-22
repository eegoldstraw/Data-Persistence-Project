using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Manager : MonoBehaviour
{
    public static Manager Instance;
    [SerializeField] InputField _playerName;
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

    public void GetName(string name)
    {
        playerName = name;
        Debug.Log("The players name is " + name);
    }     
   public void StartGame()
    {
        SceneManager.LoadScene(0);
    }
}
