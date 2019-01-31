using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropObject : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject gameobject;
    public Image iconImage;
    private Sprite nowSprite;
    private Sprite loadSprite;
    public string loadFileName;

    void Start()
    {
        nowSprite = null;
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        if (pointerEventData.pointerDrag == null) return;


        Image droppedImage = pointerEventData.pointerDrag.GetComponent<Image>();

        if (iconImage.name == "BulletSprite" || iconImage.name == "OrnamentSprite")
        {
            iconImage.sprite = droppedImage.sprite;
        }
        else
        {
            loadSprite = Resources.Load<Sprite>(loadFileName = craftedIfMatchingPair(droppedImage, iconImage));
            if (loadFileName != "") iconImage.sprite = loadSprite;
        }


        //iconImage.color = Vector4.one * 0.6f;
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        //if (pointerEventData.pointerDrag == null) return;
        //iconImage.sprite = nowSprite;
        //if (nowSprite == null)
        //    iconImage.color = Vector4.zero;
        //else
        //iconImage.color = Vector4.one;

    }

    public void OnDrop(PointerEventData pointerEventData)
    {
        Image droppedImage = pointerEventData.pointerDrag.GetComponent<Image>();
        iconImage.color = Vector4.one;
        if (iconImage.name == "BulletSprite")
        {
            iconImage.sprite = droppedImage.sprite;
            GameObject.Find("Bullet").GetComponent<BulletCustomImage>().shootFileName = getShootFileName(droppedImage);
        }
        else
        {
            if (loadFileName != "") iconImage.sprite = Resources.Load<Sprite>(loadFileName);
        }
        //iconImage.sprite = droppedImage.sprite;
        //nowSprite = droppedImage.sprite;
    }

    // 画像の組み合わせでクラフト後の画像を返す
    private string craftedIfMatchingPair(Image tmpDroppedImage, Image tmpIconImage)
    {
        string filename;
        if (tmpDroppedImage.sprite.name == "sponge bullet" && tmpIconImage.sprite.name == "proto-gun")
        {
            filename = "sponge-gun";
        }
        else if (tmpDroppedImage.sprite.name == "jewelry" && tmpIconImage.sprite.name == "proto-gun")
        {
            filename = "jewelry-gun";
        }
        else if (tmpDroppedImage.sprite.name == "egg bullet" && tmpIconImage.sprite.name == "proto-gun")
        {
            filename = "egg-gun";
        }
        else
        {
            filename = "";
        }
        return filename;
    }

    // 画像に対して、打つ時に使われる画像は何かを返す
    private string getShootFileName(Image img)
    {
        string filename;
        switch (img.sprite.name)
        {
            case "sponge-gun":
                filename = "sponge bullet";
                break;
            case "egg":
                filename = "egg bullet";
                break;
            case "jewelry-gun":
                filename = "jewelry";
                break;
            case "pepper":
                filename = "pepper-alive";
                break;
            case "egg-gun":
                filename = "egg bullet";
                break;
            case "scorpion":
                filename = "scorpion-alive";
                break;
            default:
                filename = "";
                break;
        }
        return filename;
    }
}
