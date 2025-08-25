using System;
using UnityEngine;

[Serializable]
public abstract class State<T> : MonoBehaviour
{
    [SerializeField] protected bool isEnter;

    private T _mOwner;

    public State<T> Setup(T owner)
    {
        _mOwner = owner;
        return this;
    }
    
    public void Enter()
    {
        isEnter = true;

#if UNITY_EDITOR && false
        Debug.Log($"{GetType().Name} [ Enter ]");
#endif
        
        OnEnter(_mOwner);
    }

    public void Update()
    {
        if (!isEnter)
            return;

        OnUpdate(_mOwner);
    }

    public void Exit()
    {
        isEnter = false;

#if UNITY_EDITOR && false
        Debug.Log($"{GetType().Name} [ Exit ]");
#endif
        
        OnExit(_mOwner);
    }
    
    protected abstract void OnEnter(T owner);
    
    protected abstract void OnUpdate(T owner);
    
    protected abstract void OnExit(T owner);
}