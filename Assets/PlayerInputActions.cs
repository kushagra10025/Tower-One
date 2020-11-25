// GENERATED AUTOMATICALLY FROM 'Assets/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""9146c8c7-dea1-475e-809d-101ee5945b61"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""05d65226-c2e7-4665-9d6b-d0c9d8bca747"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PickupDropTower"",
                    ""type"": ""Button"",
                    ""id"": ""432d1b27-994d-413e-a1c2-b27a94a81aa3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""14bc417a-041e-4331-8d97-7c394e30d61e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""659cfd1d-ae75-48a0-be80-4ca3a04b0eb8"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""87920a5c-4c10-4fba-b0c8-0a84a1a69911"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""6fbba709-f1c8-466a-8121-cd758125bf10"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7c5ef047-cfa1-4fd6-a0a4-a3eec08af225"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""10450305-7f5e-4842-82e4-dad17b2b19bc"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Arrow"",
                    ""id"": ""6b6a1746-b474-4bc7-8b66-27cfe9d3deb9"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2b6530b7-42a3-40d7-95b7-1fae46294212"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""681bb701-03d2-487f-baf4-aa5c8196701d"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""afffabaf-6fcd-423b-8d84-d6d40111e946"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""47fe9806-e17b-4fce-a73e-63f1615e2bc0"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""179cd9fc-14c0-47ce-8e58-47bf1b595a52"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PickupDropTower"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fca381ba-80b2-4adb-9642-02f6b44495c1"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Debug"",
            ""id"": ""a17d7447-904e-4100-87b9-9cb5e4be8900"",
            ""actions"": [
                {
                    ""name"": ""ReduceHealth"",
                    ""type"": ""Button"",
                    ""id"": ""fedb2a93-83ac-43ea-a470-34d154a571e6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""IncreaseHealth"",
                    ""type"": ""Button"",
                    ""id"": ""cde9ddca-79cd-4ac7-a697-93190cb99d53"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ReduceEnemyHealth"",
                    ""type"": ""Button"",
                    ""id"": ""6d970189-a804-4d24-9bb9-9c451941f66a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""IncreaseEnemyHealth"",
                    ""type"": ""Button"",
                    ""id"": ""9ccdb1ea-da11-41ed-8c4b-81792c089237"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""IncreaseRadius"",
                    ""type"": ""Button"",
                    ""id"": ""50b243e5-5cea-4524-bc73-b43a3f2b43df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ReduceRadius"",
                    ""type"": ""Button"",
                    ""id"": ""4eb99b79-7afc-44f2-9486-3540dc9e2b34"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""NextScene"",
                    ""type"": ""Button"",
                    ""id"": ""d2d1a448-68e0-4f4f-b267-7e7617ca5322"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PreviousScene"",
                    ""type"": ""Button"",
                    ""id"": ""04ddfcf8-3b8f-4671-8540-a1b41124fc66"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""bfd1ba18-9b15-4b48-b323-ea574cf643d3"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""IncreaseHealth"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5da036a-3a87-4e0a-a108-3e2bd37e3734"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReduceHealth"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b4f172e-9c21-4e30-a228-eed04dd18224"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReduceEnemyHealth"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3b801e28-9200-49bc-ac13-611660e7998f"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""IncreaseEnemyHealth"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aae74032-2032-4fb3-a552-5452bf7bf763"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""IncreaseRadius"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""24215d65-3d62-4a68-b530-567f80bfb31c"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReduceRadius"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c34ead12-f046-4ece-936a-7dcd13bb99a6"",
                    ""path"": ""<Keyboard>/leftBracket"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""NextScene"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4862abf3-6637-45aa-be09-961b0fdc5249"",
                    ""path"": ""<Keyboard>/rightBracket"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PreviousScene"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_PickupDropTower = m_Player.FindAction("PickupDropTower", throwIfNotFound: true);
        m_Player_Pause = m_Player.FindAction("Pause", throwIfNotFound: true);
        // Debug
        m_Debug = asset.FindActionMap("Debug", throwIfNotFound: true);
        m_Debug_ReduceHealth = m_Debug.FindAction("ReduceHealth", throwIfNotFound: true);
        m_Debug_IncreaseHealth = m_Debug.FindAction("IncreaseHealth", throwIfNotFound: true);
        m_Debug_ReduceEnemyHealth = m_Debug.FindAction("ReduceEnemyHealth", throwIfNotFound: true);
        m_Debug_IncreaseEnemyHealth = m_Debug.FindAction("IncreaseEnemyHealth", throwIfNotFound: true);
        m_Debug_IncreaseRadius = m_Debug.FindAction("IncreaseRadius", throwIfNotFound: true);
        m_Debug_ReduceRadius = m_Debug.FindAction("ReduceRadius", throwIfNotFound: true);
        m_Debug_NextScene = m_Debug.FindAction("NextScene", throwIfNotFound: true);
        m_Debug_PreviousScene = m_Debug.FindAction("PreviousScene", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_PickupDropTower;
    private readonly InputAction m_Player_Pause;
    public struct PlayerActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @PickupDropTower => m_Wrapper.m_Player_PickupDropTower;
        public InputAction @Pause => m_Wrapper.m_Player_Pause;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @PickupDropTower.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPickupDropTower;
                @PickupDropTower.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPickupDropTower;
                @PickupDropTower.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPickupDropTower;
                @Pause.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @PickupDropTower.started += instance.OnPickupDropTower;
                @PickupDropTower.performed += instance.OnPickupDropTower;
                @PickupDropTower.canceled += instance.OnPickupDropTower;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Debug
    private readonly InputActionMap m_Debug;
    private IDebugActions m_DebugActionsCallbackInterface;
    private readonly InputAction m_Debug_ReduceHealth;
    private readonly InputAction m_Debug_IncreaseHealth;
    private readonly InputAction m_Debug_ReduceEnemyHealth;
    private readonly InputAction m_Debug_IncreaseEnemyHealth;
    private readonly InputAction m_Debug_IncreaseRadius;
    private readonly InputAction m_Debug_ReduceRadius;
    private readonly InputAction m_Debug_NextScene;
    private readonly InputAction m_Debug_PreviousScene;
    public struct DebugActions
    {
        private @PlayerInputActions m_Wrapper;
        public DebugActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @ReduceHealth => m_Wrapper.m_Debug_ReduceHealth;
        public InputAction @IncreaseHealth => m_Wrapper.m_Debug_IncreaseHealth;
        public InputAction @ReduceEnemyHealth => m_Wrapper.m_Debug_ReduceEnemyHealth;
        public InputAction @IncreaseEnemyHealth => m_Wrapper.m_Debug_IncreaseEnemyHealth;
        public InputAction @IncreaseRadius => m_Wrapper.m_Debug_IncreaseRadius;
        public InputAction @ReduceRadius => m_Wrapper.m_Debug_ReduceRadius;
        public InputAction @NextScene => m_Wrapper.m_Debug_NextScene;
        public InputAction @PreviousScene => m_Wrapper.m_Debug_PreviousScene;
        public InputActionMap Get() { return m_Wrapper.m_Debug; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DebugActions set) { return set.Get(); }
        public void SetCallbacks(IDebugActions instance)
        {
            if (m_Wrapper.m_DebugActionsCallbackInterface != null)
            {
                @ReduceHealth.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnReduceHealth;
                @ReduceHealth.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnReduceHealth;
                @ReduceHealth.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnReduceHealth;
                @IncreaseHealth.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnIncreaseHealth;
                @IncreaseHealth.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnIncreaseHealth;
                @IncreaseHealth.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnIncreaseHealth;
                @ReduceEnemyHealth.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnReduceEnemyHealth;
                @ReduceEnemyHealth.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnReduceEnemyHealth;
                @ReduceEnemyHealth.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnReduceEnemyHealth;
                @IncreaseEnemyHealth.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnIncreaseEnemyHealth;
                @IncreaseEnemyHealth.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnIncreaseEnemyHealth;
                @IncreaseEnemyHealth.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnIncreaseEnemyHealth;
                @IncreaseRadius.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnIncreaseRadius;
                @IncreaseRadius.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnIncreaseRadius;
                @IncreaseRadius.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnIncreaseRadius;
                @ReduceRadius.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnReduceRadius;
                @ReduceRadius.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnReduceRadius;
                @ReduceRadius.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnReduceRadius;
                @NextScene.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnNextScene;
                @NextScene.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnNextScene;
                @NextScene.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnNextScene;
                @PreviousScene.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnPreviousScene;
                @PreviousScene.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnPreviousScene;
                @PreviousScene.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnPreviousScene;
            }
            m_Wrapper.m_DebugActionsCallbackInterface = instance;
            if (instance != null)
            {
                @ReduceHealth.started += instance.OnReduceHealth;
                @ReduceHealth.performed += instance.OnReduceHealth;
                @ReduceHealth.canceled += instance.OnReduceHealth;
                @IncreaseHealth.started += instance.OnIncreaseHealth;
                @IncreaseHealth.performed += instance.OnIncreaseHealth;
                @IncreaseHealth.canceled += instance.OnIncreaseHealth;
                @ReduceEnemyHealth.started += instance.OnReduceEnemyHealth;
                @ReduceEnemyHealth.performed += instance.OnReduceEnemyHealth;
                @ReduceEnemyHealth.canceled += instance.OnReduceEnemyHealth;
                @IncreaseEnemyHealth.started += instance.OnIncreaseEnemyHealth;
                @IncreaseEnemyHealth.performed += instance.OnIncreaseEnemyHealth;
                @IncreaseEnemyHealth.canceled += instance.OnIncreaseEnemyHealth;
                @IncreaseRadius.started += instance.OnIncreaseRadius;
                @IncreaseRadius.performed += instance.OnIncreaseRadius;
                @IncreaseRadius.canceled += instance.OnIncreaseRadius;
                @ReduceRadius.started += instance.OnReduceRadius;
                @ReduceRadius.performed += instance.OnReduceRadius;
                @ReduceRadius.canceled += instance.OnReduceRadius;
                @NextScene.started += instance.OnNextScene;
                @NextScene.performed += instance.OnNextScene;
                @NextScene.canceled += instance.OnNextScene;
                @PreviousScene.started += instance.OnPreviousScene;
                @PreviousScene.performed += instance.OnPreviousScene;
                @PreviousScene.canceled += instance.OnPreviousScene;
            }
        }
    }
    public DebugActions @Debug => new DebugActions(this);
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnPickupDropTower(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IDebugActions
    {
        void OnReduceHealth(InputAction.CallbackContext context);
        void OnIncreaseHealth(InputAction.CallbackContext context);
        void OnReduceEnemyHealth(InputAction.CallbackContext context);
        void OnIncreaseEnemyHealth(InputAction.CallbackContext context);
        void OnIncreaseRadius(InputAction.CallbackContext context);
        void OnReduceRadius(InputAction.CallbackContext context);
        void OnNextScene(InputAction.CallbackContext context);
        void OnPreviousScene(InputAction.CallbackContext context);
    }
}
