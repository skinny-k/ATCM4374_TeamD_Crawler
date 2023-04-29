using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class TouchManager : MonoBehaviour
{
    public static TouchManager Instance;
    
    [SerializeField] GameObject _debugSprite;

    Vector2 _lastPos = Vector2.zero;
    
    public static event Action<Vector2, Vector2> OnFingerMove;
    public static event Action<Vector2> OnFingerDown;
    public static event Action OnFingerUp;

    void OnEnable()
    {
        TouchSimulation.Enable();
        EnhancedTouchSupport.Enable();
        
        Touch.onFingerMove += FingerMove;
        Touch.onFingerDown += FingerDown;
        Touch.onFingerUp += FingerUp;
    }

    void OnDisable()
    {
        Touch.onFingerMove -= FingerMove;
        Touch.onFingerDown -= FingerDown;
        Touch.onFingerUp -= FingerUp;

        TouchSimulation.Disable();
        EnhancedTouchSupport.Disable();
    }

    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void FingerMove(Finger finger)
    {
        OnFingerMove?.Invoke(finger.screenPosition - _lastPos, finger.screenPosition);
        _lastPos = finger.screenPosition;
        
        UpdateDebug(finger, Color.green);
    }

    void FingerDown(Finger finger)
    {
        // Debug.Log("In TouchManager.OnFingerDown()");
        OnFingerDown?.Invoke(finger.screenPosition);
        _lastPos = finger.screenPosition;

        UpdateDebug(finger, Color.white);
    }

    void FingerUp(Finger finger)
    {
        OnFingerUp?.Invoke();

        UpdateDebug(finger, Color.white);
    }

    void UpdateDebug(Finger finger, Color color)
    {
        if (_debugSprite != null)
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(new Vector3(finger.screenPosition.x, finger.screenPosition.y, 18.5f));
            worldPos.z = _debugSprite.transform.position.z;

            SpriteRenderer sprite = _debugSprite.GetComponent<SpriteRenderer>();
            if (sprite != null)
            {
                sprite.color = color;
            }
            _debugSprite.transform.position = worldPos;
        }
    }
}
