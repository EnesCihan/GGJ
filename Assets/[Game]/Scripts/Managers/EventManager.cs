using UnityEngine;
using UnityEngine.Events;
public class EventManager : MonoBehaviour
{
    public static UnityEvent OnLevelStart = new UnityEvent();
    public static UnityEvent CloseSettingsMenu = new UnityEvent();
    public static UnityEvent OpenSettingsMenu = new UnityEvent();
    public static UnityEvent OnMenu = new UnityEvent();
    public static UnityEvent OnGameStart = new UnityEvent();
    public static UnityEvent OnWin = new UnityEvent();
    public static UnityEvent OnLoose = new UnityEvent();
}
public class BoolEvent : UnityEvent<bool> { }
public class IntEvent : UnityEvent<int> { }
public class FloatEvent : UnityEvent<float> { }
public class GameObjectEvent : UnityEvent<GameObject> { }
public class StringEvent : UnityEvent<string> { }
