using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;

public class Grappling : MonoBehaviour
{

    public LineRenderer left_lr;
    public LineRenderer right_lr;

    public LayerMask whatIsGrappleable;
    public Transform camera, player;
    private float maxDistance = 100f;
    private SpringJoint left_joint;
    private SpringJoint right_joint;

    private IMixedRealityInputSystem inputSystem = null;
    private IMixedRealityController leftController;
    private IMixedRealityController rightController;


    private Vector3 leftGrapplePoint;
    private Vector3 rightGrapplePoint;
    private Vector3 leftCurrentGrapplePosition;
    private Vector3 rightCurrentGrapplePosition;

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
    void Update()
    {
         foreach (IMixedRealityController controller in InputSystem.DetectedControllers)
        {
            if (controller.Visualizer?.GameObjectProxy != null)
            {
                if (controller.Visualizer?.GameObjectProxy.name == "Left_OVRControllerPrefab")
                {
                    leftController = controller;
                }
                else if (controller.Visualizer?.GameObjectProxy.name == "Right_OVRControllerPrefab")
                {
                    rightController = controller;
                }
            }
        }

        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            StartGrapple(leftController, left_lr,true);
        }
        if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            StartGrapple(rightController, right_lr,false);
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            StopGrapple(left_joint, left_lr);
        }
        if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger))
        {
            StopGrapple(right_joint, right_lr);
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
    void StartGrapple(IMixedRealityController controller, LineRenderer lr, bool isLeft)
    {
        RaycastHit hit;


        //Debug.Log("Visualizer Game Object: " + controller.Visualizer.GameObjectProxy);
        Vector3 forward = controller.Visualizer.GameObjectProxy.GetComponent<Transform>().forward;
        Vector3 pos = controller.Visualizer.GameObjectProxy.GetComponent<Transform>().position;
        if (Physics.Raycast(pos, forward, out hit, maxDistance, whatIsGrappleable))
        {
            
            if (isLeft)
            {
                leftGrapplePoint = hit.point;
                if (left_joint != null)
                {
                    Destroy(left_joint);
                }
                left_joint = player.gameObject.AddComponent<SpringJoint>();
                left_joint.autoConfigureConnectedAnchor = false;
                left_joint.connectedAnchor = leftGrapplePoint;

                float distanceFromPoint = Vector3.Distance(player.position, leftGrapplePoint);

                //The distance grapple will try to keep from grapple point. 
                left_joint.maxDistance = distanceFromPoint * 0.8f;
                left_joint.minDistance = distanceFromPoint * 0.25f;

                //Adjust these values to fit your game.
                left_joint.spring = 4.5f;
                left_joint.damper = 7f;
                left_joint.massScale = 4.5f;
            }
            else
            {
                rightGrapplePoint = hit.point;
                if (right_joint != null)
                {
                    Destroy(right_joint);
                }
                right_joint = player.gameObject.AddComponent<SpringJoint>();
                right_joint.autoConfigureConnectedAnchor = false;
                right_joint.connectedAnchor = rightGrapplePoint;

                float distanceFromPoint = Vector3.Distance(player.position, rightGrapplePoint);

                //The distance grapple will try to keep from grapple point. 
                right_joint.maxDistance = distanceFromPoint * 0.8f;
                right_joint.minDistance = distanceFromPoint * 0.25f;

                //Adjust these values to fit your game.
                right_joint.spring = 4.5f;
                right_joint.damper = 7f;
                right_joint.massScale = 4.5f;
            }
            

            lr.positionCount = 2;
            if (isLeft)
            {
                leftCurrentGrapplePosition = pos;
            }
            else
            {
                rightCurrentGrapplePosition = pos;
            }
        }
    }


    /// <summary>
    /// Call whenever we want to stop a grapple
    /// </summary>
    void StopGrapple(SpringJoint joint, LineRenderer lr)
    {
        lr.positionCount = 0;
        Destroy(joint);
    }



    void DrawRope()
    {
        //If not grappling, don't draw rope
        if (left_joint)
        {
            leftCurrentGrapplePosition = Vector3.Lerp(leftCurrentGrapplePosition, leftGrapplePoint, Time.deltaTime * 8f);
            left_lr.SetPosition(0, leftController.Visualizer.GameObjectProxy.GetComponent<Transform>().position);
            left_lr.SetPosition(1, leftCurrentGrapplePosition);
        }
        if (right_joint)
        {
            rightCurrentGrapplePosition = Vector3.Lerp(rightCurrentGrapplePosition, rightGrapplePoint, Time.deltaTime * 8f);
            right_lr.SetPosition(0, rightController.Visualizer.GameObjectProxy.GetComponent<Transform>().position);
            right_lr.SetPosition(1, rightCurrentGrapplePosition);
        }
    }

    public bool IsGrappling()
    {
        return left_joint != null || right_joint != null;
    }

    public Vector3[] GetGrapplePoints()
    {
        return new Vector3[] { leftGrapplePoint, rightGrapplePoint };
    }
}
