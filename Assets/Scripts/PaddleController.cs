using JetBrains.Annotations;
using ScriptableObjs;
using UnityEngine;

public enum PaddleSide
{
    Right,
    Left
};

public class PaddleController : MonoBehaviour
{
    public KeyCode upKey;
    public KeyCode downKey;
    public GameEvent paddleCollisionEvent;
    public PaddleSide playerSide;

    //[Range(5.0f, 10.0f)]
    public float paddleAccel = 6.2f;
    
        
    private float _screenVerticalBound;
    private float _halfPaddleHeight;
    private Vector2 _startPos;
    private Camera _mainCamera;
    private float _paddleTouchScreenSpaceThreshold;

    private void Start()
    {
        _mainCamera = Camera.main;

        if (_mainCamera is null)
        {
            Debug.Log("Main camera not found!");
            return;
        }
        
        _screenVerticalBound = _mainCamera.ScreenToWorldPoint(
                new Vector3(Screen.width, Screen.height, _mainCamera.transform.position.z)
            ).y;

        var paddleTransform = transform;
        _halfPaddleHeight = paddleTransform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        _startPos = paddleTransform.position;
    }

    private void Update()
    {
        var paddlePos = transform.position;

        if (Input.touchCount <= 0)
        {
            if (Input.GetKey(upKey)) paddlePos += new Vector3(0, paddleAccel * Time.deltaTime, 0);
            if (Input.GetKey(downKey)) paddlePos -= new Vector3(0, paddleAccel * Time.deltaTime, 0); 
        }
        else
        {
            paddlePos = HandleTouchInput(paddlePos);
        }
        
        paddlePos.y = Mathf.Clamp(
            paddlePos.y, 
            _halfPaddleHeight, 
            _screenVerticalBound - _halfPaddleHeight
            );
        
        transform.position = paddlePos;
    }

    private Vector3 HandleTouchInput(Vector3 currentPos)
    {
        foreach(var touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                
                var touchedPos = _mainCamera.ScreenToWorldPoint(
                    new Vector3(touch.position.x, touch.position.y, _mainCamera.transform.position.z)
                    );

                if (playerSide == PaddleSide.Left && touchedPos.x <= 2.0f)
                {
                    currentPos.y = touchedPos.y;
                }
                
                if (playerSide == PaddleSide.Right && touchedPos.x > 13.0f)
                {
                    currentPos.y = touchedPos.y;
                }
            }
        }

        return currentPos;
    }

    public void OnGameReset()
    {
        transform.position = _startPos;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        paddleCollisionEvent.Raise();
    }
}
