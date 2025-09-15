using GameShop.App.ViewsComponents;
using GameShop.Interfaces;
using GameShop.Views.NormalViews;

namespace GameShop.Views.FormViews
{
    internal class RegisterView(ViewType viewType) : FormView(viewType), IViewProvider
    {
        InfoManager _infoManager = new();
        public void InitView()
        {
            Console.Clear();
            InitOptionList();
            InitInfoList();
            FrameManager.FrameInit();
            _infoManager.InitInfo();
            _form.RenderForm();
            _form.RunForm();
        }
        protected override void InitForm()
        {
        }
        protected override void FormValidation()
        {

        }
        protected override void InitOptionList()
        {
            _form.AddField(_menuData[1], FieldType.Text, 2, 1);
            _form.AddField(_menuData[2], FieldType.Password, 2, 2);
            _form.AddField(_menuData[3], FieldType.Password, 2, 3);
            _form.AddField(_menuData[4], FieldType.ShowPassword, 2, 4);
            _form.AddField(_menuData[5], FieldType.Submit, 2, 5);
            _form.AddField(_menuData[6], FieldType.Cancel, 2, 6);
        }
        protected override void InitInfoList()
        {
            _infoManager.AddElement(_infoData[0], ConsoleColor.Yellow, ConsoleColor.Black);
            _infoManager.AddElement(_infoData[1], ConsoleColor.White, ConsoleColor.Black);
            _infoManager.AddElement(_infoData[2], ConsoleColor.DarkYellow, ConsoleColor.Black);
        }
        public ViewType NextView()
        {
            return ViewType.Start;
        }
    }
}
