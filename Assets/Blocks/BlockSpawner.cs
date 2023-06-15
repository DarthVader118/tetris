using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject[] blocks;
    void Start()
    {
        Instantiate(blocks[0], transform.position, Quaternion.identity);
    }
}
