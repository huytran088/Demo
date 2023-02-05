using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetHitbox : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("ground"))
        {
            player.SetOnGround(true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("ground"))
        {
            player.SetOnGround(false);
        }
    }
    
}
