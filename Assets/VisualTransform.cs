using UnityEngine;

public class VisualTransform : MonoBehaviour
{
    private Transform target;

    [Tooltip("The fastness")] [SerializeField]
    private float moveSpeed = 5;

    [Tooltip("The maximum range at which the transform snaps to the target object.")] [Min(0)] [SerializeField]
    private float snappingDistance = 0.01f;

    private void OnEnable()
    {
        EventSystem<Transform>.AddListener(EventType.playerMoved, OnPlayerMoved);
    }
    
    private void OnDisable()
    {
        EventSystem<Transform>.RemoveListener(EventType.playerMoved, OnPlayerMoved);
    }

    private void Update()
    {
        if (Vector3.Distance(target.position, transform.position) > snappingDistance)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = target.position;
        }
    }

    public void OnPlayerMoved(Transform target)
    {
        this.target = target;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, .3f);
    }
}