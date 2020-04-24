using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public int winScore = 100;

    public Text restartText;
    public Text gameOverText;
    public Text ScoreText;
    public Text WinText;
    public Text ammoText;

    private PlayerController playerController;
    private BgScroller backgroundScroller;
    private int score;
    public bool gameover;
    private bool restart;

    public AudioClip backgroundMusic;
    public AudioClip winMusic;
    public AudioClip lossMusic;
    public AudioSource musicSource;

    private void Awake()
    {

    }

    void Start()
    {
        gameover = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        WinText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());

        GameObject playerControllerObject = GameObject.FindWithTag("Player");
        playerController = playerControllerObject.GetComponent<PlayerController>();

        GameObject backgroundScrollerObject = GameObject.FindWithTag("Background");
        backgroundScroller = backgroundScrollerObject.GetComponent<BgScroller>();

        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }

    void Update()
    {
        UpdateAmmo();

        if (restart)
        {
            if(Input.GetKeyDown(KeyCode.M))
            {
                SceneManager.LoadScene("MainMenuScene");
            }
        }

        if (Input.GetKey("escape"))
            Application.Quit();
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];

                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameover)
            {
                restartText.text = "Press 'M' to go to Main menu!";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;
        if (score >= winScore)
        {
            WinText.text = "You Win!" + "\n" + "Game Created by Niles Garcia";
            gameover = true;
            restart = true;

            backgroundScroller.scrollSpeed = -10.0f;

            musicSource.clip = winMusic;
            musicSource.Play();
        }
    }

    public void UpdateAmmo()
    {
        ammoText.text = "Fast Rounds: " + playerController.ammo;
    }

    public void GameOver()
    {
        if(score >= winScore)
        {
            gameOverText.text = "";
        }
        else
            gameOverText.text = "Game Over" + "\n" + "Game Created by Niles Garcia";

        gameover = true;
    }
}
