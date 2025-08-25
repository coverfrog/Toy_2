using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneGlobal
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void Init()
    {
#if !UNITY_EDITOR
            SceneManager.LoadScene("Global", LoadSceneMode.Additive);
#endif
    }
}