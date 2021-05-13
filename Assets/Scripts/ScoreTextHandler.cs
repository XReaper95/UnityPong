using ScriptableObjs;
using TMPro;
using UnityEngine;

public class ScoreTextHandler: MonoBehaviour
{
    public IntVariable score;
    public ColorVariable color;

    private TextMeshProUGUI _textMeshProGUI;

    private void Start()
    {
        _textMeshProGUI = GetComponent<TextMeshProUGUI>();
        _textMeshProGUI.color = color.RuntimeValue;
    }

    public void OnPlayerScore()
    {
        _textMeshProGUI.text = score.ToString();
    }
    
    public void OnGameReset()
    {
        _textMeshProGUI.text = score.initialValue.ToString();
    }
}
