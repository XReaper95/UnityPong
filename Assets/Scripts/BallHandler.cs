using System.Collections;
using ScriptableObjs;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallHandler : MonoBehaviour
{
    //[Range(7.0f, 15.0f)]
    public float ballSpeed = 10.5f;
    public GameEvent gameStartEvent;
    
    private int _angle;
    private Vector2 _velocity;
    private Rigidbody2D _rigidbody2D;
    private bool _isFrozen;
    private bool _gameIsWon;
    private Vector2 _startPos;
    private Coroutine _scoredCoroutine;
    private Renderer _renderer;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<Renderer>();
        _startPos = transform.position;
        ResetState();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || _isFrozen || !_gameIsWon) return;
        StartGame();
    }

    public void OnPlayerScore()
    {
        _scoredCoroutine = StartCoroutine(PlayerScoredCoroutine());
    }

    public void OnPlayerWon()
    {
        StopCoroutine(_scoredCoroutine);
        _rigidbody2D.velocity = Vector2.zero;
        _renderer.enabled = false;
        _gameIsWon = true;
    }
    
    public void OnGameReset()
    {
        ResetState();
    }

    public void StartGame()
    {
        _rigidbody2D.velocity = new Vector2(_velocity.x, _velocity.y);
        _isFrozen = false;
        gameStartEvent.Raise();
    }

    private IEnumerator PlayerScoredCoroutine()
    {
        yield return new WaitForSeconds(0.3f);
        
        _rigidbody2D.velocity = Vector2.zero;
        
        yield return new WaitForSeconds(1.2f);
        
        ResetState();
    }

    private void ResetState()
    {
        transform.position = _startPos;
        _angle = GetRandomInitialAngle();
        _velocity.x = ballSpeed * Mathf.Cos(Mathf.Deg2Rad * _angle);
        _velocity.y = ballSpeed * Mathf.Sin(Mathf.Deg2Rad * _angle);
        _isFrozen = true;
        _gameIsWon = false;
        _renderer.enabled = true;
    }
    
    private static int GetRandomInitialAngle()
    {
        const int starTopRight = 30;
        const int endTopRight = 55;
        
        const int startTopLeft = 180 - 55;
        const int endTopLeft = 180 - 30;
        
        const int startBottomLeft = 180 + 30;
        const int endBottomLeft = 180 + 55;
        
        const int startBottomRight = 270 + 30;
        const int endBottomRight = 270 + 55;

        do
        {
            var randomAngle = Random.Range(0, 360);

            if ((randomAngle <= starTopRight || randomAngle >= endTopRight) &&
                (randomAngle <= startTopLeft || randomAngle >= endTopLeft) &&
                (randomAngle <= startBottomLeft || randomAngle >= endBottomLeft) &&
                (randomAngle <= startBottomRight || randomAngle >= endBottomRight)) continue;
            
            return randomAngle;
        } while (true);
    }
}
