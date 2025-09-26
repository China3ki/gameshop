using GameShop.App.Components;
using GameShop.App.ViewsComponents;
using GameShop.Interfaces;

namespace GameShop.Views.FormViews
{
    internal class LoginView(ViewType viewType) : FormView(viewType), IViewProvider
    {
        public void InitView()
        {
            Console.Clear();
            FrameManager.FrameInit();
            InitOptionList();
            InitInfoList();
            _form.RenderForm();
            InitForm();
        }
        public ViewType NextView()
        {
            return _nextView;
        }
        protected override void InitForm()
        {
            _form.RunForm();
            if (_form.GetActionFromField() == FieldType.Submit) FormValidation();
        }
        protected override void InitInfoList()
        {
            Console.SetCursorPosition(2, 0);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(_menuData[0]);
            Console.ResetColor();
            _form.AddField(_menuData[1], FieldType.Text, 2, 1);
            _form.AddField(_menuData[2], FieldType.Password, 2, 2);
            _form.AddField(_menuData[3], FieldType.ShowPassword, 2, 3);
            _form.AddField(_menuData[4], FieldType.Submit, 2, 4);
            _form.AddField(_menuData[5], FieldType.Cancel, 2, 5);
        }
        protected override void InitOptionList()
        {
            _infoManager.AddElement(_infoData[0], ConsoleColor.Yellow, ConsoleColor.Black);
            _infoManager.InitInfo();
        }
        protected override void FormValidation()
        {
            List<string> validationList = LanguageManager.GetData(ViewType.Validation, DataType.InfoList);
            string nickname = _form.GetDataFromField(0);
            string password = _form.GetDataFromField(1);
            if(!ValidationManager.InputValidation(nickname, password))
            {
                UpdateInfo(validationList[0]);
                return;
            }
            if(!ValidationManager.AccountValidation(nickname, password))
            {
                UpdateInfo(validationList[4]);
                return;
            }
            UserManager.LoginUser(nickname);
            _nextView = ViewType.SuccesfulLogin;
        }
    }
}
