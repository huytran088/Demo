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

    public bool obtainedHoney;
    public static Stats instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Health = MaxHealth;
        currentDmg = Dmg;
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

    public void Evolve()
    {
        MaxHealth *= 10;
        Dmg *= 10;

        Health *= 10;
        currentDmg *= 10;

    }
}
