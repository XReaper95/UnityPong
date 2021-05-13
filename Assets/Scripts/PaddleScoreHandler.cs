using ScriptableObjs;
using UnityEngine;

public class PaddleScoreHandler : MonoBehaviour
{
    public IntVariable score;
    public IntVariable winScore;
    public ColorVariable color;
    public GameEvent playerWonEvent;
    public GameEvent gameWonEvent;
    public GameEvent scoreUpdatedEvent;

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = color.RuntimeValue;
    }

    public void OnPlayerScore()
    {
        score.RuntimeValue += 1;
        scoreUpdatedEvent.Raise();

        if (score.RuntimeValue < winScore.RuntimeValue) return;
        playerWonEvent.Raise();
        gameWonEvent.Raise();
    }
    
    public void OnGameReset()
    {
        score.RuntimeValue = score.initialValue;
    }
}
