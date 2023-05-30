using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIscript : MonoBehaviour
{
    
    [SerializeField] private Image heartImage;
    private GameObject[] children;
    public void Start()
    {
        children = new GameObject[3];
        for (int i = 0; i < children.Length; i++)
        {
            Image img = Instantiate(heartImage, transform.position, Quaternion.identity);
            img.transform.SetParent(gameObject.transform);
            children[i] = img.gameObject;
            img.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        }
    }

    public void DeleteHeart(int health)
    {
        Destroy(children[health-1]);
    }

    public void AddHeart(int health)
    {
        Image img = Instantiate(heartImage, transform.position, Quaternion.identity);
        img.transform.SetParent(gameObject.transform);
        children[health - 1] = img.gameObject;
        img.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

    }
}
