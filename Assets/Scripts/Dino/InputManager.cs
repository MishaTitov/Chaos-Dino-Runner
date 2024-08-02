using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] DinoLocomotion dinoLocomotion;
    TouchControls touchControls;
    InputAction touchPositionInputAction;
    // Define the touch region boundaries
    private Rect touchRegion;

    public bool jumpInput;

    private void Awake()
    {
        touchControls = new TouchControls();
        touchPositionInputAction = touchControls.FindAction("TouchPositionInput");
    }

    private void Start()
    {
        touchRegion = new(0f,0f, Screen.width, Screen.height * 0.75f);
    }

    private void OnEnable()
    {

        touchControls.Touch.TouchPressInput.performed += JumpPressed;
        touchControls.Keyboard.KeyboardInput.performed += JumpPressed;

        touchControls.Enable();
        touchPositionInputAction.Enable();
    }

    private void OnDisable()
    {
        touchControls.Touch.TouchPressInput.performed -= JumpPressed;
        touchControls.Keyboard.KeyboardInput.performed -= JumpPressed;

        touchControls.Disable();
        touchPositionInputAction.Disable();
    }

    private void JumpPressed(InputAction.CallbackContext context)
    {
        Vector2 touchPosition = touchPositionInputAction.ReadValue<Vector2>();
        if (touchRegion.Contains(touchPosition) && !GameManager.instance.isGamePaused)
        {
            // Perform the desired action, such as triggering a jump
            jumpInput = true;
        }
    }

    public void HandleJumpInput()
    {
        if (jumpInput && !GameManager.instance.isGameOver)
        {
            jumpInput = false;
            dinoLocomotion.HandleJump();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(touchRegion.center, new Vector3(touchRegion.width, touchRegion.height, 0f));
    }
}
