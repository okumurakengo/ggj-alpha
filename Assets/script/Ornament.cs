using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ornament : MonoBehaviour
{


    private GameObject ornamentFlame;

    // Start is called before the first frame update
    void Start()
    {
        ornamentFlame = GameObject.FindGameObjectWithTag("OrnamentFlame");

        Image image = ornamentFlame.GetComponent<Image>();
        gameObject.GetComponent<SpriteRenderer>().sprite = image.sprite;


    }

    // Update is called once per frame
    void Update()
    {

    }
    //void OnTriggerEnter2D(Collider2D col)
    //{
    //    FindObjectOfType<Enemy>().Damage();
    //    FindObjectOfType<Enemy>().SpeedDown();
    //}

}
