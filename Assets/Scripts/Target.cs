using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    /// <Variables>
    // Public Variables:
    public int PointsValue;
    public ParticleSystem ParticleSystem;

    // Private Not Serialized Variables:
    private readonly float _minSpeed = 12.0f; // Targets Min Speed
    private readonly float _maxSpeed = 16.0f; // Targets Max Speed
    private readonly float _torque = 10.0f; // Targets Spin
    private readonly float _xRange = 4.0f; // Targets random Start Pos on "X"
    private readonly float _yStartPos = 0.0f; // Targets Start Pos on "Y"

    // Private Not Serialized & Not Readonly Variables:
    private Rigidbody _rigidbodyTarget; // Targets Rigidbodies
    private GameManager _gameManager;

    /// <Methods>
    // Private Methods:
    void Start()
    {
        _rigidbodyTarget = GetComponent<Rigidbody>(); // Access target Rigidbodies
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        _rigidbodyTarget.AddForce(RandomForce(), ForceMode.Impulse);
        _rigidbodyTarget.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomStartPos();
    }

    void Update()
    {

    }

    Vector3 RandomForce() // Vertical random force applied between 12 to 16
    {
        return Vector3.up * Random.Range(_minSpeed, _maxSpeed);
    }

    float RandomTorque() // To spin the target randomly
    {
        return Random.Range(-_torque, _torque);
    }

    Vector3 RandomStartPos() // Target start position
    {
        return new Vector3(Random.Range(-_xRange, _xRange), _yStartPos);
    }

    void OnMouseDown()
    {
        if (gameObject.CompareTag("Bad"))
        {
            Destroy(gameObject);
            Instantiate(ParticleSystem, transform.position, ParticleSystem.transform.rotation);
            _gameManager.GameOver();
        }
        else if (_gameManager._isPlaying == true)
        {
            Destroy(gameObject);
            Instantiate(ParticleSystem, transform.position, ParticleSystem.transform.rotation);
            _gameManager.UpdateScore(PointsValue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            _gameManager.GameOver();
        }
    }
}
