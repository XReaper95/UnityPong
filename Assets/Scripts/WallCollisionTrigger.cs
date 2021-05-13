using ScriptableObjs;
using UnityEngine;

public class WallCollisionTrigger : MonoBehaviour
{
    public GameEvent wallCollisionEvent;

    public void OnCollisionEnter2D()
    {
        wallCollisionEvent.Raise();
    }
}
