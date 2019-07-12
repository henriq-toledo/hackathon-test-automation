using HackathonTestAutomation.Tests.Classes.Helpers.Forms;

namespace HackathonTestAutomation.Tests.Interfaces
{
    internal interface ISetter<TType, TFormHelper>
        where TFormHelper : BaseFormHelper
    {
        TFormHelper SetValue(TType value);
    }
}
