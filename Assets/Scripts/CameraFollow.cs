using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;          
    public float followSpeed = 5f;     
    public Vector2 offset;             

    void LateUpdate()
    {
        if (player == null)
        {
            return;
        }
        Vector3 targetPosition = new Vector3(player.position.x + offset.x, player.position.y+offset.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}
