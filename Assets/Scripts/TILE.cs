
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
    public GameManager1 gameManagerReference;

    void Start()
    {
        gameManagerReference = FindObjectOfType<GameManager1>();
    }
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
            if (unit.onTurn && unit.tag == "BlueTeam/Triangle"
                && occupiedUnit.tag == "RedTeam/Circle")
            {
                print(unit.name + " se comio a " + occupiedUnit.name);
                gameManagerReference.redFichas -= 1;
                Destroy(occupiedUnit.gameObject);
                SetUnit(UnitManager.Instance.selectedUnit);
                UnitManager.Instance.SetSelectedUnit(null);
            }
            else if (unit.onTurn && unit.tag == "BlueTeam/Triangle"
                && occupiedUnit.tag == "RedTeam/Square" 
                || unit.onTurn && unit.tag == "BlueTeam/Triangle"
                && occupiedUnit.tag == "RedTeam/Triangle")
            {
                print(unit.name + " golpeo " + occupiedUnit.name);
                occupiedUnit.health -= 1;
                unit.health -= 1;
                UnitManager.Instance.SetSelectedUnit(null);
            }
            if (unit.onTurn && unit.tag == "BlueTeam/Circle"
                && occupiedUnit.tag == "RedTeam/Square")
            {
                print(unit.name + " se comio a " + occupiedUnit.name);
                gameManagerReference.redFichas -= 1;
                Destroy(occupiedUnit.gameObject);
                SetUnit(UnitManager.Instance.selectedUnit);
                UnitManager.Instance.SetSelectedUnit(null);
            }
            else if (unit.onTurn && unit.tag == "BlueTeam/Circle"
                && occupiedUnit.tag == "RedTeam/Circle" 
                || unit.onTurn && unit.tag == "BlueTeam/Circle"
                && occupiedUnit.tag == "RedTeam/Triangle")
            {
                print(unit.name + " golpeo " + occupiedUnit.name);
                occupiedUnit.health -= 1;
                unit.health -= 1;
                UnitManager.Instance.SetSelectedUnit(null);
            }
            if (unit.onTurn && unit.tag == "BlueTeam/Square"
                && occupiedUnit.tag == "RedTeam/Triangle")
            {
                print(unit.name + " se comio a " + occupiedUnit.name);
                gameManagerReference.redFichas -= 1;
                Destroy(occupiedUnit.gameObject);
                SetUnit(UnitManager.Instance.selectedUnit);
                UnitManager.Instance.SetSelectedUnit(null);
            }
            else if (unit.onTurn && unit.tag == "BlueTeam/Square"
                && occupiedUnit.tag == "RedTeam/Circle" 
                || unit.onTurn && unit.tag == "BlueTeam/Square"
                && occupiedUnit.tag == "RedTeam/Square")
            {
                print(unit.name + " golpeo " + occupiedUnit.name);
                occupiedUnit.health -= 1;
                unit.health -= 1;
                UnitManager.Instance.SetSelectedUnit(null);
            }

            if (unit.onTurn && unit.tag == "RedTeam/Triangle"
                && occupiedUnit.tag == "BlueTeam/Circle")
            {
                print(unit.name + " se comio a " + occupiedUnit.name);
                gameManagerReference.blueFichas -= 1;
                Destroy(occupiedUnit.gameObject);
                SetUnit(UnitManager.Instance.selectedUnit);
                UnitManager.Instance.SetSelectedUnit(null);
            }
            else if (unit.onTurn && unit.tag == "RedTeam/Triangle"
                && occupiedUnit.tag == "BlueTeam/Square"
                || unit.onTurn && unit.tag == "RedTeam/Triangle"
                && occupiedUnit.tag == "BlueTeam/Triangle")
            {
                print(unit.name + " golpeo " + occupiedUnit.name);
                occupiedUnit.health -= 1;
                unit.health -= 1;
                UnitManager.Instance.SetSelectedUnit(null);
            }
            if (unit.onTurn && unit.tag == "RedTeam/Circle"
                && occupiedUnit.tag == "BlueTeam/Square")
            {
                print(unit.name + " se comio a " + occupiedUnit.name);
                gameManagerReference.blueFichas -= 1;
                Destroy(occupiedUnit.gameObject);
                SetUnit(UnitManager.Instance.selectedUnit);
                UnitManager.Instance.SetSelectedUnit(null);
            }
            else if (unit.onTurn && unit.tag == "RedTeam/Circle"
                && occupiedUnit.tag == "BlueTeam/Circle"
                || unit.onTurn && unit.tag == "RedTeam/Circle"
                && occupiedUnit.tag == "BlueTeam/Triangle")
            {
                print(unit.name + " golpeo " + occupiedUnit.name);
                occupiedUnit.health -= 1;
                unit.health -= 1;
                UnitManager.Instance.SetSelectedUnit(null);
            }
            if (unit.onTurn && unit.tag == "RedTeam/Square"
                && occupiedUnit.tag == "BlueTeam/Triangle")
            {
                print(unit.name + " se comio a " + occupiedUnit.name);
                gameManagerReference.blueFichas -= 1;
                Destroy(occupiedUnit.gameObject);
                SetUnit(UnitManager.Instance.selectedUnit);
                UnitManager.Instance.SetSelectedUnit(null);
            }
            else if (unit.onTurn && unit.tag == "RedTeam/Square"
                && occupiedUnit.tag == "BlueTeam/Circle"
                || unit.onTurn && unit.tag == "RedTeam/Square"
                && occupiedUnit.tag == "BlueTeam/Square")
            {
                print(unit.name + " golpeo " + occupiedUnit.name);
                occupiedUnit.health -= 1;
                unit.health -= 1;
                UnitManager.Instance.SetSelectedUnit(null);
            }

            if (unit.blueTeam && occupiedUnit.blueTeam || unit.redTeam && occupiedUnit.redTeam)
            {
                UnitManager.Instance.SetSelectedUnit(null);
            }

        }
        
    }
}
