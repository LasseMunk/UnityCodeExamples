using System.Collections;
using UnityEngine;

namespace FiniteStateMachine
{
    public class State1 : State
    {
        
        public State1(StateMachine stateMachine) : base(stateMachine)
        {
            // information from GameManager
        }
        
        public override IEnumerator Start()
        {
            Debug.Log("this is State1 start method");
            DoSomethingInState1();
            
            yield break;
            
            // change to state2 after 1 second
            // yield return new WaitForSeconds(1f); // wait 1 second
            // gameManager.SetState(new State2(gameManager));
        }

        public override IEnumerator DoSomething()
        {
            Debug.Log("State 1 did something");
            yield break;
        }

        private void DoSomethingInState1()
        {
            Debug.Log("I'm doing something in state1");
        }
    }
}
