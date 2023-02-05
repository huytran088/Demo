using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpottedEnemy : MonoBehaviour
{

    [SerializeField] private ChaseTarget chaseEnemy;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            chaseEnemy.Chase();
        }
    }
}
