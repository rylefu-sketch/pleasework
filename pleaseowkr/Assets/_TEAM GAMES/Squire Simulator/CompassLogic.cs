using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompassLogic : MonoBehaviour
{
    [Header("References")]
    public Transform player;            // Player/camera transform
    public Transform target;            // The object being tracked
    public RectTransform compassBar;    // The compass bar UI element    
    public RectTransform marker;        // The marker that moves on the compass

    [Header("Properties")]
    public float maxAngle = 90f;        // How far left/right the marker can go until it's off screen
    public float barWidth = 1024f;      // The width of the compass bar in pixels


    // Update is called once per frame
    void Update()
    {
        if (player == null || target == null || compassBar == null || marker == null)
            return;

        // Calculate direction from player to target
        Vector3 dirToTarget = (target.position - player.position).normalized;

        // Angle between player's forward and target's direction
        float angle = Vector3.SignedAngle(player.forward, dirToTarget, Vector3.up);

        // Clamp to a max angle so marker doesn't go off the bar
        angle = Mathf.Clamp(angle, -maxAngle, maxAngle);

        // Convert angle to X position on the compass bar
        float normalized = angle / maxAngle;
        float xPos = normalized * (barWidth / 2f);

        // Apply new position
        marker.anchoredPosition = new Vector2(xPos, marker.anchoredPosition.y);
    }
}
