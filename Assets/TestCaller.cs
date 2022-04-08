using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCaller : MonoBehaviour
{
    public void testWithToast()
    {
        EventBus.Publish(new ToastRequest("Test succeed!"));
    }
}
