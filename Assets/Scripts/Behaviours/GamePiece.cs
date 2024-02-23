using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePiece : MonoBehaviour
{
    public int health = 2;
    public int damage = 1;
    public bool blueTeam;
    public bool redTeam;
    public bool onTurn = false;
    public TILE occupiedTile;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        var gamepiece = collision.gameObject.GetComponent<GamePiece>();
        if (onTurn && redTeam && gamepiece.blueTeam || onTurn && blueTeam && gamepiece.redTeam)
        {
            if (onTurn && this.gameObject.tag == "Triangle" && collision.gameObject.tag == "Circle")
            {
                print("entro");
                Destroy(collision.gameObject);
            }
            else if (onTurn && this.gameObject.tag == "Triangle" && collision.gameObject.tag == "Square" || onTurn && this.gameObject.tag == "Triangle" && collision.gameObject.tag == "Triangle")
            {
                print("entro");
                health -= 1;
                gamepiece.health -= damage;
            }

            if (onTurn && this.gameObject.tag == "Circle" && collision.gameObject.tag == "Square")
            {
                print("entro");
                Destroy(collision.gameObject);
            }
            else if (onTurn && this.gameObject.tag == "Circle" && collision.gameObject.tag == "Triangle" || this.gameObject.tag == "Circle" && collision.gameObject.tag == "Circle")
            {
                print("entro");
                health -= 1;
                gamepiece.health -= damage;
            }

            if (this.gameObject.tag == "Square" && collision.gameObject.tag == "Triangle")
            {
                print("entro");
                Destroy(collision.gameObject);
            }
            else if (this.gameObject.tag == "Square" && collision.gameObject.tag == "Circle" || this.gameObject.tag == "Square" && collision.gameObject.tag == "Square")
            {
                print("entro");
                health -= 1;
                gamepiece.health -= damage;
            }
        }

    }

}
