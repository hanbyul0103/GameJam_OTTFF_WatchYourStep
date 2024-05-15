using UnityEngine;

public class CheckEnemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            PoolManager.Instance.Push("Enemy", other.gameObject);
            AudioManager.Instance.PlaySFX("HumanBrokenSound");
            AudioManager.Instance.PlaySFX("ScreamSound");
            UIManager.Instance.GameOverPanel();
            GameManager.Instance.GameOver();
        }
    }
}
