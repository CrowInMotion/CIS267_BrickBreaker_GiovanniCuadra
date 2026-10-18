using Unity.VisualScripting;
using UnityEngine;

public class ExtraLife : MonoBehaviour
{
    [SerializeField]
    private int extraLife;

    private PlayerController playerControllerScript;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addLife()
    {
        playerControllerScript.changeLife(extraLife);
    }
}
