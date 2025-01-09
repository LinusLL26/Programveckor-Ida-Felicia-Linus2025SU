using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;

    void LateUpdate()
    {
        if (player == null)
        {
            Debug.LogWarning("Player not assigned to CameraFollow script.");
            return;
        }

       
        transform.position = player.position;
    }
}
