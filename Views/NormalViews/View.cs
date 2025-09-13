using GameShop.App;
using GameShop.App.ViewsComponents;

namespace GameShop.Views.NormalViews
{
    abstract internal class View
    {
        protected readonly ViewType _viewType;
        protected readonly MenuManager _menuManager = new();
        protected List<string>? _menuData;
        protected List<string>? _infoData;
        protected View(ViewType viewType)
        {
            _viewType = viewType;
            GetData();
        }
        private void GetData()
        {
           _menuData = LanguageManager.GetData(_viewType, DataType.OptionList);
           _menuData = LanguageManager.GetData(_viewType, DataType.InfoList);
        }
    }
}
