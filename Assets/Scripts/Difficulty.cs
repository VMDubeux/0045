using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    /// <Variables>
    // Public Variables:
    public int Challenge;

    // Private Variables:
    private Button Button;
    private GameManager _gameManager;

    /// <Methods>
    // Private Methods:
    void Start()
    {
        Button = GetComponent<Button>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Button.onClick.AddListener(SetDifficulty);
    }

    void Update()
    {
        
    }

    void SetDifficulty()
    {
        _gameManager.StartGame(Challenge);
    }
}
