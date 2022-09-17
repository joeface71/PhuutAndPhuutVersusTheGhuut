using Cinemachine;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    [field: SerializeField] public InputReader InputReader { get; private set; }

    [field: SerializeField] public CharacterController Controller { get; private set; }
    [field: SerializeField] public CinemachineFreeLook FreeLookCamera { get; private set; }

    [field: SerializeField] public float FreeLookMovementSpeed { get; private set; }



    private void Start()
    {
        SwitchState(new PlayerFreeLookState(this));
    }
}