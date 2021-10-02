using UnityEngine;

public class WeakPointEnemyScript : MonoBehaviour
{
    [SerializeField] private GameObject objectToDestroy;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(transform.parent.gameObject);
            SoundManagerScript.PlaySound("snakeDeath");
        }
    }
}
