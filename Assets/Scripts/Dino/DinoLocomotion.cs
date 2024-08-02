using UnityEngine;

public class DinoLocomotion : MonoBehaviour
{
    [SerializeField] DinoManager dinoManager;
    [SerializeField] Rigidbody dinoRigidbody;
    [SerializeField] BoxCollider dinoBoxCollider;
    [SerializeField] Animator dinoAnimator;
    //[SerializeField] InputManager inputManager;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] float radiusGroundCheck = 0.5f;
    // Dino Animator
    [SerializeField] Vector3 defaultCenterBoxCollider;
    [SerializeField] float yOffsetCollider;
    [SerializeField] float jumpForce;
    [SerializeField] bool isFallForceApplied;
    [SerializeField] float fallForce;

    private void Awake()
    {
        defaultCenterBoxCollider = dinoBoxCollider.center;
    }

    private void FixedUpdate()
    {
        if (dinoRigidbody.velocity.y < 0f && !isFallForceApplied)
        {
            dinoRigidbody.velocity -= Vector3.up * fallForce;
            isFallForceApplied = true;
            dinoAnimator.SetBool("jumpPressed", false);
        }
        else if (transform.position.y >= 4f)
            dinoRigidbody.velocity = Vector3.zero;

        if (isFallForceApplied && transform.position.y < 1.8f)
            dinoBoxCollider.center = defaultCenterBoxCollider;
    }

    private void Update()
    {
        dinoManager.isGrounded = Physics.CheckSphere(transform.position, radiusGroundCheck, groundLayer);
        dinoAnimator.SetBool("isGrounded", dinoManager.isGrounded);
    }

    public void HandleJump()
    {
        if (dinoManager.isGrounded)
        {
            dinoRigidbody.velocity = Vector3.up * jumpForce;
            isFallForceApplied = false;

            dinoAnimator.SetBool("jumpPressed", true);

            dinoBoxCollider.center += Vector3.up * yOffsetCollider;

            AudioManager.instance.PlayJumpEffect();
        }

        // Add animations
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radiusGroundCheck);

        //Gizmos.color = Color.yellow;
        //float rayRange = detectionRadius;
        //Quaternion leftRayRotation = Quaternion.AngleAxis(minimumDetectionAngle, Vector3.up);
        //Quaternion rightRayRotation = Quaternion.AngleAxis(maximumDetectionAngle, Vector3.up);
        //Vector3 leftRayDirection = leftRayRotation * transform.forward;
        //Vector3 rightRayDirection = rightRayRotation * transform.forward;
        //Gizmos.DrawRay(transform.position, leftRayDirection * rayRange);
        //Gizmos.DrawRay(transform.position, rightRayDirection * rayRange);
    }
}
