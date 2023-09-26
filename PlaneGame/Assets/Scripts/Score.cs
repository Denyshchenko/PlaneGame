using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Score : MonoBehaviour
{

    public int MaxScore;

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _maxScoreText;
    [SerializeField] private DataLoader _dataLoader;

    private int _currentScore;
    private float _timer;





    private void Start()
    {
        _dataLoader.LoadData();
        _maxScoreText.text = MaxScore.ToString();
    }

    private void Update()
    {
        if (_currentScore > MaxScore)
        {
            MaxScore = _currentScore;
            _maxScoreText.text = MaxScore.ToString();
        }
        ScoreCounter();

    }


    public void ScoreCounter()
    {


        _timer += Time.deltaTime;

        if (_timer > 1f)
        {
            _currentScore += 1;
            _scoreText.text = _currentScore.ToString();
            _timer = 0;
        }

    }

}
