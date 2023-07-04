using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /// <Variables>
    // Public Variables: 
    public List<GameObject> Targets;
    public TextMeshProUGUI TextScore;
    public TextMeshProUGUI TextGameOver;
    public Button RestartButton;
    public GameObject TitleScreen;

    //Internal Variables:
    internal bool _isPlaying = false;

    // Private Not Serialized & Not Readonly Variables: 
    private float _spawnWait = 2.0f;
    private int _score;

    /// <Methods>
    // Private Methods:
    void Start()
    {

    }

    void Update()
    {

    }

    private IEnumerator RandomSpawn()
    {
        while (_isPlaying == true)
        {
            yield return new WaitForSeconds(_spawnWait);
            int index = Random.Range(0, Targets.Count);
            Instantiate(Targets[index]);
        }
    }

    //Public Methods:
    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        TextScore.text = $"Score: {_score}";
    }

    public void GameOver()
    {
        _isPlaying = false;
        TextGameOver.gameObject.SetActive(true);
        RestartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int Challenge)
    {
        _isPlaying = true;
        _score = 0;

        StartCoroutine(RandomSpawn());
        UpdateScore(0);

        TitleScreen.SetActive(false);
        _spawnWait /= Challenge;
    }
}
