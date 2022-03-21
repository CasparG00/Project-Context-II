using TMPro;
using UnityEngine;
using Yarn.Unity;

public class OptionsPicker : MonoBehaviour
{
    [SerializeField] private Color selectedColor = Color.white;
    [SerializeField] private Color unselectedColor = Color.grey;

    [SerializeField] private KeyCode moveSelectionUp;
    [SerializeField] private KeyCode moveSelectionDown;

    private int selectedIndex;
    
    private void Update()
    {
        if (transform.childCount == 0) return;

        for (var i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            child.GetComponent<TextMeshProUGUI>().color = i == selectedIndex ? selectedColor : unselectedColor;
        }

        if (Input.GetKeyUp(moveSelectionUp))
        {
            selectedIndex -= 1;
        }

        if (Input.GetKeyDown(moveSelectionDown))
        {
            selectedIndex += 1;
        }

        if (selectedIndex >= transform.childCount)
        {
            selectedIndex = 0;
        } else if (selectedIndex < 0)
        {
            selectedIndex = transform.childCount - 1;
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))
        {
            transform.GetChild(selectedIndex).GetComponent<OptionView>().InvokeOptionSelected();
            for (var i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
