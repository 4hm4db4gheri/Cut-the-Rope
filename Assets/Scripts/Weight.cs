using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weight : MonoBehaviour
{
    [SerializeField] private float distanceFromChainEnd = 0.3f;
    public void GenerateWeight(Rigidbody2D endRigidbody)
    {
        HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedBody = endRigidbody;
        joint.anchor = Vector2.zero;
        joint.connectedAnchor = new Vector2(0, -distanceFromChainEnd);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bascket"))
        {
            GameManager.instance.Win();
        }
    }


}
