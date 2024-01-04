using UnityEngine;

public class Particle : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 3);
    }
}
