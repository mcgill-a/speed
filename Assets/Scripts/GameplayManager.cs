using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    public CarController carController = null;
    public PlayerManager playerManager = null;
    public CountdownController countdownController = null;
    private TimeDisplay timeDisplay = null;
    public CheckpointManager checkpointManager = null;

    void Start()
    {
        carController = GameObject.FindObjectOfType<CarController>();
        playerManager = GameObject.FindObjectOfType<PlayerManager>();
        countdownController = GameObject.FindObjectOfType<CountdownController>();
        timeDisplay = GameObject.FindObjectOfType<TimeDisplay>();
        checkpointManager = GameObject.FindObjectOfType<CheckpointManager>();
        InitiateGame();
    }

    public bool AttemptAction()
    {
        return countdownController.isIdle;
    }

    public void InitiateGame()
    {
        // Reset to starting position
        playerManager.TeleportPlayer();
        // Reset checkpoints
        checkpointManager.ResetAllCheckpoints();
        // Reset timer
        timeDisplay.ResetTimer();
        // Freeze player controls
        playerManager.FreezePlayer();
        // Countdown 3..2..1
        countdownController.InitiateCountdown();
    }

    /// <summary>
    /// Called by countdownController.InitiateCountdown();
    /// </summary>
    public void StartGame()
    {
        playerManager.UnfreezePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
