using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    //load scene from filename
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene (sceneName);
    }

}
