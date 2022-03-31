using UnityEngine;
using Yarn.Unity;

public class SetGameObjectState
{
    [YarnCommand("SetActive")]
    public static void SetActive(GameObject gameObject, bool active)
    {
        for (var i = 0; i < gameObject.transform.childCount; i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive(active);
        }
    }
}