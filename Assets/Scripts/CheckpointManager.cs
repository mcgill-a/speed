using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{

    public List<Checkpoint> Checkpoints {  get { return checkpoints; } }
    public Checkpoint CurrentCheckpoint {  get { return checkpoints[currentIdx]; } }
    public static CheckpointManager Instance { get { return Instance; } }

    private List<Checkpoint> checkpoints = new List<Checkpoint>();
    private int currentIdx = 0;
    private static CheckpointManager instance = null;
    private TimeDisplay timeDisplay = null;
    public string currentCourseId;

    void Start()
    {
        instance = this;
        timeDisplay = GameObject.FindObjectOfType<TimeDisplay>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetAllCheckpoints()
    {
        Debug.Log("ResetAllCheckpoints");
        for (int i = 0; i < checkpoints.Count; i++)
        {
            checkpoints[i].triggered = false;
        }
    }

    public void RegisterCheckpoint(Checkpoint checkpoint)
    {
        checkpoints.Add(checkpoint);
        Debug.Log("Checkpoint " + checkpoint.id + " registered");
    }

    public bool AllCheckpointsTriggered()
    {
        bool complete = true;
        foreach (Checkpoint checkpoint in checkpoints)
        {
            if (checkpoint.course_id.Equals(currentCourseId) && !checkpoint.triggered)
            {
                complete = false;
            }
        }
        return complete;
    }

    public bool PreviousCheckpointsTriggered(Checkpoint checkpoint)
    {
        bool complete = true;
        foreach (Checkpoint c in checkpoints)
        {
            if (!c.course_id.Equals("") && c.course_id.Equals(checkpoint.course_id))
            {
                if (c.id < checkpoint.id && !c.triggered)
                {
                    complete = false;
                    break;
                }
            }
            
        }
        return complete;
    }

    public bool CheckpointTriggered(Checkpoint checkpoint)
    {
        currentIdx = checkpoints.IndexOf(checkpoint);
        return checkpoints[currentIdx].triggered;
    }

    public void TriggerCheckpoint(Checkpoint checkpoint)
    {
        currentIdx = checkpoints.IndexOf(checkpoint);
        checkpoints[currentIdx].triggered = true;
    }

    public void UpdateCheckpoint(Checkpoint checkpoint)
    {
        currentIdx = checkpoints.IndexOf(checkpoint);

        if (!CheckpointTriggered(checkpoint) && PreviousCheckpointsTriggered(checkpoint))
        {
            TriggerCheckpoint(checkpoint);
            Debug.Log("Checkpoint " + checkpoint.id + " triggered @ index: " + currentIdx);
            if (checkpoint.type.Equals("Start"))
            {
                currentCourseId = checkpoint.course_id;
                // start the timer
                timeDisplay.StartTimer();
            }
            else if (checkpoint.type.Equals("Finish"))
            {
                if (AllCheckpointsTriggered())
                {
                    // stop the timer
                    timeDisplay.StopTimer();
                    // reset the checkpoints
                    ResetAllCheckpoints();
                }
                else
                {
                    Debug.Log("Not all checkpoints triggered");
                }
            }
        }


       
    }
}
