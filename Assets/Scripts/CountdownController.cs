using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountdownController : MonoBehaviour
{
    public TextMeshProUGUI countdownTextField;
    public GameplayManager gameplayManager = null;
    public bool isIdle;
    public void InitiateCountdown()
    {
        gameplayManager = GameObject.FindObjectOfType<GameplayManager>();
        StartCoroutine(CountdownCoroutine());
    }

    IEnumerator CountdownCoroutine()
    {
        isIdle = false;
        countdownTextField.text = "3";
        yield return new WaitForSeconds(1.0f);
        countdownTextField.text = "2";
        yield return new WaitForSeconds(1.0f);
        countdownTextField.text = "1";
        yield return new WaitForSeconds(1.0f);
        countdownTextField.text = "Go!";
        // start game
        isIdle = true;
        gameplayManager.StartGame();
        yield return new WaitForSeconds(1.0f);
        countdownTextField.text = "";
        yield return null;
    }
}
