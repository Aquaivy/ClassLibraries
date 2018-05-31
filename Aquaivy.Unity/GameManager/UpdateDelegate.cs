namespace Aquaivy.Unity
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="elapseTime"></param>
    public delegate void UpdateDelegate(int elapseTime);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="focus"></param>
    public delegate void ApplicationFocusDelegate(bool focus);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pause"></param>
    public delegate void ApplicationPauseDelegate(bool pause);

    /// <summary>
    /// 
    /// </summary>
    public delegate void ApplicationQuitDelegate();

}