using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class UIElementGroup : MonoBehaviour
{
    private List<GameObject> elements;
    public GameObject canvas;

    void Start()
    {
        elements = new List<GameObject>();
        foreach (Transform child in transform)
        {
            elements.Add(child.gameObject);
        }
    }

    public void ShowUIGroupByName(string name)
    {
        var group = FindUIGroupWithinParentByName(canvas.transform, name);
        if (group != null)
        {
            group.SetActive(true);
        }
    }

    public void HideAllUIGroups()
    {
        foreach (Transform child in canvas.transform)
        {
            if (child.gameObject.GetComponent<UIElementGroup>() != null)
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    public void ShowOnlyUIGroupByName(string name)
    {
        HideAllUIGroups();
        ShowUIGroupByName(name);
    }

    public void HideUIGroupByName(string name)
    {
        var group = FindUIGroupWithinParentByName(canvas.transform, name);
        if (group != null)
        {
            group.SetActive(false);
        }
    }

    public void SwitchUIGroupByName(string name)
    {
        var group = FindUIGroupWithinParentByName(canvas.transform, name);
        if (group != null)
        {
            group.SetActive(!group.activeSelf);
        }
    }
    private GameObject FindUIGroupWithinParentByName(Transform t, string name)
    {
        foreach (Transform child in t)
        {
            if (FindUIGroupWithinParentByName(child, name) != null)
            {
                return FindUIGroupWithinParentByName(child, name);
            }

            if (child.GetComponent<UIElementGroup>() && child.gameObject.name == name)
            {
                return child.gameObject;
            }

        }

        return null;
    }




}
