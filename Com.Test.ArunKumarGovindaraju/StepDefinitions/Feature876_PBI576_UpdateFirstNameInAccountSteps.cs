using Com.Test.ArunKumarGovindaraju.ReusableMethods;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Com.Test.ArunKumarGovindaraju.StepDefinitions
{
    [Binding]
    public class Feature876_PBI576_UpdateFirstNameInAccountSteps : ReusableMethods.Hooks
    {
        [Then(@"i update first name and save")]
        public void ThenIUpdateFirstNameAndSave(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            PageObjectModel.AccountPage.ClickAccount();
            CommonClass.impWait();
            PageObjectModel.AccountPage.updatefirstnameandverify((string)data.name);

        }
    }
}
