using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminateZone : MonoBehaviour
{
    [SerializeField] private float EliminationDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Stats.instance.Health -= EliminationDamage;
        }
    }
}
