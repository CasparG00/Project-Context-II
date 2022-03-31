using UnityEngine;
using Yarn.Unity;

public class MoveNPC
{
    [YarnCommand("Move")]
    public static void Move(GameObject character, GameObject destination, float speed)
    {
        var tf = character.transform;
        var target = destination.transform.position;

        if (Vector2.Distance(tf.position, target) > 0.05f)
        {
            tf.position = Vector2.MoveTowards(tf.position, target, speed);
        }
        else
        {
            tf.position = target;
        }
    }
}
