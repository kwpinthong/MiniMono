using UnityEngine;

public abstract class Panel : MonoBehaviour
{
    public void Open()
    {
        PreOpen();
        gameObject.SetActive(true);
        PostOpen();
    }
    
    public void Close()
    {
        PreClose();
        gameObject.SetActive(false);
        PostClose();
    }
    
    public abstract void Initialize();
    protected virtual void PreOpen() { }
    protected virtual void PostOpen() { }
    protected virtual void PreClose() { }
    protected virtual void PostClose() { }
}
