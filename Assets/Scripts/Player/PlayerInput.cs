using System;
using UnityEngine;
using UnityEngine.Events;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        public Vector2 MovementInput
        {
            get;
            private set;
        }
        
        public bool IsHoldingShift { get; private set; }
        public bool IsHoldingControl { get; private set; }
        
        public UnityEvent<Vector2> OnChangeMovementInputValue;

        private void Update()
        {
            GetMovement();
            IsHoldingShift = Input.GetKey(KeyCode.LeftShift);
        }

        private void GetMovement()
        {
            Vector2 newMovementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

            if (newMovementInput.sqrMagnitude == 0 && MovementInput.sqrMagnitude == 0)
                return;

            MovementInput = newMovementInput;
            OnChangeMovementInputValue?.Invoke(MovementInput);
            IsHoldingControl = MovementInput.sqrMagnitude != 0;
        }
    }
}


