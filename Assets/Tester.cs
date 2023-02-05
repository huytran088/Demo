using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    public Transform player;
    private Vector3 position;
    public KeyCode restartKey;

    // Start is called before the first frame update
    void Start()
    {
        position = player.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(restartKey))
        {
            player.position = position;
        }
    }
}
