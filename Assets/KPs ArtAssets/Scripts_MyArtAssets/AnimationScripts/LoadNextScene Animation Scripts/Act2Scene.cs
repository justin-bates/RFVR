using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Act2Scene : MonoBehaviour
    //Make sure to match your LoadNextScene Script name to your current Scene.
{
    void OnEnable()
    {
        //Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
        SceneManager.LoadScene("Act 3 Scene", LoadSceneMode.Single);
        //In between the "_" you type in the next scene you wanted to load.
    }
}
