using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogText : MonoBehaviour
{
    public Text targetText;
    // Start is called before the first frame update
    void Start()
    {
        this.targetText = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
