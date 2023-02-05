using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Honey : MonoBehaviour
{

    [SerializeField] private float damage;
    [SerializeField] private float sustainTime;

    private float timeSustained;
    private void Start()
    {
       
    }

    private void Update()
    {
        if (timeSustained >= sustainTime && !Stats.instance.obtainedHoney)
        {
            Stats.instance.obtainedHoney = true;
            Debug.Log("Obtained honey");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Stats.instance.Health -= damage * Time.deltaTime;
            timeSustained += Time.deltaTime;

        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyStats>().currentHealth -= damage * Time.deltaTime;
        }
    }
}
