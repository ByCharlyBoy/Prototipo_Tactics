using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager1 : MonoBehaviour
{
    public enum TurnState { RedTurn, BlueTurn, None }

    public TurnState currentState;
    public float turnTimeLimit = 6.0f;

    public int redFichas;
    public int blueFichas;
    [HideInInspector]public List<GamePiece> bluePieces;
    [HideInInspector]public List<GamePiece> redPieces;


    //private string redTeam;
    //private string blueTeam;

private float _turnTimer;

    GridManager gridReferece;

    void Start()
    {
        // Inicia con un turno especúƒico si es necesario
        //currentState = TurnState.RedTurn;
        _turnTimer = turnTimeLimit;

        currentState = TurnState.None;

        //bluePieces = gridReferece.blueTeam; //meterme a esta lista que es la copia y hacer un for de la lista
        //                                                    //y me meto en cada pieza y activo el onturn a true 
        //redPieces = gridReferece.redTeam;



    }

    void Update()
    {
        if (currentState == TurnState.None)
        {
            _turnTimer -= Time.deltaTime;

            if (_turnTimer <= 0.0f)
            {
                // Tiempo de espera agotado, pasar al siguiente jugador
                EndTurn();
            }

        }
        if (currentState != TurnState.None)
        {
            _turnTimer -= Time.deltaTime;

            if (_turnTimer <= 0.0f)
            {
                // Tiempo de espera agotado, pasar al siguiente jugador
                EndTurn();
            }

        }

        if (redFichas <= 0)
        {
            Debug.Log("Blue Team Win");
            EndGame();
        }
        else if (blueFichas <= 0)
        {
            Debug.Log("Red Team Win");
            EndGame();
        }

    }
    public void SetBlueList(List<GamePiece> gamePiecesCopy)
    {
        bluePieces = gamePiecesCopy;
    }
    public void SetRedList(List<GamePiece> gamePiecesCopy)
    {
        redPieces = gamePiecesCopy;
    }
    public void EndTurn()
    {
        //Desactiva el current player
        if (currentState == TurnState.RedTurn)
        {
            if (redPieces[0].onTurn == true)
            {
                for (int y = 0; y < redPieces.Count; y++)
                {
                    bluePieces[y].onTurn = true;
                    redPieces[y].onTurn = false;
                }
                currentState = TurnState.BlueTurn;
            }
        }
        else
        {
            if (bluePieces[0].onTurn == true)
            {
                for (int y = 0; y < redPieces.Count; y++)
                {
                    redPieces[y].onTurn = true;
                    bluePieces[y].onTurn = false;
                }
                currentState = TurnState.RedTurn;
            }
        }

        _turnTimer = turnTimeLimit;


    }

    public void EndGame()
    {
        // lógica de fin de juego
        // Mostrar un mensaje de Game Over
        GameObject gameOverText = GameObject.Find("GameOverText");
        if (gameOverText != null)
        {
            gameOverText.GetComponent<Text>().enabled = true;
        }

        // Desactivar la lógica de juego
        currentState = TurnState.None;
        _turnTimer = 0.0f;

        // Mostrar el panel de Game Over
        GameObject gameOverPanel = GameObject.Find("GameOverPanel");
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        Debug.Log("Game Over!");
    }
}