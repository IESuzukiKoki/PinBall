using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private int _score;


    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        _scoreText.text = _score.ToString();
    }

    public void SetScore(int score)
    {
        _score += score;
        _scoreText.text = _score.ToString();
    }
}
