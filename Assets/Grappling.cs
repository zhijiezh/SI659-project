using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;

public class Grappling : MonoBehaviour
{

    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, camera, player;
    private float maxDistance = 100f;
    private SpringJoint joint;

    private IMixedRealityInputSystem inputSystem = null;

    protected IMixedRealityInputSystem InputSystem
    {
        get
        {
            if (inputSystem == null)
            {
                MixedRealityServiceRegistry.TryGetService<IMixedRealityInputSystem>(out inputSystem);
            }
            return inputSystem;
        }
    }

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            StartGrapple();
        }
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) || OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
        {
            StopGrapple();
        }
    }

    //Called after Update
    void LateUpdate()
    {
        DrawRope();
    }

    /// <summary>
    /// Call whenever we want to start a grapple
    /// </summary>
    void StartGrapple()
    {
        RaycastHit hit;

        foreach (IMixedRealityController controller in InputSystem.DetectedControllers)
        {
            if (controller.Visualizer?.GameObjectProxy != null)
            {
                //Debug.Log("Visualizer Game Object: " + controller.Visualizer.GameObjectProxy);
                Vector3 forward = controller.Visualizer.GameObjectProxy.GetComponent<Transform>().forward;
                Vector3 pos = controller.Visualizer.GameObjectProxy.GetComponent<Transform>().position;
                if (Physics.Raycast(pos, forward, out hit , maxDistance, whatIsGrappleable))
                {
                    grapplePoint = hit.point;
                    joint = player.gameObject.AddComponent<SpringJoint>();
                    joint.autoConfigureConnectedAnchor = false;
                    joint.connectedAnchor = grapplePoint;

                    float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

                    //The distance grapple will try to keep from grapple point. 
                    joint.maxDistance = distanceFromPoint * 0.8f;
                    joint.minDistance = distanceFromPoint * 0.25f;

                    //Adjust these values to fit your game.
                    joint.spring = 4.5f;
                    joint.damper = 7f;
                    joint.massScale = 4.5f;

                    lr.positionCount = 2;
                    currentGrapplePosition = gunTip.position;
                }
                Debug.Log("Visualizer Game Object: " + forward.x + forward.y + forward.z);
            }
            else
            {
                Debug.Log("Controller has no visualizer!");
            }


        }
    }


    /// <summary>
    /// Call whenever we want to stop a grapple
    /// </summary>
    void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }

    private Vector3 currentGrapplePosition;

    void DrawRope()
    {
        //If not grappling, don't draw rope
        if (!joint) return;

        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, grapplePoint, Time.deltaTime * 8f);

        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, currentGrapplePosition);
    }

    public bool IsGrappling()
    {
        return joint != null;
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }
}
