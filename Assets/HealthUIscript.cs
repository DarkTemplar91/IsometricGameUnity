using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HealthUIscript : MonoBehaviour
{
    [SerializeField] private GameObject[] children;
    public void DeleteHeart(int health)
    {
        Destroy(children[health-1]);
    }
}
