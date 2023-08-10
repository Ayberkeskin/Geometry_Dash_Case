using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GeometryDash.Inputs
{
    public class InputManager 
    {
        DefaultAction _input;

        public bool IsJump { get; private set; }

        public InputManager() 
        {
            _input = new DefaultAction();

            _input.Cube.Jump.performed += context => IsJump = context.ReadValueAsButton();

            _input.Enable();

        }   
    }

}
