using System.Collections;
using UnityEngine;

public class LaunchButtonHandler : MonoBehaviour
{

    public GameObject launchButtonObject;

    private Coroutine _buttonCoroutine;

    private void Start()
    {
        launchButtonObject.SetActive(true);
    }

    public void OnGameStart()
    {
        launchButtonObject.SetActive(false);
    }

    public void OnPlayerPoint()
    {
        _buttonCoroutine = StartCoroutine(ButtonCoroutine());
    }
    
    public void OnGameWon()
    {
        StopCoroutine(_buttonCoroutine);
        launchButtonObject.SetActive(false);
    }

    private IEnumerator ButtonCoroutine()
    {
        yield return new WaitForSeconds(1.6f);
        
        launchButtonObject.SetActive(true);
    }
}
