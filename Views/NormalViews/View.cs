using GameShop.App;

namespace GameShop.Views.NormalViews
{
    abstract internal class View
    {
        protected readonly ViewType _viewType;
        protected List<string>? _menuData;
        protected List<string>? _infoData;
        protected View(ViewType viewType)
        {
            _viewType = viewType;
            GetData();
        }
        abstract protected void InitOptionList();
        abstract protected void InitInfoList();
        protected void GetData()
        {
           _menuData = LanguageManager.GetData(_viewType, DataType.OptionList);
           _infoData = LanguageManager.GetData(_viewType, DataType.InfoList);
        }
    }
}
