using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    public float currentHealth;

    private void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(enemy);
        }
    }
}
