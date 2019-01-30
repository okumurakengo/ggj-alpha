using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bullet : MonoBehaviour
{

    private Rigidbody2D m_RigidBody2D;
    [SerializeField]
    private Vector3 bulletScale;
    private GameObject bulletFlame;

    string shootFileName;

    public string Weaponname;

    public void Update()
    {
        transform.localScale += bulletScale;

 
    }

    public void BulletFire(GameObject enemy)
    {
        bulletFlame = GameObject.FindGameObjectWithTag("BulletFlame");

       shootFileName = GameObject.Find("Bullet").GetComponent<BulletCustomImage>().shootFileName;

        Sprite sp;
        if (shootFileName == "")
        {
            sp = bulletFlame.GetComponent<Image>().sprite;
        }
        else
        {
            sp = Resources.Load<Sprite>(shootFileName);
        }

        gameObject.GetComponent<SpriteRenderer>().sprite = sp;

        Rigidbody2D m_RigidBody2D = GetComponent<Rigidbody2D>();
        transform.LookAt(enemy.transform);
        m_RigidBody2D.velocity = transform.forward * 3;
        transform.rotation = Quaternion.Euler(0,0,0);

        Weaponname = sp.name;
        Debug.Log(Weaponname+"Bullet");
        
    }


    public string GetWeaponname()
    {
        return Weaponname;
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Enemy")
        {
            this.gameObject.SetActive(false);
        }
    }
}
