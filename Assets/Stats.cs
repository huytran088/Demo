using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField] private float MaxHealth;
    [SerializeField] private float Dmg;

    public float currentDmg;
    public float Health;

    [SerializeField] private bool isAlive;

    public static Stats instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Health = MaxHealth;
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
