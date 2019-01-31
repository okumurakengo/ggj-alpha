using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Score scoreE;

    [SerializeField] float hp = 2;
    [SerializeField] float size = 0.01f;
    [SerializeField] private float speed = 0.005f;
    [SerializeField] float generation = 1;

    Vector2 enemySize;
    float changeRed = 1.0f;
    float changeGreen = 1;
    float changeBlue = 1;
    float changeAlpha = 1.0f;
    float maxhp;
    private Vector3 goalPoint;
    private Nerf_Machine_Gun NerfMachineGun;


    public float Gethp()
    {
        return hp;
    }

    public void Start()
    {
        enemySize = transform.localScale;
        maxhp = hp;//最大ｈｐを設定

       scoreE = GetComponent<Score>();
        NerfMachineGun = GameObject.Find("Nerf_Machine_Gun").GetComponent<Nerf_Machine_Gun>();
    }


    public void FixedUpdate()
    {
        //徐々に拡大
        enemySize.x = enemySize.x + size;
        enemySize.y = enemySize.y + size;
        transform.localScale = enemySize;

        Vector3 position = transform.position;
        Vector3 motionVector = goalPoint - position;
        Vector3 motionVectorDt = motionVector * speed;
        transform.position = position + motionVectorDt;

        if (hp <= 0)
        {
            Debug.Log("a");
            
        }

        //仮ダメージ
        if (Input.GetKey(KeyCode.Space))
        {
            hp = hp - 1;
            
        }

        //カラー表示
        this.GetComponent<SpriteRenderer>().color = new Color(changeRed, changeGreen, changeBlue, changeAlpha);
       
        //ｈｐが最大の半分以下になったらカラー変更
        if (hp <= maxhp / 2)
        {
            changeBlue = -25;
            changeGreen = -25;
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        Bullet bulletComponent = col.gameObject.GetComponent<Bullet>();

        if (bulletComponent == null)
        {
            return;
        }


        Debug.Log(bulletComponent.GetWeaponname());
        switch (bulletComponent.GetWeaponname())
        {
            case "egg bullet":
                hp = hp - 7;
                SpeedDown();
                break;
            case "jewelry":
                hp = hp - 8;
                break;
            case "sponge bullet"://仮
                hp = hp - 1;
                break;
            case "scorpion-alive":
                hp = hp - 10;
                break;
            default:
                Debug.Log(string.Format("エラー: 想定外の武器名 {0}", bulletComponent.GetWeaponname()));
                hp = hp - 5;
                break;
        }

        if (bulletComponent.GetWeaponname() != null)
        {
            NerfMachineGun.run();
        }
    }


    //速度低下
    public void SpeedDown()
    {
        size = size * 0.6f;
    }
    public void Damage()
    {
        hp = hp - 1;
    }


    // 侵略成功位置を定義
    public void SetGoalPoint(Vector3 point)
    {
        goalPoint = point;
    }

    public bool HasReachedGoal()
    {
        return this.transform.position == goalPoint;
    }
}
