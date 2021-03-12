using Struct;
using UnityEngine;
using System;
using System.IO;

public class GameSave : MonoBehaviour
{
    
    private string _savePath;
    private string _saveFileName = "data.json";

    [SerializeField] private DateStruct dateGame;
    
    private void Awake()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        savePath = Path.Combine(Application.persistentDataPath,saveFileName);
#else
        _savePath = Path.Combine(Application.dataPath,_saveFileName);
#endif
        Debug.Log(_savePath);
    }
    
    
    public void SaveToFille(float time,int coins)
    {
        dateGame.highScore = time;
        dateGame.totalCountCoins = coins;
        
        string json = JsonUtility.ToJson(dateGame,true);
        
        try
        {
            File.WriteAllText(_savePath, json);
        }
        catch (Exception e)
        {
            Debug.Log($"Error {e}");
        }
    }
    
    
    public void LoadFromFille(out DateStruct loadInfoGame)
    { 
        if (!File.Exists(_savePath))
        {
            Debug.Log("{GameLog}=>{GameCore} - LoadFromFile ->File Not Found");
            loadInfoGame = default;
            return;
        }
        try
        {
            string json = File.ReadAllText(_savePath);
            loadInfoGame = JsonUtility.FromJson<DateStruct>(json);
        }
        catch (Exception e)
        {
            loadInfoGame = default;
            Debug.Log(e);
        }
    }
}
