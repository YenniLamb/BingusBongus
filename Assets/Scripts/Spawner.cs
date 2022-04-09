//using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;

using System.Text;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //public GameObject prefab;

    public List<GameObject> objectsToSpawn;//= new List<GameObject>();

    public bool isRandomized;

    public float spawnRate = 1.5f;  // how often we want to spawn the object
    public float netsMinHeight = -1.84f;
    public float netsMaxHeight = 0.83f;
    public float pipeMinHeight = -3.5f;
    public float pipeMaxHeight = 0.5f;


    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        int index = isRandomized ? Random.Range(0, objectsToSpawn.Count) : 0;

        if (objectsToSpawn.Count > 0)
        {
            GameObject pipes = Instantiate(objectsToSpawn[index], transform.position, Quaternion.identity);
            //Debug.Log("pipes: " + pipes.name); //print Nets(clone)

            //Debug.Log("object index:   " + objectsToSpawn[index].name); //print nets
            //Debug.Log("    Is pobject equal to string: " + objectsToSpawn[index].name.Equals("Nets"));

            if (objectsToSpawn[index].name.Equals("Nets"))
            {
                pipes.transform.position += Vector3.up * Random.Range(netsMinHeight, netsMaxHeight);
                //Debug.Log("true");
            }
            else if (objectsToSpawn[index].name.Equals("Pipes2 Variant"))
            {
                pipes.transform.position += Vector3.up * Random.Range(pipeMinHeight, pipeMaxHeight);
               // Debug.Log("false");
            }
        }
        //GameObject nets = Instantiate(prefab, transform.position, Quaternion.identity);
        //nets.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }

}