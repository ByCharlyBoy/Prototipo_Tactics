
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TILE : MonoBehaviour
{
    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject highlight;

    public GamePiece occupiedUnit;

    public void Init(bool isOffset)
    {
        spriteRenderer.color = isOffset ? offsetColor : baseColor;
    }

    void OnMouseEnter()
    {
        highlight.SetActive(true);
    }
    void OnMouseExit()
    {
        highlight.SetActive(false);
    }
    void OnMouseDown()
    {
        if (occupiedUnit != null)
        {
            UnitManager.Instance.SetSelectedUnit((GamePiece)occupiedUnit);
            Debug.Log("Unit Selected: " + occupiedUnit);
        }
        else
        {
            if (UnitManager.Instance.selectedUnit != null)
            {
                SetUnit(UnitManager.Instance.selectedUnit);
                UnitManager.Instance.SetSelectedUnit(null);
            }
        }
        Debug.Log(name);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    occupiedUnit = collision.gameObject.GetComponent<Unit>();
    //    Debug.Log("Collision with " + collision.gameObject.name);
    //}
    public void SetUnit(GamePiece unit)
    {
        if(unit.occupiedTile != null) unit.occupiedTile.occupiedUnit = null;
        unit.transform.position = transform.position;
        occupiedUnit = unit;
        unit.occupiedTile = this;
    }
}
