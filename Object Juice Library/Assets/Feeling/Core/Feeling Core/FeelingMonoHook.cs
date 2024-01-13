using UnityEngine;

public class FeelingMonoHook : MonoBehaviour
{
    public static FeelingMonoHook Instance { get; set; }

    public void Initialise() 
        => Instance = this;
}
