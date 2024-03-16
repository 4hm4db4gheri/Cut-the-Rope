using System;
using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField] private Rigidbody2D hookRigidbody;
    [SerializeField] private GameObject linkPrefab;
    [SerializeField] private int linkNumbers = 7;
    [SerializeField] private Weight weight;

    private void Start()
    {
        GenerateRope();
    }

    private void GenerateRope()
    {
        Rigidbody2D previousRB = hookRigidbody;
        for (int i = 0; i < linkNumbers; i++)
        {
            GameObject link = Instantiate(linkPrefab, transform);
            HingeJoint2D joint2D = link.GetComponent<HingeJoint2D>();
            joint2D.connectedBody = previousRB;

            if (i < linkNumbers - 1)
                previousRB = link.GetComponent<Rigidbody2D>();
            else
                weight.GenerateWeight(link.GetComponent<Rigidbody2D>());
        }
    }
}
