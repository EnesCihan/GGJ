using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInitializer : MonoBehaviour
{
    private void Start()
    {
        if (SceneManager.sceneCount > 1)
        {
            Destroy(gameObject);
        }else
            StartCoroutine(LoadScenesCO());
    }
    private IEnumerator LoadScenesCO()
    {
        yield return SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }
}
