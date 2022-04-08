using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;

public class HitPointTest : MonoBehaviour, IMixedRealityPointerHandler
{
    public void OnPointerClicked(MixedRealityPointerEventData eventData)
    {
        //EventBus.Publish(new ToastRequest("OnPointerClicked!"));
    }

    public void OnPointerDown(MixedRealityPointerEventData eventData)
    {
        //EventBus.Publish(new ToastRequest("OnPointerDown!"));
    }

    public void OnPointerDragged(MixedRealityPointerEventData eventData)
    {
        //EventBus.Publish(new ToastRequest("OnPointerDragged!"));
        //foreach (var source in MixedRealityToolkit.InputSystem.DetectedInputSources)
        //{
        //    // Ignore anything that is not a hand because we want articulated hands
        //    if (source.SourceType == Microsoft.MixedReality.Toolkit.Input.InputSourceType.Hand)
        //    {
        //        foreach (var p in source.Pointers)
        //        {
        //            if (p is IMixedRealityNearPointer)
        //            {
        //                // Ignore near pointers, we only want the rays
        //                continue;
        //            }
        //            if (p.Result != null)
        //            {
        //                var startPoint = p.Position;
        //                var endPoint = p.Result.Details.Point;
        //                var hitObject = p.Result.Details.Object;
        //                if (hitObject)
        //                {
        //                    var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //                    sphere.transform.localScale = Vector3.one * 0.01f;
        //                    sphere.transform.position = endPoint;
        //                }
        //            }

        //        }
        //    }
        //}
    }

    public void OnPointerUp(MixedRealityPointerEventData eventData)
    {
        //EventBus.Publish(new ToastRequest("OnPointerUp!"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}