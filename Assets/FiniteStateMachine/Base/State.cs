using System.Collections;

namespace  FiniteStateMachine
{
    
    public abstract class State 
    // it is abstract because future classes should implement it
    {

        // if each state needs information from UsingTheStateMachine
        // then implement in each state
        // protected means deriving classes can access
        protected GameManager gameManager;

        public State(GameManager gm)
        {
            // enables each state to reference the state machine
            gameManager = gm;
        }
        
        public virtual IEnumerator Start()
        {
            yield break;
        }
        
        public virtual IEnumerator DoSomething()
        {
            yield break;
        }
    }
}