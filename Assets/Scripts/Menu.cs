using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Text textName;

    public void CloseGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    public void StartGame()
    {
        if(Player.instance.Name!=null)
        {
            SceneManager.LoadScene(1);
        }
    }
    public void Text_Changed(string newtext)
    {
        string name = newtext;
        if (name == Player.instance.Name)
        {
            textName.text = "Best Score: " + Player.instance.Name + " : " + Player.instance.Record;
        }
        else
        {
            Player.instance.Name = name;
            textName.text = "Best Score: " + Player.instance.Name + " : " + Player.instance.Record;
        }
       
    }

}
