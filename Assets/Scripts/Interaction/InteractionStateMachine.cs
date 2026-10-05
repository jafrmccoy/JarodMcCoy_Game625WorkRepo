using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static InteractionMode;
using static UnityEngine.Timeline.AnimationPlayableAsset;

public class InteractionStateMachine : MonoBehaviour
{
    [SerializeField] private Texture2D[] _cursorSprites;
    [SerializeField] InputActionReference _lookMode;
    [SerializeField] InputActionReference _useMode;

    public IInteractionState CurrentInteractionState { get; private set; }

    public DefaultState defaultState;
    public LookState lookState;
    public GrabState grabState;
    public HoldingState holdingState;

    public static event Action<IInteractionState> InteractionStateChanged;

    public static InteractionStateMachine Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

        defaultState = new DefaultState(null);
        lookState = new LookState(_cursorSprites[0]);
        grabState = new GrabState(_cursorSprites[1]);
        holdingState = new HoldingState(_cursorSprites[2]);
        Initialize(defaultState);
    }

    public void Initialize(IInteractionState state)
    {
        CurrentInteractionState = state;
        CurrentInteractionState.OnEnterInteractState();
    }

    private void Update()
    {
        if (_lookMode.action.WasPressedThisFrame() && CurrentInteractionState != holdingState)
        {
            if (CurrentInteractionState == lookState)
            {
                ChangeToState(defaultState);
            }
            else
            {
                ChangeToState(lookState);
            }
        }

        if (_useMode.action.WasPressedThisFrame() && CurrentInteractionState != holdingState)
        {
            if (CurrentInteractionState == grabState)
            {
                ChangeToState(defaultState);
            }
            else
            {
                ChangeToState(grabState);
            }
        }
    }

    public void ChangeToState(IInteractionState newState)
    {
        CurrentInteractionState.OnExitInteractState();
        CurrentInteractionState = newState;
        CurrentInteractionState.OnEnterInteractState();
        InteractionStateChanged?.Invoke(newState);
    }
}
