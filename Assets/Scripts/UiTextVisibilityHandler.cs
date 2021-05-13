using TMPro;
using UnityEngine;

public class UiTextVisibilityHandler: MonoBehaviour
{
    private TextMeshProUGUI _textMeshPro;

    private void Start()
    {
        _textMeshPro = GetComponent<TextMeshProUGUI>();
        _textMeshPro.enabled = false;
    }
}
