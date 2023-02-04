using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInitializer : MonoBehaviour
{
    private void OnEnable()
    {
        if (SceneManager.sceneCount > 1)
        {
            Destroy(gameObject);
        }
        else
            StartCoroutine(LoadScenesCO());
    }
    private IEnumerator LoadScenesCO()
    {
        yield return SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }
}
