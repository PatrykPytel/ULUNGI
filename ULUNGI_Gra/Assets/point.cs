
using UnityEngine;
using UnityEngine.UI;

public class point : MonoBehaviour
{
    public Text scoreText;
    public Text highscoreText;
    int score = 0;
    int highscore = 0;

    void Start()
    {
        scoreText.text = score.ToString() + "POINTS";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
