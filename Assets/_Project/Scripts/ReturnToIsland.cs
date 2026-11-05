using UnityEngine;

public sealed class ReturnToIsland : MonoBehaviour
{
    [SerializeField] private float resetBelowY = -4f;
    [SerializeField] private Rigidbody _body;

    private Rigidbody body;
    private Vector3 startingPosition;
    private Quaternion startingRotation;

    private void Awake()
    {
        body = _body;
        startingPosition = body.position;
        startingRotation = body.rotation;
    }

    private void FixedUpdate()
    {
        if (body.position.y >= resetBelowY || body.isKinematic)
        {
            return;
        }

        body.linearVelocity = Vector3.zero;
        body.angularVelocity = Vector3.zero;
        body.position = startingPosition;
        body.rotation = startingRotation;
    }
}