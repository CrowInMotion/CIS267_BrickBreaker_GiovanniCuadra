using UnityEngine;

public class LoseLifeEffect : MonoBehaviour
{
    [SerializeField]
    private int damageToPlayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;

            damageToPlayer = damageToPlayer * -1;
            player.GetComponent<PlayerController>().changeLife(damageToPlayer);
        }
    }
}
