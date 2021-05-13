using ScriptableObjs;
using UnityEngine;

public class GameResetHandler: MonoBehaviour
{
    public GameEvent gameResetEvent;
    private void Start()
    {
        enabled = false;
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) || Input.touchCount > 0)
        {
            gameResetEvent.Raise();
            enabled = false;
        }
    }
    
}
