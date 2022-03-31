using UnityEngine;

public class QuitHandler : MonoBehaviour
{
    private void Update()
    {
        if (!Input.GetKeyUp(KeyCode.Escape)) return;
        Application.Quit();
    }
}
