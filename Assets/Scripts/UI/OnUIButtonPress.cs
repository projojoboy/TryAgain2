using UnityEngine;

public class OnUIButtonPress : MonoBehaviour
{
    public delegate void OnJumpButtonPress();
    public delegate void OnMoveButtonPress(float HMove);

    public static event OnJumpButtonPress JumpEvent;
    public static event OnMoveButtonPress MoveEvent;

    public void OnButtonPress(string buttonType)
    {
        switch (buttonType)
        {
            case "Jump":
                JumpEvent?.Invoke();
                break;

            case "MoveRight":
                MoveEvent?.Invoke(1);
                break;
            case "MoveLeft":
                MoveEvent?.Invoke(-1);
                break;
            case "Stop":
                MoveEvent?.Invoke(0);
                break;
        }
    }
}
