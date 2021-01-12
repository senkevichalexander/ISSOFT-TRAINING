using FinalTask.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace FinalTask.Pages.LoginPage
{
    public class CreateAnAccountPage : PageBase
    {
        public CreateAnAccountPage() : base(Browser.Driver.Url)
        {

        }

        private const string _createAnAccountPage = "http://automationpractice.com/index.php?controller=authentication&back=my-account#account-creation";
        private readonly string title = "Login - My Store";

        private readonly string emailValue = "sdad4616@gmail.com";

        private readonly string firstName = "Alexander";
        private readonly string lastName = "Senkevich";
        private readonly string password = "Qwerty1";
        private readonly string adress = "Shulgi";
        private readonly string city = "Fanipol";
        private readonly string zipCode = "22275";
        private readonly string mobilePhone = "+375292727402";
        private readonly string adressAlias = "Fan";
        private readonly string state = "New York";
        private readonly string country = "United States";

        #region WebElements

        [FindsBy(How = How.CssSelector, Using = "input#id_gender1")] 
        private IWebElement _genderMaleCheckbox;

        [FindsBy(How = How.CssSelector, Using = "#customer_firstname")]
        private IWebElement _firstNameField;

        [FindsBy(How = How.CssSelector, Using = "#customer_lastname")]
        private IWebElement _lastNameField;

        [FindsBy(How = How.CssSelector, Using = "#email")]
        private IWebElement _emailField;

        [FindsBy(How = How.CssSelector, Using = "#passwd")]
        private IWebElement _passwordField;

        [FindsBy(How = How.CssSelector, Using = "#firstname.form-control")]
        private IWebElement _firstNameInAdressSection;

        [FindsBy(How = How.CssSelector, Using = "#lastname.form-control")]
        private IWebElement _lastnameInAdressSection;

        [FindsBy(How = How.CssSelector, Using = "#address1")]
        private IWebElement _adressField;

        [FindsBy(How = How.CssSelector, Using = "#city")]
        private IWebElement _cityField;

        [FindsBy(How = How.CssSelector, Using = "#id_state")]
        private IWebElement _stateDropbox;

        [FindsBy(How = How.CssSelector, Using = "#postcode")]
        private IWebElement _postCodeField;

        [FindsBy(How = How.CssSelector, Using = "#id_country")]
        private IWebElement _countryDropbox;

        [FindsBy(How = How.CssSelector, Using = "#phone_mobile")]
        private IWebElement _mobilePhoneField;

        [FindsBy(How = How.CssSelector, Using = "#alias")]
        private IWebElement _aliasField;

        [FindsBy(How = How.CssSelector, Using = "#submitAccount")]
        private IWebElement _registerButton;

        #endregion


        public bool IsOpened
        {
            get { return Browser.Driver.Title.Equals(title); }
        }

        public void ClickRegisterButton()
        {
            _registerButton.Click();
        }

        public void CheckEmail()
        {
            var emailInField = _emailField.GetAttribute("value");

            if(emailInField != emailValue)
            {
                _emailField.Clear();
                _emailField.SendKeys(emailValue);
            }
        }

        public void RegisterWithRequiredFields()
        {
            ClickOnCheckboxWithMaleTitle();
            SelectState();
            SelectCountry();
            InputFirstName();
            InputLastName();
            InputPassword();
            InputFirstNameInAdressSection();
            InputLastNameInAdressSection();
            InputAdress();
            InputCityName();
            InputPostCode();
            InputMobilePhone();
            InputAlias();
            CheckEmail();
        }

        #region Filling all required fields

        public void ClickOnCheckboxWithMaleTitle()
        {
            ImplicitlyWait();
           //WaitUntilElementExists(_genderMaleCheckbox);
            _genderMaleCheckbox.Click();
        }

        #region Selects
        public void SelectState()
        {
            var selectElement = new SelectElement(_stateDropbox);

            selectElement.SelectByText(state);
        }

        public void SelectCountry()
        {
            var selectElement = new SelectElement(_countryDropbox);

            selectElement.SelectByText(country);
        }
        #endregion


        #region Input Values 
        public void InputFirstName()
        {
            _firstNameField.SendKeys(firstName);
        }

        public void InputLastName()
        {
            _lastNameField.SendKeys(lastName);
        }

        public void InputPassword()
        {
            _passwordField.SendKeys(password);
        }

        public void InputFirstNameInAdressSection()
        {
            _firstNameInAdressSection.SendKeys(firstName);
        }

        public void InputLastNameInAdressSection()
        {
            _lastnameInAdressSection.SendKeys(lastName);
        }

        public void InputAdress()
        {
            _adressField.SendKeys(adress);
        }

        public void InputCityName()
        {
            _cityField.SendKeys(city);
        }

        public void InputPostCode()
        {
            _postCodeField.SendKeys(zipCode);
        }

        public void InputMobilePhone()
        {
            _mobilePhoneField.SendKeys(mobilePhone);
        }
        public void InputAlias()
        {
            _aliasField.SendKeys(adressAlias);
        }
        #endregion
        #endregion
    }
}
