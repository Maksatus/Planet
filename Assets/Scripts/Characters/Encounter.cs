using UnityEngine;

public class Encounter : MonoBehaviour
{
    [SerializeField] private Score score;
    [SerializeField] private GameManager statusGame;
    [Space(15)]
    [SerializeField] private Coin effectCoin;
    [SerializeField] private ParticleSystem effectUp;
    private bool _isDeath = true;
    private void OnCollisionEnter(Collision other)
    {
        var isCoin = other.collider.GetComponent<Coin>();
        if (isCoin!=null)
        {
            score.WriteCoin();
            effectCoin.PlayAnimEffectUp(effectUp);
        }
        else if (other.collider.CompareTag("Death") && _isDeath)
        {
            statusGame.EndGame();
            score.CountingTheRecord();
            _isDeath = false;
        }
    }
}
