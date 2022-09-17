using UnityEngine;

public class PlayerAimState : PlayerBaseState
{
    public PlayerAimState(PlayerStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        stateMachine.InputReader.AimEvent += OnCancel;

        stateMachine.Animator.CrossFadeInFixedTime("PistolIdle", 0.1f);
    }

    public override void Exit()
    {
        stateMachine.InputReader.AimEvent -= OnCancel;
    }

    public override void Tick(float deltaTime)
    {
        Vector3 movement = CalculateMovement();

        Move(movement * stateMachine.AimingMovementSpeed, deltaTime);
    }

    private void OnCancel()
    {
        stateMachine.SwitchState(new PlayerFreeLookState(stateMachine));
    }

    private Vector3 CalculateMovement()
    {
        Vector3 movement = Vector3.zero;

        movement.x = stateMachine.InputReader.MovementValue.x;
        movement.y = 0f;
        movement.z = stateMachine.InputReader.MovementValue.y;

        return movement;
    }
}
