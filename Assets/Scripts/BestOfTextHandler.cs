using ScriptableObjs;
using TMPro;
using UnityEngine;

public class BestOfTextHandler: MonoBehaviour
{
    public IntVariable winScore;

    private TextMeshProUGUI _textMeshProGUI;

    private void Start()
    {
        _textMeshProGUI = GetComponent<TextMeshProUGUI>();
        var newText = _textMeshProGUI.text.Replace("?", winScore.ToString());
        _textMeshProGUI.text = newText;
    }
}
