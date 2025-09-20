using GameShop.App.Components;
using GameShop.App.ViewsComponents;
using GameShop.Interfaces;
using GameShop.Views.NormalViews;
using System.Diagnostics;

namespace GameShop.Views.FormViews
{
    internal class RegisterView(ViewType viewType) : FormView(viewType), IViewProvider
    {
        public void InitView()
        {
            Console.Clear();
            InitOptionList();
            InitInfoList();
            FrameManager.FrameInit();
            _infoManager.InitInfo();
            _form.RenderForm();
            InitForm();
            
        }
        protected override void InitForm()
        {
            _form.RunForm();
            if (_form.GetActionFromField() == FieldType.Submit) FormValidation();
        }
        protected override void FormValidation()
        {
            List<string> validationList = LanguageManager.GetData(ViewType.Validation, DataType.InfoList);
            string nickname = _form.GetDataFromField(0);
            string password = _form.GetDataFromField(1);
            string confirmedPassword = _form.GetDataFromField(2);
            if (!ValidationManager.InputValidation(nickname, password, confirmedPassword))
            {
                UpdateInfo(validationList[0]);
                return;
            }
            if (!ValidationManager.PasswordEqualityValidation(password, confirmedPassword))
            {
                UpdateInfo(validationList[1]);
                return;
            }
            if (!ValidationManager.PasswordRequirementsValidation(password))
            {
                UpdateInfo(validationList[2]);
                return;
            }
            if (!ValidationManager.AccountValidation(nickname))
            {
                UpdateInfo(validationList[3]);
                return;
            }
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
            return _nextView;
        }
    }
}
