using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Scene : MonoBehaviour
{

    public void OnClickMain()
    {
        SceneManager.LoadScene("MainScene");
    }


    public void OnClickExit()
    {
        EditorApplication.isPlaying = false;

        Application.Quit();
    }

    public void OnClickTitle()
    {
        SceneManager.LoadScene("Title");
    }



}
