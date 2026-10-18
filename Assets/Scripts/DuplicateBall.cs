using UnityEngine;

public class DuplicateBall : MonoBehaviour
{
    public GameObject ballDuplicate;

    private GameObject ballOriginal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ballOriginal = GameObject.FindGameObjectWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void duplicateBall()
    {
        Debug.Log("Duplicate Ball");
        ballDuplicate = Instantiate(ballDuplicate);
        
        ballDuplicate.transform.position = new Vector2(ballOriginal.transform.position.x, ballOriginal.transform.position.y + 1);

        ballDuplicate.GetComponent<Rigidbody2D>().linearVelocity = ballOriginal.GetComponent<Rigidbody2D>().linearVelocity;
        ballDuplicate.GetComponent<SpriteRenderer>().color = Color.blue;
    }

}
