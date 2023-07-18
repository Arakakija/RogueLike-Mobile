using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    public static T Instance
    {
        get
        {
            // If the instance is already set, return it
            if (instance != null)
            {
                return instance;
            }

            // Try to find an instance in the scene
            instance = FindObjectOfType<T>();

            // If no instance found, create a new GameObject and add the component
            if (instance == null)
            {
                GameObject singletonObject = new GameObject(typeof(T).Name);
                instance = singletonObject.AddComponent<T>();
            }

            // Make sure the instance persists across scenes
            DontDestroyOnLoad(instance.gameObject);

            return instance;
        }
    }

    protected virtual void Awake()
    {
        // Check if another instance already exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
    }
}