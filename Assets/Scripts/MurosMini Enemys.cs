using UnityEngine;

public class MurosMiniEnemys : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Subdits"))
        {
            
        }
         else if (collision.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>());
        }
    }
}