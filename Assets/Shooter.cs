using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float coolDown;
    private float lastShot;
    private void Update()
    {
        if (Time.time - lastShot > coolDown)
        {
            Instantiate(bullet, transform.position - new Vector3(0f, 0.1f, 0f), Quaternion.identity);
            lastShot = Time.time;   
        }
    }
}
