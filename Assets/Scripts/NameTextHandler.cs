using ScriptableObjs;
using TMPro;
using UnityEngine;


public class NameTextHandler: MonoBehaviour
{
    public StringVariable playerName;
    public ColorVariable color;

    private TextMeshProUGUI _textMeshPro;

    private void Start()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        _textMeshPro.text = playerName.RuntimeValue;
        _textMeshPro.color = color.RuntimeValue;
    }
}
