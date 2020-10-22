using UnityEngine;

/*
 * Just a simple script to store the checkpoint data.
 */

public class Checkpoint
{
    Vector3 position;

    public Checkpoint(Vector3 position)
    {
        this.position = position;
    }

    public void UpdateCheckpoint(Vector3 position)
    {
        this.position = position;
    }

    public Vector3 GetCheckpoint()
    {
        return this.position;
    }
}
