using System.Collections;
using UnityEngine;

public class DinoManager : MonoBehaviour
{
    [SerializeField] Rigidbody dinoRigidbody;
    [SerializeField] InputManager inputManager;
    // Flags to do somethiong
    [SerializeField] bool isJumping;
    public bool isGrounded;

    [Header("Modes Settings")]
    [SerializeField] float angleRotatingSpeed;

    // TODO GroundChecking
    private void Update()
    {

        // HandleInput
        inputManager.HandleJumpInput();
    }

    #region Rotating Dino Mode
    public void StartRotateDino(float timeDuration)
    {
        StartCoroutine(nameof(RotateDino), timeDuration);
    }

    IEnumerator RotateDino(float timeDuration)
    {
        Quaternion previousRotation = transform.rotation;
        float timePass = 0f;
        while (timePass < timeDuration)
        {
            transform.RotateAround(transform.position, transform.up, angleRotatingSpeed * Time.deltaTime);
            timePass += Time.deltaTime;
            yield return null;
        }
        transform.rotation = previousRotation;
    }
    #endregion

    #region No Gravity
    public void StartNoGravity(float timeDuration)
    {
        StartCoroutine(nameof(NoGravity), timeDuration - 0.1f);
    }

    IEnumerator NoGravity(float timeDuration)
    {
        float timePass = 0f;
        dinoRigidbody.useGravity = false;
        while (timePass < timeDuration)
        {
            timePass += Time.deltaTime;
            yield return null;
        }
        dinoRigidbody.useGravity = true;
    }
    #endregion

    #region Mini Dino
    public void StartMiniDino(float timeDuration)
    {
        StartCoroutine(nameof(MiniDino), timeDuration);
    }

    IEnumerator MiniDino(float timeDuration)
    {
        Vector3 previousDinoScale = transform.localScale;
        float timePass = 0f;
        transform.localScale = Vector3.one;
        while (timePass < timeDuration)
        {
            timePass += Time.deltaTime;
            yield return null;
        }
        transform.localScale = previousDinoScale;
    }
    #endregion
}
