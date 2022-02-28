using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpRange = 2f;
    [SerializeField] private Transform startingTransform;
    [SerializeField] private LayerMask plantMask;
    
    private Transform currentTransform, closest;

    private void Start()
    {
        currentTransform = startingTransform;
        EventSystem<Transform>.Invoke(EventType.playerMoved, currentTransform);
    }

    private void Update()
    {
        var results = Physics2D.OverlapCircleAll(currentTransform.position, jumpRange, plantMask);

        var mousePos = Input.mousePosition;
        mousePos.z = 0;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        var minDist = Mathf.Infinity;

        foreach (var result in results)
        {
            var tf = result.transform.parent;
            if (tf == currentTransform) continue;
            
            var dist = Vector3.Distance(tf.position, mousePos);

            if (dist < minDist)
            {
                closest = tf;
                minDist = dist;
            }
        }

        if (closest != null)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                currentTransform = closest;
                
                EventSystem<Transform>.Invoke(EventType.playerMoved, currentTransform);
            }
        }
    }

    private void OnPlayerMoved(Transform target)
    {
        
    }

    private void OnDrawGizmos()
    {
        if (closest == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(closest.position,.3f);
    }
}
