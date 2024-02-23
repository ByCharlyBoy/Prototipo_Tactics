using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class GridManager : MonoBehaviour
{
    [SerializeField] private int width, height;
    [SerializeField] private TILE tilePrefab;
    [SerializeField] private Transform cam;
    public GamePiece[] prefabRed;
    public GamePiece[] prefabBlue;
    [SerializeField] private List<TILE> tileList;
    [SerializeField] public List<GamePiece> redTeam;
    [SerializeField] public List<GamePiece> blueTeam;
    public GameManager1 gameManagerReference;

    void Start()
    {
        tileList = new List<TILE>();    
        blueTeam = new List<GamePiece>();
        redTeam = new List<GamePiece>();
        GenerateGrid();
       
    }
    void GenerateGrid()
    {
        for(int x = 0; x < width; x++)
        {
            var spawnedRedPiece = Instantiate(prefabRed[x], new Vector3(x, 0, 0), Quaternion.identity);
            var spawnedBluePiece = Instantiate(prefabBlue[x], new Vector3(x, height - 1, 0), Quaternion.identity);
            redTeam.Add(spawnedRedPiece);
            blueTeam.Add(spawnedBluePiece);
            for (int y = 0; y < height; y++)
            {
                var spawnedTile = Instantiate(tilePrefab, new Vector3(x, y), Quaternion.identity);
                spawnedTile.name = $"Tile {x} {y}";
                var isOffset = (x % 2 == 0 && y % 2 != 0) || (x % 2 != 0 && y % 2 == 0);
                spawnedTile.Init(isOffset);
                tileList.Add(spawnedTile);
                
                
            }
        }
        //tileList[5].occupiedUnit = blueTeam[0];
        for (int i = 0; i < redTeam.Count; i++)
        {
            tileList[i * 6].occupiedUnit = redTeam[i];
            tileList[((i + 1) * 6) - 1].occupiedUnit = blueTeam[i];
            
        }

        gameManagerReference.SetBlueList(blueTeam);
        gameManagerReference.SetRedList(redTeam);

        cam.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10);
    }
}
