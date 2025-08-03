using GogoGaga.OptimizedRopesAndCables;
using UnityEngine;

class JumpRope : MonoBehaviour
{
    [SerializeField]  float Force = 5.0f;
    private Rope rope;
    bool isJumping = false;
    float jumpDuration = .15f;

    private float time = 0;
    private float swingDirection = 0;
    void Awake()
    {
        rope = GetComponent<Rope>();
    }

    void FixedUpdate()
    {
        if (!isJumping) return;
        if (rope == null || rope.StartPoint == null || rope.EndPoint == null)
        {
            Debug.Log("rope init failed");
            return;
        }

        Jump();
    }

    void Jump()
    {
        time += Time.fixedDeltaTime;
        if (time >= jumpDuration)
        {
            rope.otherPhysicsFactors = Vector3.zero;
            isJumping = false;
            time = 0;
            return;
        }

        Vector3 p1 = rope.StartPoint.position;
        Vector3 p2 = rope.EndPoint.position;
        Vector3 rotationAxis = (p2 - p1).normalized;

        Vector3 initialRadiusDir = Vector3.ProjectOnPlane(Vector3.down, rotationAxis).normalized;
        float angle = swingDirection * (time/jumpDuration) * 360f;
        Quaternion rotation = Quaternion.AngleAxis(angle, rotationAxis);

        Vector3 currentRadius = rotation * initialRadiusDir;
        Vector3 tangent = Vector3.Cross(rotationAxis, currentRadius).normalized;

        Vector3 jumpVelocity = tangent * Force;

        rope.otherPhysicsFactors = jumpVelocity;
    }

    public void Jump(AttackType attackType)
    {
        if (time != 0) return;
        swingDirection = -1;
        if (attackType == AttackType.Back) swingDirection = 1;
        time = 0;
        isJumping = true;
    }
}