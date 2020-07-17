using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    CheckpointManager manager = null;
    
    public string type;
    public int id = -1;
    public string course_id = "";
    public bool triggered = false;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.FindObjectOfType<CheckpointManager>();
        manager.RegisterCheckpoint(this);
    }


    public void OnTriggerEnter(Collider other)
    {
        manager.UpdateCheckpoint(this);
    }

    public void OnTriggerStay(Collider other)
    {
    }

    public void OnTriggerExit(Collider other)
    {
    }
}
