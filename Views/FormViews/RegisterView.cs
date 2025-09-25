using GameShop.App.Components;
using GameShop.App.ViewsComponents;
using GameShop.Interfaces;

namespace GameShop.Views.FormViews
{
    internal class RegisterView(ViewType viewType) : FormView(viewType), IViewProvider
    {
        public void InitView()
        {
            Console.Clear();
            FrameManager.FrameInit();
            InitOptionList();
            InitInfoList();
            _infoManager.InitInfo();
            _form.RenderForm();
            InitForm();
            
        }
        protected override void InitForm()
        {
            _form.RunForm();
            if (_form.GetActionFromField() == FieldType.Submit) FormValidation();
        }
        /// <summary>
        /// Validates the user input from the form fields and performs necessary actions based on the validation
        /// results.
        /// </summary>
        /// <remarks>This method validates the nickname, password, and confirmed password entered by the
        /// user.  It checks for input validity, password equality, password requirements, and account existence.  If
        /// any validation fails, an appropriate message is displayed, and the process is halted.  If all validations
        /// pass, a new user is registered, and the next view is set to indicate successful registration.</remarks>
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
            UserManager.AddNewUser(nickname, password);
            _nextView = ViewType.SuccesfulRegistration;
        }
        protected override void InitOptionList()
        {
            Console.SetCursorPosition(2, 0);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(_menuData[0]);
            Console.ResetColor();
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
