using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public PlayerMovement playerMovement = null;
    public GameplayManager gameplayManager = null;
    
    public MouseLook mouseLook = null;
    public Transform spawnpoint;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        gameplayManager = GameObject.FindObjectOfType<GameplayManager>();
        mouseLook = GameObject.FindObjectOfType<MouseLook>();
    }

    public void FreezePlayer()
    {
        playerMovement.disableMovement = true;
        mouseLook.disableMouselook = true;
    }

    public void UnfreezePlayer()
    {
        playerMovement.disableMovement = false;
        mouseLook.disableMouselook = false;
    }

    public void TeleportPlayer()
    {
        Debug.Log("Teleport player: " + player.transform.position + " to spawnpoint: " + spawnpoint.transform.position);
        player.transform.position = spawnpoint.transform.position;
        mouseLook.ResetCameraPosition();
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
