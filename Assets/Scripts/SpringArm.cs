using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringArm : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Anchor")]
    [SerializeField] private Transform anchor;
    [SerializeField] private bool isLocked;
    [Header("Spring")]
    [SerializeField] private float minLength;
    [SerializeField] private float maxLength;
    [SerializeField] private float springSpeed;

    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
