using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private PlayerController playerController;

    void Start()
    {
        GameObject playerControllerObject = GameObject.FindWithTag("Player");
        playerController = playerControllerObject.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PickUp(other);
        }
    }

    public void PickUp(Collider player)
    {
        playerController.ammo += 25;

        playerController.fireRate = 0.1f;
        Destroy(gameObject);
    }
}
