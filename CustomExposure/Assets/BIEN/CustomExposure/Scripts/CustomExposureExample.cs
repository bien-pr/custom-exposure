using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomExposureExample : MonoBehaviour
{
    [HideInInspector]
    public WebCamTexture mCamera = null;
    [HideInInspector]
    public GameObject plane;

    public Text m_Text;
    public InputField m_Duration;
    public InputField m_Scale;
    public InputField m_ISO;


    // Start is called before the first frame update
    void Start()
    {
        plane = GameObject.FindWithTag("Player");

        mCamera = new WebCamTexture();

        plane.GetComponent<Renderer>().material.mainTexture = mCamera;

        mCamera.Play();
    }

    public void SetAuto()
    {
        CustomExposure.AVCaptureExposureModeAutoExpose();
        m_Text.text = string.Format("Example - {0}", "Set AUTO");
    }

    public void SetLock()
    {
        CustomExposure.AVCaptureExposureModeLocked();
        m_Text.text = string.Format("Example - {0}", "Set LOCK");
    }

    public void SetCustom()
    {
        float duration = float.Parse(m_Duration.text);
        float scale = float.Parse(m_Scale.text);
        float iso = float.Parse(m_ISO.text);

        CustomExposure.AVCaptureExposureModeCustom(duration, scale, iso);

        m_Text.text = string.Format("Example - {0} d: {1}, s: {2}, i: {3} ", "Set CUSTOM", duration, scale, iso);
    }
}
