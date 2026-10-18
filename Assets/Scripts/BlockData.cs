using UnityEngine;

public class BlockData : MonoBehaviour
{
    [SerializeField]
    private int blockValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int getBlockValue()
    {
        return blockValue;
    }
}
