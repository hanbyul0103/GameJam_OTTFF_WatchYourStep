using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    private BoxCollider rightFootCollider;
    [SerializeField]
    private BoxCollider leftFootCollider;

    public IEnumerator RightColliderEnable()
    {
        rightFootCollider.enabled = true;
        yield return new WaitForSeconds(0.1f);
        rightFootCollider.enabled = false;
        Debug.Log("right foot attacked");
    }

    public IEnumerator LeftColliderEnable()
    {
        leftFootCollider.enabled = true;
        yield return new WaitForSeconds(0.1f);
        leftFootCollider.enabled = false;
        Debug.Log("left foot attacked");
    }
}
