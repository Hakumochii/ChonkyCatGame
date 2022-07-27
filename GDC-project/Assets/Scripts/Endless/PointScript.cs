using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointScript : MonoBehaviour
{
    public int points = 0;

    [SerializeField] private TextMeshProUGUI currentScoreText;

    [SerializeField] private TextMeshProUGUI endScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints(int newPoints)
    {
        points += newPoints;
        currentScoreText.text = "Score: " + points * 10;
    }

    public void SavePoints()
    {
        endScoreText.text = "Score: " + points * 10;
        if (points > PlayerPrefs.GetInt("Player Highscore"))
        {
            PlayerPrefs.SetInt("Player Highscore", points);
            highScoreText.text = "New Highscore: " + points * 10;
            highScoreText.color = Color.red;
        }
        else
        {
            highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("Player Highscore") * 10;
        }
    }
}
