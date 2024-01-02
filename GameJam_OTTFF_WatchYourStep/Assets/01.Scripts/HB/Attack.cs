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
        yield return null;
        rightFootCollider.enabled = false;
        Debug.Log("right foot attacked");
    }

    public IEnumerator LeftColliderEnable()
    {
        leftFootCollider.enabled = true;
        yield return null;
        leftFootCollider.enabled = false;
        Debug.Log("left foot attacked");
    }
}
