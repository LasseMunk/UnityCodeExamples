using NaughtyAttributes;
using UnityEngine;

namespace FiniteStateMachine
{
    public class GameManager : StateMachine
    // StateMachine derives from monobehaviour
    
    {
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