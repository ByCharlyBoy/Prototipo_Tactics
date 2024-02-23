using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public static UnitManager Instance;

    public GamePiece selectedUnit;

    void Awake()
    {
        Instance = this;
    }
    void OnMouseDown()
    {
        Debug.Log(name + " " + transform.position);
    }
    public void SetSelectedUnit(GamePiece unit)
    {
        selectedUnit = unit;
    }
}
