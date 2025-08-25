using System;
using System.Collections.Generic;

[Serializable]
public class StateTransition<T>
{
    public T Owner { get; }
    
    public State<T> FromState { get; }
    
    public State<T> ToState { get; }
    
    private Func<bool> IsTransition { get; }

    public bool IsTransAble(State<T> state) => IsTransition() && (FromState == null || state == FromState);
    
    public StateTransition(T owner, State<T> fromState, State<T> toState, Func<bool> isTransition)
    {
        Owner = owner;
        FromState = fromState;
        ToState = toState;
        IsTransition = isTransition;
    }
}