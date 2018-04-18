using System;
using UnityEngine;

public class ButtonController : MonoBehaviour {

    public static event Action OnPressed;

    public Transform ButtonCapsule;

    private Vector3 _originalScale;
    private Vector3 _pressedScale;

    private const float PressedZScale = 0.04f;

    public void Start () {
        _originalScale = ButtonCapsule.localScale;
        _pressedScale = new Vector3(_originalScale.x, _originalScale.y, PressedZScale);
    }

    public void OnMouseDown ()
    {
        GetComponent<AudioSource>().Play();
        ButtonCapsule.localScale = _pressedScale;
    }

    public void OnMouseUp ()
    {
        ButtonCapsule.localScale = _originalScale;
    }

    private void OnMouseUpAsButton()
    {
        if (OnPressed != null)
            OnPressed();
    }
}
