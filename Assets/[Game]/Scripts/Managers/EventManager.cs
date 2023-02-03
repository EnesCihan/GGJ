using UnityEngine;
using UnityEngine.Events;
public class EventManager : MonoBehaviour
{
    public static UnityEvent OnLevelStart = new UnityEvent();
    public static UnityEvent OnOpenMenu = new UnityEvent();
    public static UnityEvent OnCloseMenu = new UnityEvent();
    public static UnityEvent OnWin = new UnityEvent();
    public static UnityEvent OnLoose = new UnityEvent();
}
public class BoolEvent : UnityEvent<bool> { }
public class IntEvent : UnityEvent<int> { }
public class FloatEvent : UnityEvent<float> { }
public class GameObjectEvent : UnityEvent<GameObject> { }
public class StringEvent : UnityEvent<string> { }
