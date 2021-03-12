using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SmoothFollow mainCamera;
    
    [Space(15)]
    [SerializeField] private GameObject[] objectsGamesTurnOnOff;
    [SerializeField] private GameObject[] objectsStartGameTurnOnOff;
    [SerializeField] private GameObject[] objectsEndGameTurnOnOff;
   
    [Space(15)] 
    [SerializeField] private CharacterSelection player;
    
    private SondControl _songEffect;
    private AnimalsMove _playerStatus;

    public void StartGame(string currentAnimals)
    {
        InitializationCharacter();

        IsMove(true);
        _playerStatus.GetComponent<AnimationControl>().SetAnimation(currentAnimals);
        TurnOnOfGame();
        TurnOnOfStart();
    }
    
    public void EndGame()
    {
        _playerStatus.GetComponent<AnimationControl>().SetAnimation("isDead");
        TurnOnOfEnd();
        TurnOnOfGame();
        IsMove(false);
    }

    public void RebutGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void TurnOnOfEnd()
    {
        foreach (var obj in objectsEndGameTurnOnOff)
        {
            obj.SetActive(!obj.activeSelf);
        }
    }
    private void TurnOnOfStart()
    {
        foreach (var obj in objectsStartGameTurnOnOff)
        {
            obj.SetActive(!obj.activeSelf);
        }
    }
    private void TurnOnOfGame()
    {
        foreach (var obj in objectsGamesTurnOnOff)
        {
            obj.SetActive(!obj.activeSelf);
        }
    }

    private void IsMove(bool status)
    {
        mainCamera.enabled = status;
        _playerStatus.isMove = status;
        _songEffect.TurnSong(status);
    }
    private void InitializationCharacter()
    {
        int index = player.selectedCharacter;
        mainCamera.target = player.characters[index].transform;
        _playerStatus = player.characters[index].GetComponent<AnimalsMove>();
        _songEffect = player.characters[index].GetComponent<SondControl>();
    }
}
