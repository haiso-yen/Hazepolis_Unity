using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Singleton : MonoBehaviour
//{
//    // Start is called before the first frame update
//    public static Singleton instance;

//    private void Awake()
//    {
//        if (instance == null)
//        {
//            instance = this;
//        }
//        else
//        {
//            if (instance != this)
//            {
//                Destroy(gameObject);
//            }
//        }
//        DontDestroyOnLoad(gameObject);
//    }
//}

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T instance;

    public static T Instance
    {
        get { return instance; }
    }

    protected virtual void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = (T)this;
    }

    public static bool IsInitialized
    {
        get { return instance != null; }
    }

    protected virtual void OnDestroy()
    {
        if (instance == this)
        {
            if (instance == this)
            {
                instance = null;
            }
        }
    }
}
