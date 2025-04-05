using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class UIcontroler : MonoBehaviour
{
    [Header("положение героя")]
    [SerializeField] private Transform _player;
    [Header("кнопочки")]
    [SerializeField] private GameObject _playButton;
    [SerializeField] private GameObject _RestarText;
    [SerializeField] private GameObject _ExitButton;
    [SerializeField] private GameObject _pauseButton;

    private bool _isPause;
    private bool _isPlaying;

    private float _recordValue;
    [Header("текстик")]
    [SerializeField] private Text _recordText;
    [SerializeField] private Text _scoreText;

    private void Start()
    {
        _recordValue = PlayerPrefs.GetFloat("Record", 0);
        _recordText.text = Mathf.Round(_recordValue).ToString();
        _isPause = false;
        _isPlaying = false;
    }
    private void Update()
    {
        _scoreText.text = Mathf.Round(_player.position.z).ToString();
        if (_recordValue < _player.position.z)
        {
            _recordValue = _player.position.z;
            _recordText.text = Mathf.Round(_recordValue).ToString();
            PlayerPrefs.SetFloat("Record", _recordValue);
            PlayerPrefs.Save();
        }
        _RestarText.SetActive(_isPause);
        _ExitButton.SetActive(_isPause);

        if (_isPlaying)
        {
            
            _playButton.SetActive(_isPause);
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                _isPause = !_isPause;
            }
            if (_isPause)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
        else
        {
            _playButton.SetActive(true);
            _ExitButton.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void Play()
    {
        if (_isPlaying)
        {
            _isPause = !_isPause;
        }
        else
        {
            _isPlaying = true;
        }
      
    }
    public void Pause()
    {
        if (_isPlaying)
        { _isPause = !_isPause;}
    }
    public void Restart()   
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Exit()
    {
     Application.Quit();
    }
    
}
