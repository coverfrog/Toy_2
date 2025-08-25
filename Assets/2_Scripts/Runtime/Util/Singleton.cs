using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    public static T Instance
    {
        get
        {
            if (_instance != null)
                return _instance;

            _instance = FindAnyObjectByType<T>();
            
            if (_instance != null)
                return _instance;
            
            _instance = new GameObject(typeof(T).Name).AddComponent<T>();
                
            return _instance;
        }
    }
    
    private static T _instance;
    
   protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}