using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chainsaw : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Transform RightHand;
    void OnEnable()
    {
        //Debug.Log("Enable");
        transform.SetParent(RightHand);
    }
}
