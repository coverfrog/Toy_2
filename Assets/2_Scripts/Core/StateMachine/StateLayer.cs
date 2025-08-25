
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class StateLayer<T> where T : Component
{
    private readonly T _mOwner;
    private readonly int _mIndex;
    
    public State<T> CurrentState { get; private set; }
    public State<T> PreviousState { get; private set; }
    public State<T> GlobalState { get; private set; }

    public Dictionary<Type, State<T>> States { get; } = new();
    
    public List<StateTransition<T>> Transitions { get; } = new();
    
    public StateLayer(T owner, int index)
    {
        _mOwner = owner;
        _mIndex = index;
    }

    public void AddState<TState>(T owner) where TState : State<T>
    {
        States.Add(typeof(TState), _mOwner.gameObject.AddComponent<TState>().Setup(owner));
    }

    public void AddTransition<TFrom, TTo>(Func<bool> isTransition)
        where TFrom : State<T>
        where TTo : State<T>
    {
        State<T> from = States[typeof(TFrom)];
        State<T> to = States[typeof(TTo)];
        StateTransition<T> transition = new StateTransition<T>(_mOwner, from, to, isTransition);

        Transitions.Add(transition);
    }

    public void AddAnyTransition<TTo>(Func<bool> isTransition)
        where TTo : State<T>
    {
        State<T> to = States[typeof(TTo)];
        StateTransition<T> transition = new StateTransition<T>(_mOwner, null, to, isTransition);
        
        Transitions.Add(transition);
    }
    
    public void Run()
    {
        ChangeState(States.Values.FirstOrDefault());
    }

    public void ChangeState(State<T> newState)
    {
        if (newState == null)
        {
            Debug.Assert(false, "상태 존재하지 않음");
            return;
        }

        if (newState == CurrentState)
        {
            // Debug.Assert(false, "상태 중복");
            return;
        }
        
        CurrentState?.Exit();
        
        CurrentState = newState;
        PreviousState = CurrentState;
        
        CurrentState?.Enter();
    }

    
}