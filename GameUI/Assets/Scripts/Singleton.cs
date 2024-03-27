using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component {
    private static T INSTANCE;

    public static T Instance {
        get {
            if (INSTANCE == null) {
                INSTANCE = FindObjectOfType<T>();
                if(INSTANCE == null) {
                    GameObject singleton = new GameObject(typeof(T).Name);
                    INSTANCE = singleton.AddComponent<T>();
                }
            }
            return INSTANCE;
        }
    }

    private void Awake() {
        if(INSTANCE == null) {
            INSTANCE = this as T;
            DontDestroyOnLoad(gameObject);
            return;
        }

        Debug.LogFormat("Found second instance of {0}, Destroying myself.", typeof(T).Name);
        Destroy(gameObject);
    }

}
