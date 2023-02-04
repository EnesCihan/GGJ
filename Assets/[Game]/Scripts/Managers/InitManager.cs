using System.Collections;
using UnityEngine.SceneManagement;

public class InitManager : Singleton<InitManager>
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
            StartCoroutine(LoadScenesCO(1));
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }
    #endregion
    #region My Methods
    private IEnumerator LoadScenesCO(int sceneIndex)
    {
        yield return SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
    }
    private void OpenGameScene()
    {
        StartCoroutine(LoadScenesCO(2));
    }
    private void CloseGameScene()
    {
        SceneManager.UnloadSceneAsync(2);
    }
    #endregion
    private void OnEnable()
    {
        EventManager.OnLevelStart.AddListener(OpenGameScene);
        EventManager.OnMenu.AddListener(CloseGameScene);

    }
    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener(OpenGameScene);
        EventManager.OnMenu.RemoveListener(CloseGameScene);

    }
}
