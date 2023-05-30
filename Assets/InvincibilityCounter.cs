using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvincibilityCounter : MonoBehaviour
{
    private Text text;
    
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();
        ResetText();
    }

    public void RefreshCounter(int sec)
    {
        text.text = $"Invincibility for: {sec}s";
    }

    public void ResetText()
    {
        text.text = "";
    }
}
