using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Collider2D _collider;
    [SerializeField] private Animator _animator;
    [SerializeField] private Transform player;
    [SerializeField] private Transform enemy;

    [SerializeField] private EnemyStats stats;

    [SerializeField] private bool flipable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("weapon"))
        {

            if (tag == "egg")
            {
                _animator.SetTrigger("hit");
            }

            else
            {
                stats.currentHealth -= Stats.instance.currentDmg;
            }

            if (flipable)
            {
                if (player.position.x < enemy.position.x)
                {
                    Vector3 enemyDirection = enemy.localScale;
                    enemy.localScale = new Vector3(-enemyDirection.x, enemyDirection.y, enemyDirection.z);
                }
                else if (player.position.x > enemy.position.x)
                {
                    Vector3 enemyDirection = enemy.localScale;
                    enemy.localScale = new Vector3(-enemyDirection.x, enemyDirection.y, enemyDirection.z);
                }
            }
        }
    }
}
