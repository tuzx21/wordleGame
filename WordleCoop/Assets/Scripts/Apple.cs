using UnityEngine;

public class Apple : MonoBehaviour
{
    public float speedBoost = 3f;
    public float duration = 5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement2D player = collision.GetComponent<PlayerMovement2D>();
            if (player != null )
            {
                player.StartCoroutine(player.SpeedBoost(speedBoost, duration));
            }
            gameObject.SetActive(false);

        }




    }
}
