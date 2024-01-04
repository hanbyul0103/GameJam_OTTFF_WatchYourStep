using UnityEngine;

public class CheckEnemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            PoolManager.Instance.Push("Enemy", other.gameObject);
            GameManager.Instance.GameOver();
            AudioManager.Instance.PlaySFX("HumanBrokenSound");
            AudioManager.Instance.PlaySFX("ScreamSound");
        }
    }
}
