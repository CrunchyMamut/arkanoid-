using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class BlockData
{
    //Replace these example variable with your objects variables
    //that you wish to save
    
    public string name;
    public float[] position;

    public BlockData(Block block)
    {
        name = block.name;

        Vector3 blockPos = block.transform.position;

        position = new float[]
        {
            blockPos.x, blockPos.y, blockPos.z
        };
    }
}
