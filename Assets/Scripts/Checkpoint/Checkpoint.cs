using UnityEngine;

/*
 * Just a simple script to store the checkpoint data.
 */

public class Checkpoint
{
    Vector3 position;

    public Vector3 Position
    {
        get { return position; }
        set { position = value; }
    }

    public Checkpoint(Vector3 position)
    {
        this.position = position;
    }
}
