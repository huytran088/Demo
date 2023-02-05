using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{

    public Transform player;
    // Update is called once per frame
    void LateUpdate ()
    {
        Vector3 position = player.transform.position + new Vector3(0, 0.2f, 0);
        transform.position = position + new Vector3(0, 0, -5.5f);
    }
    
}
