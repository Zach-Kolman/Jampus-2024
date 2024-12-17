using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class ConvoStopper : MonoBehaviour
{
    public DialogueSystemController dmanager;

    public void StopConvo()
    {
        dmanager.StopAllConversations();
    }
}
