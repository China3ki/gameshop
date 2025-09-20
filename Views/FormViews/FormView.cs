using FormController;
using GameShop.App.ViewsComponents;
using GameShop.Views.NormalViews;

namespace GameShop.Views.FormViews
{
    abstract class FormView(ViewType viewType) : View(viewType)
    {
        protected Form _form = new();
        protected InfoManager _infoManager = new();
        protected ViewType _nextView = ViewType.Start;
        abstract protected void FormValidation();
        abstract protected void InitForm();
        protected void UpdateInfo(string info)
        {
            _infoManager.ClearInfo();
            _infoManager.AddElement(info, ConsoleColor.Red, ConsoleColor.Black);
            _infoManager.InitInfo();
            InitForm();
        }
    }
}
