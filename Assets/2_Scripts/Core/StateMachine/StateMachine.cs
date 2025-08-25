using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class StateMachine<T> where T : Component
{
    private readonly T _mOwner;

    private readonly Dictionary<int, StateLayer<T>> _layers;
    
    public StateMachine(T owner)
    {
        _mOwner = owner;
        _layers = new Dictionary<int, StateLayer<T>>();
    }

    public void Update()
    {
        foreach ((int index, StateLayer<T> layer) in _layers)
        {
            foreach (StateTransition<T> transition in layer.Transitions)
            {
                if (!transition.IsTransAble(layer.CurrentState))
                    continue;

                ChangeState(index, transition.ToState);
            }
        }
    }

    public bool AddState<TState>(int index) where TState : State<T>
    {
        // 레이어 없다면 추가
        if (!TryAddLayer(index)) return false;
        
        // 해당 레이어에 추가
        _layers[index].AddState<TState>(_mOwner);
        
        return true;
    }

    public bool AddTransition<TFromState, TToState>(int index, Func<bool> isTransition)
        where TFromState : State<T>
        where TToState : State<T>
    {
        // 경고 : 동일한 상태인지
        if (typeof(TFromState) == typeof(TToState))
        {
            Debug.Assert(false, "동일한 상태의 추가");
            return false;
        }
        
        // 레이어 없다면 추가
        if (!TryAddLayer(index)) return false;
        
        // 해당 트렌지션 추가
        _layers[index].AddTransition<TFromState, TToState>(isTransition);
        
        return true;
    }
    
    public bool AddAnyTransition<TToState>(int index, Func< bool> isTransition)
        where TToState : State<T>
    {
        // 레이어 없다면 추가
        if (!TryAddLayer(index)) return false;
        
        _layers[index].AddAnyTransition<TToState>(isTransition);
        
        return true;
    }

    
    private bool TryAddLayer(int index)
    {
        if (_layers.ContainsKey(index)) 
            return true;
        
        StateLayer<T> layer = new StateLayer<T>(_mOwner, index);
            
        return _layers.TryAdd(index, layer);
    }

    public void Run()
    {
        foreach ((_, StateLayer<T> layer) in _layers)
        {
            layer.Run();   
        }
    }

    public void ChangeState(int index, State<T> newState)
    {
        _layers[index].ChangeState(newState);
    }


}

