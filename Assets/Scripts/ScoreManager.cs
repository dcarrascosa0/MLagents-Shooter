using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI team1ScoreText;
    public TextMeshProUGUI team2ScoreText;
    bool isEnemyPlayer;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnemyPlayer)
        {
            if (int.Parse(team1ScoreText.text) + int.Parse(team2ScoreText.text) == 10)
            {
                Time.timeScale = 0;
            }
        }
        
    }

    public void UpdateScoreTeam1()
    {
        team1ScoreText.text = (int.Parse(team1ScoreText.text) + 1).ToString();

    }

    public void UpdateScoreTeam2()
    {
        team2ScoreText.text = (int.Parse(team2ScoreText.text) + 1).ToString();

    }
}
