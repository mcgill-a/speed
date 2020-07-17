using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{

    public PlayerManager playerManager = null;
    public CountdownController countdownController = null;
    private TimeDisplay timeDisplay = null;
    public CheckpointManager checkpointManager = null;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.FindObjectOfType<PlayerManager>();
        countdownController = GameObject.FindObjectOfType<CountdownController>();
        timeDisplay = GameObject.FindObjectOfType<TimeDisplay>();
        checkpointManager = GameObject.FindObjectOfType<CheckpointManager>();
        InitiateGame();
    }

    public bool AttemptAction()
    {
        bool prevent = false;
        if (countdownController.isIdle)
        {
            prevent = true;
        }

        return prevent;
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
