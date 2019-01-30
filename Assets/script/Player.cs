using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public Texture2D cursorTexture;                 //カーソルのテクスチャ
    public CursorMode cursorMode = CursorMode.Auto; //カーソルの表示モード
    public Vector2 hotSpot = Vector2.zero;          //マウスカーソルの当たり範囲

    [SerializeField]
    private GameObject bulletPrefab;               //弾のプレハブ
    [SerializeField]
    private GameObject ornament;                   //置物のプレハブ
    private Camera cam;                            //メインカメラ代入用
    private Vector3 point = new Vector3();         //置物を置く場所
    private bool ornamentSw = false;               //置物判定
    [SerializeField]
    private GameObject bulletFlame;                //キャンバスの弾の画像
    [SerializeField]
    private GameObject ornamentFlame;              //キャンバスの置物の画像
    private float interval = 0.1f;
    private float nowTime = 0;
    [SerializeField]
    private DragObject m_DragObject;

    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        cam = Camera.main;
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            RayCast2D();
        }
        //ornamentSw = m_DragObject.FireCheck();
    }


    private void RayCast2D()
    {
        /*      置物操作中は発射不可に     */
        if (ornamentSw)
        {
            return;
        }
        /*   弾丸のスプライトがない場合発射不可   */
        if (bulletFlame.GetComponent<Image>().sprite == null)
        {
            return;
        }

        /* メインカメラ上のマウスカーソルのある位置からRayを飛ばす */
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        /*                     レイの詳細設定                      */
        RaycastHit2D hit2D = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

        if (hit2D.collider == null)
        {
            return;
        }

        else if (hit2D.collider.gameObject.tag== "Enemy")
        {
            nowTime += Time.deltaTime;
            if (nowTime > interval)
            {
                /*     引数に指定するため代入    */
                GameObject enemy = hit2D.collider.gameObject;
                /*         クラス取得用          */
                GameObject bullet = Instantiate(bulletPrefab,
                    new Vector3(transform.position.x,
                    transform.position.y, -2),
                    Quaternion.identity);

                bullet.GetComponent<Bullet>().BulletFire(enemy);
                nowTime = 0;
            }
        }
    }

    private void OnGUI()
    {
        Event currentEvent = Event.current;
        /*           マウスの座標を入れる変数          */
        Vector2 mousePos = new Vector2();
        /* 1フレーム経過ごとにマウスのポジションを格納 */
        mousePos.x = currentEvent.mousePosition.x;
        mousePos.y = cam.pixelHeight - currentEvent.mousePosition.y;
        /*                    代入                     */
        point = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane));

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("Result");
        }
    }

    public void OrnamenteDrop()
    {
        if (ornamentFlame.GetComponent<Image>().sprite == null)
        {
            return;
        }
        Instantiate(ornament, point, Quaternion.identity);
    }

}

