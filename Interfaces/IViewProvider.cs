namespace GameShop.Interfaces
{
    /// <summary>
    /// Defines a contract for initializing and transitioning between views in an application.
    /// </summary>
    /// <remarks>Implementations of this interface are responsible for managing the lifecycle of views, 
    /// including their initialization and determining the next view to display.</remarks>
    internal interface IViewProvider
    {
        void InitView();
        ViewType NextView();
    }
}
