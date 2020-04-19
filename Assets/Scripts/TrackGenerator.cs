using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGenerator : MonoBehaviour
{
    public GameObject[] blocks;
    public Transform startPos;
    
    Block currentBlock;
    public int buffer = 20;

    void Awake() {
        GameObject startBlock = Instantiate(blocks[0], startPos.position, startPos.rotation, transform);
        currentBlock = startBlock.GetComponent<Block>();
        GeneratePath();
    }

    void GeneratePath() {
        System.Random random = new System.Random();
        string generatedPath = "";

        for (int i = 0; i < buffer; i++) {  //create string of random integers
            generatedPath += random.Next(1, blocks.Length).ToString();
        }
        
        //Convert generated string of integers
        char[] path = generatedPath.ToCharArray();  
        for (int i = 0; i < path.Length; i++) {
            int nextBlock = (int)Char.GetNumericValue(path[i]);

            GameObject newBlock = Instantiate(blocks[nextBlock],
                currentBlock.end.position, //place at end of current block
                currentBlock.end.rotation, //match rotation at end
                transform);                 //parent block to path object

            //newBlock.transform.Rotate(90, 0, 0);
            currentBlock = newBlock.GetComponent<Block>();
        }

    }

    void Start() {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
