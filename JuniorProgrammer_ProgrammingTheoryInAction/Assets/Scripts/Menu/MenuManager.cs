using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputUsername;
    // Start is called before the first frame update
    void Start()
    {
        inputUsername.text = MainManager.instance.GetUsername();
    }

    public void StartGame()
    {
        if (MainManager.instance.CanStartGame(inputUsername.text))
        {
            MainManager.instance.SaveData();
            SceneManager.LoadScene(1);
        }
    }
    public void QuitGame()
    {
        //Save the current data
        MainManager.instance.SaveData();

        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #else
                Application.Quit(); // original code to quit Unity player
        #endif
    }
}
