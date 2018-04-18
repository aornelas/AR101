using UnityEngine;

public class ButtonController : MonoBehaviour {

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
        ButtonCapsule.localScale = _pressedScale;
    }

    public void OnMouseUp ()
    {
        ButtonCapsule.localScale = _originalScale;
    }
}
