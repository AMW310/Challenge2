using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    public Transform player;
    public float detectionAngle = 45f; // Adjust this value based on your needs
    public bool chase;

    void Update()
    {
        if (IsPlayerFacingEnemy())
        {
            // The player is facing the enemy
            Debug.Log("Player is facing the enemy!");
            chase = false;
        }
        else
        {
            // The player is not facing the enemy
            Debug.Log("Player is not facing the enemy.");
            chase = true;
        }
    }

    bool IsPlayerFacingEnemy()
    {
        if (player == null)
        {
            // If player is not set, return false
            return false;
        }

        // Calculate the direction from the player to the enemy
        Vector3 toEnemy = transform.position - player.position;
        toEnemy.y = 0f; // Ignore the vertical component

        // Calculate the angle between the player's forward direction and the toEnemy vector
        float angle = Vector3.Angle(player.forward, toEnemy.normalized);

        // Check if the angle is within the detection range
        if (angle < detectionAngle)
        {
            return true;
        }

        return false;
    }
}
