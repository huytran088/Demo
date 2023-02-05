using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class ChaseTarget : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    [SerializeField] private Collider2D attackHitbox;

    [SerializeField] private Transform player;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private float attackRadius;

    [SerializeField] private float chaseForce;

    public void Attack()
    {

        _animator.SetBool("isAttacking", true);
    }

    public void TurnOnHitbox()
    {
        attackHitbox.enabled = true;
    }

    public void TurnOffHitbox()
    {
        attackHitbox.enabled = false;
        _animator.SetBool("isAttacking", false);
    }


    public void Chase()
    {
        if (Mathf.Abs(player.position.x -  transform.position.x) > attackRadius)
        {
            Debug.Log("Applying " + (player.position - transform.position) *chaseForce * Time.deltaTime);
            rb.AddForce((player.position - transform.position) * chaseForce * Time.deltaTime);
        }
        else
        {
            Attack();
        }
    }
}
