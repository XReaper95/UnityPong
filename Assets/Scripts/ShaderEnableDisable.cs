using UnityEngine;

public class ShaderEnableDisable : MonoBehaviour
{
    private MonoBehaviour _shaderScript;
    private void Start()
    {
        _shaderScript = GetComponent<CrtPostProcess>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            _shaderScript.enabled = !_shaderScript.enabled;
        }
    }
}
