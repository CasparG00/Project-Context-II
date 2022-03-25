using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Yarn.Unity;

public class OptionsPicker : MonoBehaviour
{
    [SerializeField] private Color selectedColor = Color.white;
    [SerializeField] private Color unselectedColor = Color.grey;

    [SerializeField] private KeyCode moveSelectionUp;
    [SerializeField] private KeyCode moveSelectionDown;

    private readonly List<Transform> options = new List<Transform>();
    private int selectedIndex;
    
    private void Update()
    {
        if (transform.childCount == 0) return;

        for (var i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            if (child.gameObject.activeSelf)
            {
                if (!options.Contains(child))
                {
                    options.Add(child);
                }
            }
            else
            {
                if (options.Contains(child))
                {
                    options.Remove(child);
                }
            }
        }
        
        if (options.Count == 0) return;

        for (var i = 0; i < options.Count; i++)
        {
            options[i].GetComponent<TextMeshProUGUI>().color = i == selectedIndex ? selectedColor : unselectedColor;
        }

        if (Input.GetKeyDown(moveSelectionUp))
        {
            selectedIndex -= 1;
        }

        if (Input.GetKeyDown(moveSelectionDown))
        {
            selectedIndex += 1;
        }

        if (selectedIndex >= options.Count)
        {
            selectedIndex = 0;
        } else if (selectedIndex < 0)
        {
            selectedIndex = options.Count - 1;
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Space))
        {
            options[selectedIndex].GetComponent<OptionView>().InvokeOptionSelected();
            foreach (var t in options)
            {
                t.gameObject.SetActive(false);
            }
        }
    }
}
