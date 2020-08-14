
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    public static Transform[] checkpoints;

    private void Awake()
    {
        checkpoints = new Transform[transform.childCount];
        
        for (int i = 0; i < checkpoints.Length; i++)
        {
            checkpoints[i] = transform.GetChild(i);
        }
    }
}
