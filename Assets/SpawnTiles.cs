using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpawnTiles : MonoBehaviour
{
    [SerializeField] private Tilemap tilemapGround;
    [SerializeField] private Tilemap tilemapObject;

    [SerializeField] private Grid grid;

    [SerializeField] private float tilemapWidth;
    [SerializeField] private float tilemapHeight;

    private GameObject player;
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    // Update is called once per frame
    void Update()
    {
        Tilemap[] tilemaps =  FindObjectsOfType<Tilemap>(); //Gets all the tilemaps.
        if (tilemaps.Length >= 8)
            return;
        foreach (var tilemap in tilemaps)
        {
            if(Mathf.Abs(tilemap.transform.position.x - player.transform.position.x) > tilemapWidth )
            {
                Vector3 offset = new Vector3();
                
                if (tilemap.transform.position.x - player.transform.position.x < -tilemapWidth)
                {
                    offset.x = tilemapGround.size.x;
                }
                else if (tilemap.transform.position.x - player.transform.position.x > tilemapWidth)
                {
                    offset.x = -tilemapGround.size.x;
                }
                
                var position = tilemap.transform.position + offset;
                if(CheckOffsetTilemapExists(position))
                    continue;
                
                Tilemap tmGround =  Instantiate(tilemapGround,position, Quaternion.identity);
                Tilemap tmObject = Instantiate(tilemapObject, position, Quaternion.identity);

                var transform1 = grid.transform;
                tmGround.transform.parent = transform1;
                tmObject.transform.parent = transform1;
                break;
            }

            if (Mathf.Abs(tilemap.transform.position.y - player.transform.position.y) > tilemapHeight)
            {
                Vector3 offset = new Vector3();
                if (tilemap.transform.position.y - player.transform.position.y < -tilemapHeight)
                {
                    offset.y = tilemapGround.size.y;
                }
                else if (tilemap.transform.position.y - player.transform.position.y > tilemapHeight)
                {
                    offset.y = -tilemapGround.size.y;
                }

                var position = tilemap.transform.position + offset;
                if(CheckOffsetTilemapExists(position))
                    continue;

                Tilemap tmGround =  Instantiate(tilemapGround,position, Quaternion.identity);
                Tilemap tmObject = Instantiate(tilemapObject, position, Quaternion.identity);

                var transform1 = grid.transform;
                tmGround.transform.parent = transform1;
                tmObject.transform.parent = transform1;
                break;
            }
        }
        
    }

    private bool CheckOffsetTilemapExists(Vector3 position)
    {
        Tilemap[] tilemaps = FindObjectsOfType<Tilemap>();
        foreach (var tilemap in tilemaps)
        {
            if (tilemap.transform.position == position)
            {
                Debug.Log("exists");
                return true;
            }
        }

        return false;
    }
}
