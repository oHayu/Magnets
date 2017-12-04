using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameController : MonoBehaviour {
    public static GameController instance;
    public bool gameOver = false;
    private int score, health = 3;
    public Text scoreText;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else if (instance != this) {
            Destroy(this.gameObject);
        }
    }


    void Update() {
        if (gameOver && Input.GetMouseButtonDown(0)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
    }
}