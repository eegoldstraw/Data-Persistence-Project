using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;
public class Manager : MonoBehaviour
{
    public static Manager Instance;
    [SerializeField] GameObject userInputField;
    public string playerName;
    public int highScore;
    public string highScorePlayerName;
    //public TMP_Text HighScoreText;
    public GameObject HighScoreText;

    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
    }
    public void UpdateHighScore(string name, int score)
    {
        if (score > highScore)
        {
            highScore = score;
            highScorePlayerName = name;
        }
        HighScoreText.GetComponent<Text>().text = "High Score :" + highScorePlayerName + " : " + highScore;
        Debug.Log("updated high score");
        if (GameObject.Find("MainManager").GetComponent<MainManager>().m_GameOver)
        {
            SaveHighScore();
            Debug.Log("save high score");
        }
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
    [System.Serializable]
    class SaveData
    {
        public string highScorePlayerName;
        public int highScore;
    }

    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.highScorePlayerName = highScorePlayerName;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScore = data.highScore;
            highScorePlayerName = data.highScorePlayerName;
        }
    }
}
