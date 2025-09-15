using FormController;
using GameShop.Views.NormalViews;

namespace GameShop.Views.FormViews
{
    abstract class FormView(ViewType viewType) : View(viewType)
    {
        protected Form _form = new();
        abstract protected void FormValidation();
        abstract protected void InitForm();
    }
}
