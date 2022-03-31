using UnityEngine;
using Yarn.Unity;

public class MoveNPC
{
    [YarnCommand("Move")]
    public static void Move(GameObject character, GameObject destination)
    {
        character.transform.position = destination.transform.position;
    }
}
