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
            if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2))
            {
                currentTransform = closest;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (currentTransform == null) return;
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(currentTransform.position, .3f);

        if (closest == null) return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(closest.position,.3f);
    }
}
