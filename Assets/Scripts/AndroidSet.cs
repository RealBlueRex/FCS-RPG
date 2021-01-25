using UnityEngine;

public class AndroidSet : MonoBehaviour
{

#if UNITY_ANDROID

    static public AndroidSet instance;

    AndroidJavaObject currentActivity;
    AndroidJavaClass UnityPlayer;
    AndroidJavaObject context;
    AndroidJavaObject toast;


    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        UnityPlayer =
            new AndroidJavaClass("com.unity3d.player.UnityPlayer");

        currentActivity = UnityPlayer
            .GetStatic<AndroidJavaObject>("currentActivity");


        context = currentActivity
            .Call<AndroidJavaObject>("getApplicationContext");

        DontDestroyOnLoad(this.gameObject);
    }

    void ShowToast(string message)
    {
        currentActivity.Call
        (
            "runOnUiThread",
            new AndroidJavaRunnable(() =>
            {
                AndroidJavaClass Toast
                = new AndroidJavaClass("android.widget.Toast");

                AndroidJavaObject javaString
                = new AndroidJavaObject("java.lang.String", message);

                toast = Toast.CallStatic<AndroidJavaObject>
                (
                    "makeText",
                    context,
                    javaString,
                    Toast.GetStatic<int>("LENGTH_SHORT")
                );

                toast.Call("show");
            })
         );
    }

    public void CancelToast()
    {
        currentActivity.Call("runOnUiThread",
            new AndroidJavaRunnable(() =>
            {
                if (toast != null) toast.Call("cancel");
            }));
    }


#else
    void Awake()
    {
        Destroy(gameObject);
    }
#endif

}