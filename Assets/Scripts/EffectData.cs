using UnityEngine;

public class EffectData : MonoBehaviour
{
    private int effectId;

    [SerializeField]
    private float timeToExpire;

    private float timer;

    public bool isEnabled = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnabled)
        {
            checkTimer();
        }
    }

    public void checkTimer()
    {
        timer += Time.deltaTime;

        if (timer >= timeToExpire)
        {
            //reset our timer to 0
            timer = 0f;
            isEnabled = false;
        }

        //return time;
    }
}
