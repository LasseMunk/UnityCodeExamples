using System.Collections;
using UnityEngine;

namespace FiniteStateMachine
{
public class State2 : State
    {
        public State2(GameManager gameManager) : base(gameManager)
        {
            // information from GameManager
        }
        
        public override IEnumerator Start()
        {
            Debug.Log("this is State2 start method");
            ThisIsSpecificForState2();
         
            yield break;
        }

        private void ThisIsSpecificForState2()
        {
            Debug.Log("This is specific for state 2");
        }
    }
}