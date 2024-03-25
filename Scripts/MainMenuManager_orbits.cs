using System.Collections;
using TMPro;
using UnityEngine;

public class MainMenuManager_orbits : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _newBestText;
    [SerializeField] private TMP_Text _bestScoreText;
    public GameObject panel_loading;

    private void Awake()
    {
        _bestScoreText.text = GameManager_orbits.Instance.HighScore.ToString();

        if(!GameManager_orbits.Instance.IsInitialized)
        {
            _scoreText.gameObject.SetActive(false);
            _newBestText.gameObject.SetActive(false);
        }
        else
        {
            StartCoroutine(ShowScore());
        }
    }

    [SerializeField] private float _animationTime;
    [SerializeField] private AnimationCurve _speedCurve;

    private IEnumerator ShowScore()
    {
        int tempScore = 0;
        _scoreText.text = tempScore.ToString();

        int currentScore = GameManager_orbits.Instance.CurrentScore;
        int highScore = GameManager_orbits.Instance.HighScore;

        if(currentScore > highScore)
        {
            _newBestText.gameObject.SetActive(true);
            GameManager_orbits.Instance.HighScore = currentScore;
        }
        else
        {
            _newBestText.gameObject.SetActive(false);
        }

        float speed = 1 / _animationTime;
        float timeElapsed = 0f;
        while(timeElapsed < 1f)
        {
            timeElapsed += speed * Time.deltaTime;

            tempScore = (int)(_speedCurve.Evaluate(timeElapsed) * currentScore);
            _scoreText.text = tempScore.ToString();

            yield return null;
        }

        tempScore = currentScore;
        _scoreText.text = tempScore.ToString();
    }

    [SerializeField] private AudioClip _clickSound;

    public void ClickedPlay()
    {
        SoundManager_orbits.Instance.PlaySound(_clickSound);
        GameManager_orbits.Instance.GoToGameplay();
    }

     public void exit()
    {
        GameObject GameManager = GameObject.Find("GameManager");
        if(GameManager)
          Destroy(GameManager);
        panel_loading.SetActive(true); 
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }



}
