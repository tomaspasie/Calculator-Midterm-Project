using System;
using System.Collections.Generic;
using System.Text;

namespace CalculatorProject.State
{
    // Context Class (State Design Pattern)
    class Context
    {
        private State _state;

        public Context(State state)
        {
            this.State = state;
        }

        public State State
        {
            get { return _state; }
            set
            {
                _state = value;
            }
        }

        public void Request()
        {
            _state.Handle(this);
        }
    }
}
