using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;

    public Text scoreText;

    public GameObject playButton;

    public AudioSource backGroundMusic;

    public AudioClip soundEffect; 

    public GameObject gameOver;
    public GameObject getReady;

    public bool gameEnd;

    private int score;

    private void Awake() {

        // Application.targetFrameRate = 60;
        //backGroundMusic = GetComponent<AudioSource>();

        
        gameOver.SetActive(false);
        
        getReady.SetActive(true);
        Pause();
    }

    public void Play() {
        score = 0;     //reset score to 0
        scoreText.text = score.ToString();

        backGroundMusic.Play();
        //backGroundMusic.PlayOneShot(backGroundMusic, 0.7F);

        playButton.SetActive(false);
        getReady.SetActive(false);
        gameOver.SetActive(false);
        // Destroy(gameOver);



        Time.timeScale = 1f;
        player.enabled = true;

        Nets[] nets = FindObjectsOfType<Nets>();

        for (int i = 0; i < nets.Length; i++) {
            Destroy(nets[i].gameObject);
        }

    }


    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;

       

    }

    public void GameOver() {
        //Debug.Log("Game over");
        gameEnd = false;
        //AudioSource.PlayClipAtPoint(soundEffect);
        gameOver.SetActive(true);
        playButton.SetActive(true);

        // backGroundMusic = GetComponent<AudioSource>();
        // backGroundMusic.Play();
        
        if (gameEnd == false)
        {
            backGroundMusic.Stop();
            backGroundMusic.PlayOneShot(soundEffect, 0.553f);
            gameEnd = true;   
            
        }
       

        Pause();
    }

    public void IncreaseScore() {
        score++;
        scoreText.text = score.ToString();
    }
}
