using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RootMotion.FinalIK;

public class Calibration : MonoBehaviour
{
    [Tooltip("The VRIK component.")] public VRIK ik;

    [Header("Head")]
    [Tooltip("HMD.")] public Transform centerEyeAnchor;
    [Tooltip("Position offset of the camera from the head bone (root space).")] public Vector3 headAnchorPositionOffset;
    [Tooltip("Rotation offset of the camera from the head bone (root space).")] public Vector3 headAnchorRotationOffset;

    [Header("Hands")]
    [Tooltip("Left Hand Controller")] public Transform leftHandAnchor;
    [Tooltip("Right Hand Controller")] public Transform rightHandAnchor;
    [Tooltip("Position offset of the hand controller from the hand bone (controller space).")] public Vector3 handAnchorPositionOffset;
    [Tooltip("Rotation offset of the hand controller from the hand bone (controller space).")] public Vector3 handAnchorRotationOffset;

    [Header("Scale")]
    [Tooltip("Multiplies the scale of the root.")] public float scaleMlp = 1f;

    [Header("Data stored by Calibration")]
    public VRIKCalibrator.CalibrationData data = new VRIKCalibrator.CalibrationData();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void calibreateAvatar() => data = VRIKCalibrator.Calibrate(ik, centerEyeAnchor, leftHandAnchor, rightHandAnchor, headAnchorPositionOffset, headAnchorRotationOffset, handAnchorPositionOffset, handAnchorRotationOffset, scaleMlp);

    public void calibrateScale()
    {
        if (data.scale == 0f)
        {
            Debug.LogError("Avatar needs to be calibrated before RecalibrateScale is called.");
        }
        VRIKCalibrator.RecalibrateScale(ik, data, scaleMlp);
    }
}