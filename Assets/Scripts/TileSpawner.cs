using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public GameObject TilePrefab;
    public GameObject Player;
    public Vector3 SpawnPoint;
    public Quaternion Rotation;
    public int StartingLength;
    //public GameObject[] clones = new GameObject[15];
    GameObject clone;
    
    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < StartingLength; i++)
        {
            clone = Instantiate(TilePrefab, SpawnPoint, Rotation);
            //clones[i] = clone;
            SpawnPoint.z += 10;
        }   
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Spawn()
    {        
        clone = Instantiate(TilePrefab, SpawnPoint, Rotation);
        SpawnPoint.z += 10;
    }
}//GameObject clone, GameObject TilePrefab,Quaternion Rotation, Vector3 SpawnPoint
