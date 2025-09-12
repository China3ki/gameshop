namespace GameShop.Interfaces
{
    internal interface IViewProvider
    {
        void InitView();
        ViewType NextView();
    }
}
