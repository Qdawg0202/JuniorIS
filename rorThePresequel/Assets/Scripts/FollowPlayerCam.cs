using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerCam : MonoBehaviour
{
    public Transform player;
    public float smoothing;
    public Vector3 offset;

    private void Start()
    {
        offset.z = -1;
        offset.y = 1.5f;
        smoothing = 0.1f;
    }
    void FixedUpdate()
    {
        
        if(player!= null)
        {
            Vector3 movePos = Vector3.Lerp(transform.position, player.transform.position + offset, smoothing);
            transform.position = movePos;
        } 
    }
}
