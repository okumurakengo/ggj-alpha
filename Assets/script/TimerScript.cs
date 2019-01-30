using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{

    [SerializeField]
    public int minute;
    [SerializeField]
    private float seconds;
    [SerializeField]
    private float totalSeconds;
    //　前のUpdateの時の秒数
    private float oldSeconds;
    //　タイマー表示用テキスト
    private Text timerText;



    void Start()
    {
        minute = 0;
        seconds = 0f;
        oldSeconds = 0f;
        totalSeconds = 0f;
        timerText = GetComponentInChildren<Text>();
    }

    void Update()
    {
        totalSeconds += Time.deltaTime;
        seconds += Time.deltaTime;
        if (seconds >= 60f)
        {
            minute++;
            seconds = seconds - 60;
        }
        //　値が変わった時だけテキストUIを更新
        if ((int)seconds != (int)oldSeconds)
        {
            timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
        }
        oldSeconds = seconds;
    }

    public float GetTotalSeconds()
    {
        return totalSeconds;
    }
}

