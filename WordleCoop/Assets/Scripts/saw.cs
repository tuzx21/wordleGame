using UnityEngine;

public class saw : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            Debug.Log("Player died!");
        }   
    }
}
