using UnityEngine;

public class SondControl : MonoBehaviour
{
    [SerializeField] private AudioSource audioFootsteps;
    [SerializeField] private AudioSource effecBonus;

    public void PlaySongBonus()
    {
        effecBonus.Play();
    } 
    public void TurnSong(bool status)
    {
        if (status)
        {
            audioFootsteps.Play();
        }
        else
        {
            audioFootsteps.Stop();
        }
    }
}
