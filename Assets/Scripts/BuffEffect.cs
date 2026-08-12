using System;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;

public class BuffEffect : MonoBehaviour
{
    public Action currentBuffAction;
    public string currentBuffName;

    private List<(Action action, string name)> buffMethods;
    private AudioManager audioManager;

    private void Awake()
    {
        buffMethods = new List<(Action, string)>
        {
            (SpeedBoost, "Speed Boost!"),
            (JumpDisabled, "Jump Disabled!"),
            (InvertControls, "Invert Controls!"),
            (SlowMotion, "Slow Motion!"),
            (EnlargePlayer, "Enlarged Player!"),
            (MotionSickness, "Motion Sickness!")
        };

        audioManager = FindObjectOfType<AudioManager>();
        if (audioManager == null)
        {
            Debug.LogWarning("AudioManager not found in scene.");
        }
    }

    private void CancelPreviousBuff()
    {
        if (BuffUIManager.Instance != null)
            BuffUIManager.Instance.DeactivateAll();
        else
            Debug.LogWarning("BuffUIManager.Instance is null in CancelPreviousBuff");

        var player = FindAnyObjectByType<ThirdPersonController>();
        if (player != null)
            player.ResetAllBuffs();
        else
            Debug.LogWarning("Player not found in CancelPreviousBuff");
    }

    public void SelectRandomBuff()
    {
        CancelPreviousBuff();

        int index = UnityEngine.Random.Range(0, buffMethods.Count);
        currentBuffAction = buffMethods[index].action;
        currentBuffName = buffMethods[index].name;
        currentBuffAction?.Invoke();
    }

    // ------------------------ BUFF METHODS ------------------------

    private void SpeedBoost()
    {
        Debug.Log("Buff Activated: Speed Boost");
        ShowBuffCanvas(BuffUIManager.Instance?.SpeedCanvas);

        var player = FindAnyObjectByType<ThirdPersonController>();
        if (player != null)
            player.SetSpeedMultiplier(2f, Mathf.Infinity);

        PlayBuffSound();
    }

    private void JumpDisabled()
    {
        Debug.Log("Debuff Activated: Jump Disabled");
        ShowBuffCanvas(BuffUIManager.Instance?.JumpCanvas);

        var player = FindAnyObjectByType<ThirdPersonController>();
        if (player != null)
            player.DisableJump(5f);

        PlayBuffSound();
    }

    private void InvertControls()
    {
        Debug.Log("Debuff Activated: Invert Controls");
        ShowBuffCanvas(BuffUIManager.Instance?.ReverseCanvas);

        var player = FindAnyObjectByType<ThirdPersonController>();
        if (player != null)
            player.InvertControls(Mathf.Infinity);

        PlayBuffSound();
    }

    private void SlowMotion()
    {
        Debug.Log("Buff Activated: Slow Motion");
        ShowBuffCanvas(BuffUIManager.Instance?.SlowCanvas);

        var player = FindAnyObjectByType<ThirdPersonController>();
        if (player != null)
            player.SetSpeedMultiplier(0.6f, Mathf.Infinity);

        PlayBuffSound();
    }

    private void EnlargePlayer()
    {
        Debug.Log("Buff Activated: BIG Player");
        ShowBuffCanvas(BuffUIManager.Instance?.SizeCanvas);

        var player = FindAnyObjectByType<ThirdPersonController>();
        if (player != null)
            player.SetTemporaryScale(Vector3.one * 2f, Mathf.Infinity);

        PlayBuffSound();
    }

    private void MotionSickness()
    {
        Debug.Log("Debuff Activated: Motion Sickness");
        ShowBuffCanvas(BuffUIManager.Instance?.NoSightCanvas);

        var effect = FindAnyObjectByType<MotionSicknessEffect>();
        if (effect != null)
            effect.TriggerEffect();
        else
            Debug.LogWarning("MotionSicknessEffect not found.");

        PlayBuffSound();
    }

    // ------------------------ HILFSMETHODEN ------------------------

    private void ShowBuffCanvas(GameObject canvas)
    {
        if (BuffUIManager.Instance != null)
        {
            BuffUIManager.Instance.DeactivateAll();
            if (canvas != null)
                canvas.SetActive(true);
            else
                Debug.LogWarning("Canvas reference is null.");
        }
        else
        {
            Debug.LogWarning("BuffUIManager.Instance is null – UI skipped.");
        }
    }

    private void PlayBuffSound()
    {
        if (audioManager == null)
            audioManager = FindObjectOfType<AudioManager>();

        if (audioManager != null && audioManager.buffer != null)
            audioManager.PlaySFX(audioManager.buffer, 0.8f);
        else
            Debug.LogWarning("AudioManager or buffer clip is missing.");
    }
}
