
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TILE : MonoBehaviour
{
    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject highlight;
    [SerializeField] private UnitMovement unitMovement;

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
        if (UnitManager.Instance.selectedUnit != null && occupiedUnit != null)
        {
            print("entre");
            UnitDamage(UnitManager.Instance.selectedUnit);
        }
        else if (occupiedUnit != null)
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

    public void UnitDamage(GamePiece unit)
    {
        if (unit.onTurn && unit.blueTeam
           || unit.onTurn && unit.redTeam)
        {
            if (unit.onTurn && unit.redTeam && unit.tag == "Triangle"
                && unit.redTeam && occupiedUnit.tag == "Circle")
            {
                print(unit.name + " se comio a " + occupiedUnit.name);
                Destroy(occupiedUnit.gameObject);
            }
        }
    }
}
