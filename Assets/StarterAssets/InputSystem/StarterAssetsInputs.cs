using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
    public class StarterAssetsInputs : MonoBehaviour
    {
        [Header("Character Input Values")]
        public Vector2 move;
        public Vector2 look;
        public bool jump;
        public bool sprint;
        public bool aim;
        public bool action;
        public bool shoot;
        public bool esc;

        [Header("Movement Settings")]
        public bool analogMovement;

        [Header("Mouse Cursor Settings")]
        public bool cursorLocked = true;
        public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM
        public void OnMove(InputValue value)
        {
            MoveInput(value.Get<Vector2>());
        }

        public void OnLook(InputValue value)
        {
            if (cursorInputForLook)
            {
                LookInput(value.Get<Vector2>());
            }
        }

        public void OnJump(InputValue value)
        {
            JumpInput(value.isPressed);
        }

        public void OnSprint(InputValue value)
        {
            SprintInput(value.isPressed);
        }
        public void OnAim(InputValue value)
        {
            AimInput(value.isPressed);
        }
        public void OnAction(InputValue value)
        {
            ActionInput(value.isPressed);
        }
        public void OnShoot(InputValue value)
        {
            ShootInput(value.isPressed);
        }
        public void OnEsc(InputValue value)
        {
            EscInput(value.isPressed);
        }
#endif


        public void MoveInput(Vector2 newMoveDirection)
        {
            if (!esc)
                move = newMoveDirection;
        }

        public void LookInput(Vector2 newLookDirection)
        {
            if (!esc)
                look = newLookDirection;
        }

        public void JumpInput(bool newJumpState)
        {
            if (!esc)
                jump = newJumpState;
        }

        public void SprintInput(bool newSprintState)
        {
            if (!esc)
                sprint = newSprintState;
        }
        public void AimInput(bool newAimState)
        {
            if (!esc)
                aim = newAimState;

        }
        public void ActionInput(bool newActionState)
        {
            if (!esc)
                action = newActionState;

        }
        public void ShootInput(bool newShootState)
        {
            if (!esc)
                shoot = newShootState;
        }
        public void EscInput(bool newEscState)
        {
            if (!esc)
                esc = newEscState;
        }

        /*private void OnApplicationFocus(bool hasFocus)
        {
            SetCursorState(cursorLocked);
        }

        /*private void SetCursorState(bool newState)
        {
            Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
        }*/
    }

}