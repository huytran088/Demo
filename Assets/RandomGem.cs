using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGem : MonoBehaviour
{
    [SerializeField] private Gem gem1;

    [SerializeField] private Gem gem2;

    private void Start()
    {
        int i = Random.Range(1, 3);

        if (i == 1)
        {
            gem1.isFake = true;
        }
        else if (i == 2)
        {
            gem2.isFake = true;
        }
    }
}
