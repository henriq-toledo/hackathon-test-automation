using HackathonTestAutomation.Tests.Classes.Helpers.Forms;

namespace HackathonTestAutomation.Tests.Interfaces
{
    internal interface IGetter<TType, TFormHelper>
        where TFormHelper : BaseFormHelper
    {
        TFormHelper GetValue(out TType value);
    }
}
