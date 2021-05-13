using ScriptableObjs;
using UnityEngine;

public class PlayerScoredTrigger : MonoBehaviour
{
    public GameEvent ballCollisionEvent;

    public void OnTriggerEnter2D(Collider2D other)
    {
        ballCollisionEvent.Raise();
    }
}
