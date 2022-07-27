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
        currentScoreText.text = (points * 10).ToString();
    }

    public void SavePoints()
    {
        endScoreText.text = (points * 10).ToString();
        if (points > PlayerPrefs.GetInt("Player Highscore"))
        {
            PlayerPrefs.SetInt("Player Highscore", points);
            highScoreText.text = (points * 10).ToString();
            highScoreText.color = Color.red;
        }
        else
        {
            highScoreText.text = (PlayerPrefs.GetInt("Player Highscore") * 10).ToString();
        }
    }
}
