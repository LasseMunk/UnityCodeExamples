using UnityEngine;

// https://www.youtube.com/watch?v=5PTd0WdKB-4 see from 5:34
// https://www.youtube.com/watch?v=G1bd75R10m4

namespace  FiniteStateMachine
{
    public abstract class StateMachine : MonoBehaviour
    {
        // keeps track of state object
        // protected - deriving class can delegate behaviour down to current state
        protected State currentState;
        
        // derived State classes will take the responsibility of setting the state 
        // of the state machine
        protected void SetState(State state)
        {
            currentState = state;
            // each states start method should be triggered when we change state
            // coroutines to enable morphing parameters 
            StartCoroutine(currentState.Start());
        }
    }
}
