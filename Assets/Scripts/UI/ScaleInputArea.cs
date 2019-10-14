using UnityEngine.UI;
using UnityEngine;

public class ScaleInputArea : MonoBehaviour
{
    [SerializeField] private bool _InvertedX = false;

    private RectTransform _LocalRT;
    private RectTransform _MainCanvasRT;

    private Vector2 _ScreenSize;

    private void Awake()
    {
        _LocalRT = GetComponent<RectTransform>();
        _MainCanvasRT = GameObject.Find("MainCanvas").GetComponent<RectTransform>();
    }

    void Update()
    {
        if(_ScreenSize != _MainCanvasRT.sizeDelta)
        {
            _ScreenSize = _MainCanvasRT.sizeDelta;

            if (!_InvertedX)
                _LocalRT.sizeDelta = new Vector2(_ScreenSize.x / 2, _ScreenSize.y);
            else
                _LocalRT.sizeDelta = new Vector2(-_ScreenSize.x / 2, _ScreenSize.y);
        }
    }
}
