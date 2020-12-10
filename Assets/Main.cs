using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject objPrefab;
    GameObject currentObj = null;
    MeshRenderer currnetComp = null;
    public enum States
    {
        Object,
        Component
    }

    public States state = States.Object;

    void Update()
    {
        if (state == States.Object)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                state = States.Component;
            }
            WorkWithObject();
        }
        else if (state == States.Component)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                state = States.Object;
            }
            WorkWithComponent();
        }
    }

    void WorkWithObject()
    {
        if (currentObj != null && Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(currentObj);
            currentObj = null;
        }
        else if (currentObj == null && Input.GetKeyDown(KeyCode.I))
        {
            currentObj = Instantiate(objPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            currnetComp = currentObj.GetComponent<MeshRenderer>();
        }
        else if (currentObj != null && currentObj.activeSelf && Input.GetKeyDown(KeyCode.D))
        {
            currentObj.SetActive(false);
        }
        else if (currentObj != null && !currentObj.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            currentObj.SetActive(true);
        }
    }
    void WorkWithComponent()
    {
        if (currentObj == null)
        {
            return;
        }

        if (currnetComp != null && Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(currnetComp);
            currnetComp = null;
        }
        else if (currnetComp == null && Input.GetKeyDown(KeyCode.I))
        {
            currnetComp = currentObj.AddComponent<MeshRenderer>();
        }
        else if (currnetComp != null && currnetComp.enabled && Input.GetKeyDown(KeyCode.D))
        {
            currnetComp.enabled = false;
        }
        else if (currnetComp != null && !currnetComp.enabled && Input.GetKeyDown(KeyCode.E))
        {
            currnetComp.enabled = true;
        }
    }
}
