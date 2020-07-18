using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //public Spawnpoint spawnpoint = null;
    public GameplayManager gameplayManager = null;
    public CarController carController = null;
    public GameObject player;
    public Transform spawn;

    // Start is called before the first frame update
    void Start()
    {
        carController = GameObject.FindObjectOfType<CarController>();
        //spawnpoint = GameObject.FindObjectOfType<Spawnpoint>();
        gameplayManager = GameObject.FindObjectOfType<GameplayManager>();
    }

    public void FreezePlayer()
    {
        carController.disableMovement = true;
    }

    public void UnfreezePlayer()
    {
        carController.disableMovement = false;
    }

    public void TeleportPlayer()
    {
        player.transform.position = spawn.position;
        carController.ResetMovements();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("delete"))
        {
            if (gameplayManager.AttemptAction())
            {
                gameplayManager.InitiateGame();
            }
        }
    }
}
