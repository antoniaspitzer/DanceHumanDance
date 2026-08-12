using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using System.Collections;

public class MotionSicknessEffect : MonoBehaviour
{
    [Header("Post Processing")]
    public Volume volume;
    private DepthOfField dof;

    [Header("Camera Wobble")]
    public Transform cameraTransform; // z. B. PlayerCameraRoot
    public float wobbleAmount = 10f;
    public float wobbleSpeed = 5f;

    [Header("Effect Timing")]
    public float duration = 5f;

    private Vector3 originalEulerAngles;
    private bool isActive = false;

    void Start()
    {
        if (volume != null)
        {
            volume.profile.TryGet(out dof);
            if (dof != null) dof.active = false;
        }

        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }

        originalEulerAngles = cameraTransform.localEulerAngles;
    }

    public void TriggerEffect()
    {
        if (!isActive)
        {
            StartCoroutine(ApplyMotionSickness());
        }
    }

    private IEnumerator ApplyMotionSickness()
    {
        isActive = true;

        if (dof != null)
            dof.active = true;

        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;

            float wobble = Mathf.Sin(Time.time * wobbleSpeed) * wobbleAmount;

            cameraTransform.Rotate(0, 0, Mathf.Sin(Time.time * wobbleSpeed) * wobbleAmount * Time.deltaTime);

            Debug.Log("Wobble Z: " + cameraTransform.localEulerAngles.z);

            yield return null;
        }

        // Reset
        if (dof != null)
            dof.active = false;

        cameraTransform.localEulerAngles = originalEulerAngles;
        isActive = false;
    }
}
