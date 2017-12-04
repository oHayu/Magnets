using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour {
    public static GameController instance;
    public bool gameOver = false, playing = false;
    public GameObject player;
    private int score;
    public Text scoreText, gameOverText, startText;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(this.gameObject);
        }

    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log(playing);
            if (gameOver) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            if (!playing) {
                playing = true;
                ChangeMode();
            }
        }
    }

    public void UpdateScore(int score) {
        if (!gameOver) {
            this.score += score;
            scoreText.text = "Score: " + this.score.ToString();
        }
    }

    public void PlayerDied() {
        gameOver = true;
        startText.text = "Score: " + this.score.ToString();
        playing = false; 
        ChangeMode();
    }

    private void ChangeMode() {
        scoreText.enabled = !gameOver;
        Spawner.instance.canSpawnChange();
        gameOverText.enabled = gameOver;
        startText.enabled = gameOver;
    }


}