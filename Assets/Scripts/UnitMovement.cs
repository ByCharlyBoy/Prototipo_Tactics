using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    TILE tile;
    [SerializeField] GameObject selectedUnit;

    private void Update()
    {
        OnMouseDown();
    }
    private void OnMouseDown()
    {
        if (selectedUnit == null)
        {
            selectedUnit = gameObject;
            Debug.Log("Se seleccionno " + selectedUnit.name);
        }
        else if (selectedUnit != null)
        {
            selectedUnit.transform.position = new Vector3(3, 0, 0);
        }
    }
}
