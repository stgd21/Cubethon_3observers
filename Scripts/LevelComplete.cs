using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This just sits on the panel with animation to load a new scene once its done
public class LevelComplete : MonoBehaviour
{
    public void LoadNewLevel()
    {
        SceneManager.LoadScene(0);
    }
}
