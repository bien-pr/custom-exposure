using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class CustomExposure : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void _AVCaptureExposureModeLocked();

    [DllImport("__Internal")]
    private static extern void _AVCaptureExposureModeAutoExpose();

    [DllImport("__Internal")]
    private static extern void _AVCaptureExposureModeContinuousAutoExposure();

    [DllImport("__Internal")]
    private static extern void _AVCaptureExposureModeCustom(float duration, float scale, float newISO);

    public static void AVCaptureExposureModeLocked()
    {
        // Call plugin only when running on real device
        if (Application.platform != RuntimePlatform.OSXEditor)
            _AVCaptureExposureModeLocked();
    }

    public static void AVCaptureExposureModeAutoExpose()
    {
        // Call plugin only when running on real device
        if (Application.platform != RuntimePlatform.OSXEditor)
            _AVCaptureExposureModeAutoExpose();
    }

    public static void AVCaptureExposureModeContinuousAutoExposure()
    {
        // Call plugin only when running on real device
        if (Application.platform != RuntimePlatform.OSXEditor)
            _AVCaptureExposureModeContinuousAutoExposure();
    }

    public static void AVCaptureExposureModeCustom(float duration, float scale, float newISO)
    {
        Debug.Log("duration: " + duration + ", scale: " + scale +", newISO: " + newISO);

        // Call plugin only when running on real device
        if (Application.platform != RuntimePlatform.OSXEditor)
            _AVCaptureExposureModeCustom(duration, scale, newISO);
    }
}
