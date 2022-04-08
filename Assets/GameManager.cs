using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    //void Start()
    //{

    //}

    //// Update is called once per frame
    //void Update()
    //{


    //    foreach (var source in MixedRealityToolkit.InputSystem.DetectedInputSources)
    //    {
    //        // Ignore anything that is not a hand because we want articulated hands
    //        if (source.SourceType == Microsoft.MixedReality.Toolkit.Input.InputSourceType.Hand)
    //        {
    //            foreach (var p in source.Pointers)
    //            {
    //                if (p is IMixedRealityNearPointer)
    //                {
    //                    // Ignore near pointers, we only want the rays
    //                    continue;
    //                }
    //                if (p.Result != null)
    //                {

    //                    var startPoint = p.Position;
    //                    var endPoint = p.Result.Details.Point;
    //                    Debug.Log(endPoint.x.ToString() + endPoint.y.ToString() + endPoint.z.ToString());
    //                    var hitObject = p.Result.Details.Object;
    //                    if (hitObject)
    //                    {
    //                        var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    //                        sphere.transform.localScale = Vector3.one * 0.01f;
    //                        sphere.transform.position = endPoint;
    //                    }
    //                }

    //            }
    //        }
    //    }
    //}

    //[SerializeField] Rigidbody camera_rb;

    //private IMixedRealityInputSystem inputSystem = null;

    ///// <summary>
    ///// The active instance of the input system.
    ///// </summary>
    //protected IMixedRealityInputSystem InputSystem
    //{
    //    get
    //    {
    //        if (inputSystem == null)
    //        {
    //            MixedRealityServiceRegistry.TryGetService<IMixedRealityInputSystem>(out inputSystem);
    //        }
    //        return inputSystem;
    //    }
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //    if (Input.GetKeyDown(KeyCode.P))
    //    {
    //        EventBus.Publish<ToastRequest>(new ToastRequest("Test toast"));
    //    }

    //    if (Input.GetKeyDown(KeyCode.O))
    //    {

    //        EventBus.Publish<ToastRequest>(new ToastRequest("Force added"));
    //        camera_rb.AddForce(new Vector3(100, 100, 100));
    //    }

    //    //if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.Get(OVRInput.Button.SecondaryIndexTrigger))
    //    //{
    //    //    Debug.Log("DOne");

    //    //}

    //    // Log something every 60 frames.
    //    if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
    //    {
    //        foreach (IMixedRealityController controller in InputSystem.DetectedControllers)
    //        {
    //            if (controller.Visualizer?.GameObjectProxy != null)
    //            {
    //                //Debug.Log("Visualizer Game Object: " + controller.Visualizer.GameObjectProxy);
    //                Vector3 forward = controller.Visualizer.GameObjectProxy.GetComponent<Transform>().forward;
    //                Vector3 pos = controller.Visualizer.GameObjectProxy.GetComponent<Transform>().position;
    //                RaycastHit hit;
    //                if (Physics.Raycast(pos, forward, out hit))
    //                {
    //                    var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    //                    sphere.transform.localScale = Vector3.one * 0.01f;
    //                    sphere.transform.position = hit.point;
    //                }
    //                Debug.Log("Visualizer Game Object: " + forward.x + forward.y + forward.z);
    //            }
    //            else
    //            {
    //                Debug.Log("Controller has no visualizer!");
    //            }


    //            foreach (IMixedRealityPointer pointer in controller.InputSource.Pointers)
    //            {
    //                if (pointer is MonoBehaviour)
    //                {
    //                    var monoBehavior = pointer as MonoBehaviour;
    //                    Debug.Log("Found pointer game object: " + (monoBehavior.gameObject));
    //                }
    //            }
    //        }
    //    }
    //}
}
