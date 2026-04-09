using UnityEngine;

public class SteeringManager : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 5f;

    public Transform target;

    private Vector3 wanderTarget;
    private float wanderRadius = 5f;

    private enum Behavior { None, Wander, Seek, Arrive }
    private Behavior currentBehavior;

    void Update()
    {
        switch (currentBehavior)
        {
            case Behavior.Wander:
                Wander();
                break;
            case Behavior.Seek:
                Seek();
                break;
            case Behavior.Arrive:
                Arrive();
                break;
        }
    }

    public void ActivateWander()
    {
        currentBehavior = Behavior.Wander;
        wanderTarget = GetRandomPoint();
    }

    public void ActivateSeek(Transform t)
    {
        target = t;
        currentBehavior = Behavior.Seek;
    }

    public void ActivateArrive(Transform t)
    {
        target = t;
        currentBehavior = Behavior.Arrive;
    }

    public void Stop()
    {
        currentBehavior = Behavior.None;
    }

    void Wander()
    {
        if (Vector3.Distance(transform.position, wanderTarget) < 1f)
            wanderTarget = GetRandomPoint();

        MoveTowards(wanderTarget);
    }

    void Seek()
    {
        if (target == null) return;
        MoveTowards(target.position);
    }

    void Arrive()
    {
        if (target == null) return;

        float distance = Vector3.Distance(transform.position, target.position);
        float currentSpeed = speed;

        if (distance < 3f)
            currentSpeed = speed * (distance / 3f);

        MoveTowards(target.position, currentSpeed);
    }

    void MoveTowards(Vector3 targetPos, float customSpeed = -1)
    {
        float moveSpeed = customSpeed > 0 ? customSpeed : speed;

        Vector3 dir = (targetPos - transform.position).normalized;

        transform.position += dir * moveSpeed * Time.deltaTime;

        if (dir != Vector3.zero)
        {
            Quaternion rot = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, rotationSpeed * Time.deltaTime);
        }
    }

    Vector3 GetRandomPoint()
    {
        Vector3 random = Random.insideUnitSphere * wanderRadius;
        random.y = 0;
        return transform.position + random;
    }
}