using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform shooter;
    private Vector3 bulletPos;

    [SerializeField] private float speed;

    [SerializeField] private float damage;

    [SerializeField] private float destroyTime;
    private float init;

    // Start is called before the first frame update
    void Start()
    {
        shooter = GameObject.FindWithTag("Shooter").transform;
        init = Time.time;   
    }

    // Update is called once per frame
    void Update()
    {
        if (shooter != null)
        {
            if (shooter.localScale.x > 0)
            {
                //Shoot
                bulletPos = transform.position;
                transform.position = new Vector3(bulletPos.x + speed * Time.deltaTime, bulletPos.y, bulletPos.z);
            }
            else if (shooter.localScale.x < 0)
            {
                //Shoot
                bulletPos = transform.position;
                transform.position = new Vector3(bulletPos.x - speed * Time.deltaTime, bulletPos.y, bulletPos.z);
            }


        }

        if (Time.time - init > destroyTime)
        {
            Explode();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Stats.instance.Health -= damage;
        }
    }

    private void Explode()
    {
        Destroy(gameObject);
    }
}
