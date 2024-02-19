using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
  public LayerMask terrainMask;
    Vector3 noTerrainPosition;
    PlayerMovement pm;
    public GameObject current;
    void Start()
    {
      pm = FindObjectOfType<PlayerMovement>();  
    }

    // Update is called once per frame
    void Update()
    {
        ChunkChecker(); 
    }
    void ChunkChecker()
    {
        if (!current)
        {
            return;
        }
        if(pm.moveDir.x> 0 && pm.moveDir.y == 0) ///right
        {
            if(!Physics2D.OverlapCircle(current.transform.Find("Right").position , checkerRadius, terrainMask))
            {
                noTerrainPosition = current.transform.Find("Right").position;
                SpawnChunk();

            }
        }

     else   if (pm.moveDir.x < 0 && pm.moveDir.y == 0)  ///left
        {
            if (!Physics2D.OverlapCircle(current.transform.Find("Left").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = current.transform.Find("Left").position;
                SpawnChunk();

            }

        } 
     else   if (pm.moveDir.y > 0 && pm.moveDir.x == 0)  ///up
        {
            if (!Physics2D.OverlapCircle(current.transform.Find("Up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = current.transform.Find("Up").position;
                SpawnChunk();

            }

        }
       else if (pm.moveDir.y < 0 && pm.moveDir.x == 0)  ///down
        {
            if (!Physics2D.OverlapCircle(current.transform.Find("Down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = current.transform.Find("Down").position;
                SpawnChunk();
            }

        }

        else if (pm.moveDir.x > 0 && pm.moveDir.y > 0)  ///right up
        {
            if (!Physics2D.OverlapCircle(current.transform.Find("Right up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = current.transform.Find("Right up").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x < 0 && pm.moveDir.y > 0)  ///left up
        {
            if (!Physics2D.OverlapCircle(current.transform.Find("Left up").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = current.transform.Find("Left up").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x > 0 && pm.moveDir.y < 0)  ///right down
        {
            if (!Physics2D.OverlapCircle(   current.transform.Find("Right down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = current.transform.Find("Right down").position;
                SpawnChunk();
            }
        }
        else if (pm.moveDir.x < 0 && pm.moveDir.y < 0)  ///left down
        {
            if (!Physics2D.OverlapCircle(current.transform.Find("Left down").position, checkerRadius, terrainMask))
            {
                noTerrainPosition = current.transform.Find("Left down").position;
                SpawnChunk();
            }
        }
       

    }
    void SpawnChunk()
    {
        int randomIndex = Random.Range(0, terrainChunks.Count);
        GameObject terrain = Instantiate(terrainChunks[randomIndex], noTerrainPosition, Quaternion.identity);
    }
}
