using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scene : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(1000, 500, false);
    }

    public void OnClickMain()
    {
        SceneManager.LoadScene("MainScene");
    }


    public void OnClickExit()
    {
        //コメントにしないとなぜかビルドできなかった okumura1a
        //EditorApplication.isPlaying = false;

        Application.Quit();
    }

    public void OnClickTitle()
    {
        SceneManager.LoadScene("Title");
    }



}
