using System.Globalization;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{ 
    [SerializeField] private TextMeshProUGUI timerInGame;
    [SerializeField] private TextMeshProUGUI survivalTime;
    [SerializeField] private Timer timeSecond;
    
    [Space(15)] 
    [SerializeField] private TextMeshProUGUI bestScore;
    [SerializeField] private TextMeshProUGUI actualMoney;

    [SerializeField] private GameSave gameSave;
    
    private float _second;
    private float _bestScore;
    private int _totalCoins;

    private void Start()
    {
        gameSave.LoadFromFille(out var infoGame);
        
        _bestScore = infoGame.highScore;
        _totalCoins = infoGame.totalCountCoins;
       
        bestScore.text = Mathf.Round(_bestScore).ToString(CultureInfo.InvariantCulture);
        actualMoney.text = _totalCoins.ToString();
    }

    public void CountingTheRecord()
    {
        survivalTime.text = Mathf.Round(_second).ToString(CultureInfo.InvariantCulture);
        
        var sec = (_second > _bestScore) ? _second : _bestScore;
        gameSave.SaveToFille(sec,_totalCoins);
        
    }
    public void WriteCoin()
    {
        _totalCoins++;
        actualMoney.text = _totalCoins.ToString();
    }
    private void Update()
    {
         _second = timeSecond.timeSecond;
         timerInGame.text = $"{Mathf.Round(_second)} sec";
    }
}
