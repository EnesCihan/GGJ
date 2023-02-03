using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitManager : MonoBehaviour
{
    #region Parameters
    public static InitManager instance = null;
    #endregion
    #region MonoBehaviour Methods
    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            StartCoroutine(LoadScenesCO());
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }
    #endregion
    #region My Methods
    private IEnumerator LoadScenesCO()
    {
        yield return SceneManager.LoadSceneAsync(1, LoadSceneMode.Additive);
        yield return SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);

    }
    #endregion

}
