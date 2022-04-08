using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteadyMove : MonoBehaviour
{
    Transform game_object_transform;
    // Start is called before the first frame update
    void Start()
    {
        game_object_transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        game_object_transform.position += new Vector3(0.001f,0, 0);
    }
}
