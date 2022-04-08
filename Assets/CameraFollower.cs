using System.Collections;
using System.Collections.Generic;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] Transform follow_object;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

         MixedRealityPlayspace.Transform.Translate(-MixedRealityPlayspace.Transform.position + follow_object.position);

    }
}
