using ScriptableObjs;
using UnityEngine;

public class AudioPlayer: MonoBehaviour
{
    public AudioSource refereeWhistleSound;
    public AudioSource woodHitSound;
    public AudioSource borderHitSound;
    public AudioSource scoreSound;
    public AudioSource clappingSound;

    public void PlayGameStartSound()
    {
        clappingSound.Stop();
        refereeWhistleSound.Stop();
        refereeWhistleSound.Play();
    }
    
    public void PlayPaddleHitSound()
    {
        woodHitSound.Play();
    }
    
    public void PlayWallHitSound()
    {
        borderHitSound.Play();
    }
    
    public void PlayPlayerScoredSound()
    {
        scoreSound.Stop();
        scoreSound.Play();
    }
    
    public void PlayGameFinishedSound()
    {
        scoreSound.Stop();
        clappingSound.Stop();
        clappingSound.Play();
    }

    public void StopClappingSound()
    {
        clappingSound.Stop();
    }
    
}
