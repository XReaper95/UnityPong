using ScriptableObjs;
using TMPro;
using UnityEngine;

public class GameWonTextHandler: MonoBehaviour
{
    public StringVariable player1Name;
    public ColorVariable player1Color;
    public StringVariable player2Name;
    public ColorVariable player2Color;
    
    private TextMeshProUGUI _textMeshPro;

    private void Start()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        _textMeshPro.enabled = false;
    }

    public void OnPlayer1Won()
    {
        var modifiedText = _textMeshPro.text.Replace("?????", player1Name.RuntimeValue);
        _textMeshPro.text = modifiedText;
        _textMeshPro.color = player1Color.RuntimeValue;
    }
    
    public void OnPlayer2Won()
    {
        var modifiedText = _textMeshPro.text.Replace("?????", player2Name.RuntimeValue);
        _textMeshPro.text = modifiedText;
        _textMeshPro.color = player2Color.RuntimeValue;
    }
}
