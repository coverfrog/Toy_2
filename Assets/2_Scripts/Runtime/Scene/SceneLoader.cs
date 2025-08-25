using System;
using System.Collections;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static void LoadScene(
        string name, 
        MonoBehaviour mono, 
        Action onStart, 
        Action<float> onProgress,
        Action onComplete)
    {
        mono.StartCoroutine(LoadSceneCoroutine(name, onStart, onProgress, onComplete));
    }

    private static IEnumerator LoadSceneCoroutine(
        string name,
        Action onStart,
        Action<float> onProgress,
        Action onComplete)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);

        if (op == null)
        {
            Debug.Assert(false, "씬 로딩 실패");
            yield break;
        }

        int activeSceneCount = SceneManager.loadedSceneCount;
        for (int i = 0; i < activeSceneCount; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);

            if (scene.name.ToLower() == "global")
            {
                continue;
            }
            
            _ = SceneManager.UnloadSceneAsync(scene);
        }

        UIPageLoading loading = UIManager.Instance.PageLoading;
        loading.OnProgress(0);
        loading.SetActive(true);
        
        onStart?.Invoke();
        
        op.allowSceneActivation = false;
        op.completed += _ =>
        {
            onComplete?.Invoke();
            loading.SetActive(false);
        };

        while (op.progress < 0.9f)
        {
            float progress = Mathf.Clamp01(op.progress / 0.9f);
            
            onProgress?.Invoke(progress);
            loading.OnProgress(progress);
            
            yield return null;
        }
        
        op.allowSceneActivation = true;
    }
}