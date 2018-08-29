using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip firstHit;
    public AudioClip secondHit;
    public AudioClip thirdHit;
    public AudioClip fourthHit;
    public AudioClip titleScreen;
    public AudioClip powerUp;
    public AudioClip gameOver;
    public AudioClip lifeLost;
    public AudioClip collisionBallPlayer;
    public AudioSource audioSource;

    public void PlayFirstHit()
    {
        audioSource.PlayOneShot(firstHit);
    }

    public void PlaySecondHit()
    {
        audioSource.PlayOneShot(secondHit);
    }

    public void PlayThirdHit()
    {
        audioSource.PlayOneShot(thirdHit);
    }

    public void PlayFourthHit()
    {
        audioSource.PlayOneShot(fourthHit);
    }

    public void PlayTitleScreen()
    {
        audioSource.loop = true;
        audioSource.clip = titleScreen;
        audioSource.Play();
    }

    public void PlayGameOver()
    {
        audioSource.PlayOneShot(gameOver);
    }

    public void PlayLifeLost()
    {
        audioSource.PlayOneShot(lifeLost);
    }

    public void PlayPowerUp()
    {
        audioSource.PlayOneShot(powerUp);
    }

    public void PlayCollisionPlayerBall()
    {
        audioSource.PlayOneShot(collisionBallPlayer);
    }
}
