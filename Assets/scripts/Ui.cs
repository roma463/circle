using UnityEngine;
using UnityEngine.UI;
public class Ui : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _displayMaxScore;
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private Spacner _spavner;
    [SerializeField] private Player _player; 
    [SerializeField] private GameObject _uiPlay;
    private int _score;
    private int _MaxScore;
    private void Start()
    {
        _MaxScore = PlayerPrefs.GetInt("Score", 0);
        _displayMaxScore.text = _MaxScore.ToString();
    }
    public void ScoreCount(int x = 0) 
    {
        if(x == 0)
        {
            _score = 0;
        }
        else
        {
            _score += x;
            if(_score >= _MaxScore)
            {
                _MaxScore = _score;
            }
        }
        _displayMaxScore.text = _MaxScore.ToString();
        _scoreText.text = _score.ToString();
    }
    public void ConditionGame(bool conitionLife, float timeScale)
    {
        PlayerPrefs.SetInt("Score", _MaxScore);
        _gameOver.SetActive(conitionLife);
        Time.timeScale = timeScale;
    }
    public void Restart()
    {
        _player._isDeath = false;
        ConditionGame(false, 1);
        _spavner.OffAllActiveObject();
        ScoreCount();

    }
    public void Play()
    {
        _spavner.enabled = true;
        _player.enabled = true;
        _uiPlay.SetActive(false);
    }
}
