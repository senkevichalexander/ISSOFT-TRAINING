﻿using FinalTask.Framework;
using FinalTask.TestData;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace FinalTask.Pages.LoginPage
{
    public class CreateAnAccountPage : PageBase
    {
        private User _user;
        public CreateAnAccountPage() : base(Browser.Driver.Url)
        {

        }

        private const string _createAnAccountPage = "http://automationpractice.com/index.php?controller=authentication&back=my-account#account-creation";
        private readonly string title = "Login - My Store";

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

            if (emailInField != _user.EmailValue)
            {
                _emailField.Clear();
                _emailField.SendKeys(_user.EmailValue);
            }
        }

        public void RegisterWithRequiredFields(User user)
        {
            _user = user;

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
            ImplicitlyWait(5);
            _genderMaleCheckbox.Click();
        }

        #region Selects
        public void SelectState()
        {
            var selectElement = new SelectElement(_stateDropbox);

            selectElement.SelectByText(_user.State);
        }

        public void SelectCountry()
        {
            var selectElement = new SelectElement(_countryDropbox);

            selectElement.SelectByText(_user.Country);
        }
        #endregion


        #region Input Values 
        public void InputFirstName()
        {
            _firstNameField.SendKeys(_user.FirstName);
        }

        public void InputLastName()
        {
            _lastNameField.SendKeys(_user.LastName);
        }

        public void InputPassword()
        {
            _passwordField.SendKeys(_user.Password);
        }

        public void InputFirstNameInAdressSection()
        {
            _firstNameInAdressSection.Clear();
            _firstNameInAdressSection.SendKeys(_user.FirstName);
        }

        public void InputLastNameInAdressSection()
        {
            _lastnameInAdressSection.Clear();
            _lastnameInAdressSection.SendKeys(_user.LastName);
        }

        public void InputAdress()
        {
            _adressField.SendKeys(_user.Adress);
        }

        public void InputCityName()
        {
            _cityField.SendKeys(_user.City);
        }

        public void InputPostCode()
        {
            _postCodeField.SendKeys(_user.PostCode);
        }

        public void InputMobilePhone()
        {
            _mobilePhoneField.SendKeys(_user.MobilePhone);
        }
        public void InputAlias()
        {
            _aliasField.Clear();
            _aliasField.SendKeys(_user.AdressAlias);
        }
        #endregion
        #endregion
    }
}