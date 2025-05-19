using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartSceneManager : MonoBehaviour
{
   public void GoGameScene()
   {
        SceneManager.LoadScene("GameScene");
   }
}
