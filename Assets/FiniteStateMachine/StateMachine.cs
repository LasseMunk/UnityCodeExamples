using NaughtyAttributes;
using UnityEngine;

namespace FiniteStateMachine
{
    // StateMachine derives from mono behaviour
    public class StateMachine : MonoBehaviour
    {
        private State _currentState;
        
        [SerializeField] private GameObject videoPlayer1;
        [SerializeField] private GameObject videoPlayer2;
        
        // derived State classes will take the responsibility of setting the state 
        // of the state machine
        

        [SerializeField] private GameObject myCube;
        private void SetState(State state)
        {
            _currentState = state;
            // each states start method should be triggered when we change state
            // coroutines to enable morphing parameters 
            StartCoroutine(_currentState.Start());
        }

       
        
        [Button]
        public void OnChangeStateTo1()
        {
            SetState(new State1(this));
        }      
        
        [Button]
        public void OnChangeStateTo2()
        {
            SetState(new State2(this));
        }
    }
}