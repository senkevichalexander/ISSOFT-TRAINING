using Allure.Commons;
using Allure.NUnit.Attributes;
using FinalTask.Framework;
using FinalTask.Helpers;
using FinalTask.Pages;
using NUnit.Framework;
using System.Linq;

namespace FinalTask.Tests
{
    [TestFixture]
    [AllureSuite("")]
    public class Tests : AllureReport
    {
        private readonly ReportHelper _reportHelper = new ReportHelper();

        [OneTimeSetUp]
        public void Setup()
        {
            Browser.Initializes(true);
            var loginPage = PageGenerator.LoginPage;
            loginPage.OpenLoginPage();
            Assert.IsTrue(loginPage.IsOpened, "Login page must be  opened");
                        
            loginPage.InputEmailForSignIn();
            loginPage.InputPasswordForSignIn();
            loginPage.ClickSignInButton();

            var myAccountPage = PageGenerator.MyAccountPage;
            Assert.IsTrue(myAccountPage.IsOpened, "MyAcccount page must be opened");
        }

        [Test(Description = "Add to auto-created wishlist")]
        [AllureSeverity(Allure.Commons.Model.SeverityLevel.Minor)]
        [AllureLink("http://automationpractice.com/")]
        [AllureOwner("Alexander Senkevich")]
        [AllureSubSuite("Add to Wishlist")]

        public void AddToAutoCreatedWishlist()
        {
            #region Pages
            var loginPage = PageGenerator.LoginPage;
            var myAccountPage = PageGenerator.MyAccountPage;
            var productPage = PageGenerator.ProductPage;
            var header = PageGenerator.Header;
            var myWishlists = PageGenerator.MyWishlistsPage;
            var topSellersBlock = PageGenerator.TopSellersBlock;
            #endregion


            myAccountPage.ClickMyWishlists();
            myAccountPage.ClearTheWishlists();

            topSellersBlock.ClickFirstTopSellersProduct();

            productPage.ClickAddToWishlistButton();
            productPage.CloseOverlayAddToWishlist();
            var productPropertiesFromProductPage = productPage.GetProductPropertiesToList();

            header.ClickAccount();
            myAccountPage.ClickMyWishlists();

            myWishlists.OpenWishlistDetail();
            var productPropertiesFromWishlist = myWishlists.GetProductPropertiesToList();

            Assert.IsTrue(Enumerable.SequenceEqual(productPropertiesFromProductPage.OrderBy(t => t),
                productPropertiesFromWishlist.OrderBy(t => t)), "Productis added to auto-created wishlist");
        }


        [Test(Description = "Create a wishlist and add prioduct")]
        [AllureSeverity(Allure.Commons.Model.SeverityLevel.Minor)]
        [AllureLink("http://automationpractice.com/")]
        [AllureOwner("Alexander Senkevich")]
        [AllureSubSuite("Create wishlist")]

        public void AddProductToCreatedWishlist()
        {
            #region Pages
            var loginPage = PageGenerator.LoginPage;
            var myAccountPage = PageGenerator.MyAccountPage;
            var productPage = PageGenerator.ProductPage;
            var header = PageGenerator.Header;
            var myWishlists = PageGenerator.MyWishlistsPage;
            var topSellersBlock = PageGenerator.TopSellersBlock;
            #endregion

            header.ClickAccount();

            myAccountPage.ClickMyWishlists();

            myWishlists.InputNameOfWishList();
            myWishlists.ClickSaveButton();

            topSellersBlock.ClickFirstTopSellersProduct();

            productPage.ClickAddToWishlistButton();
            productPage.CloseOverlayAddToWishlist();
            var productPropertiesFromProductPage = productPage.GetProductPropertiesToList();

            header.ClickAccount();
            myAccountPage.ClickMyWishlists();

            myWishlists.OpenWishlistDetail();
            var productPropertiesFromWishlist = myWishlists.GetProductPropertiesToList();

            Assert.IsTrue(Enumerable.SequenceEqual(productPropertiesFromProductPage.OrderBy(t => t),
                productPropertiesFromWishlist.OrderBy(t => t)), "Product is added to auto-created wishlist");
        }


        [Test(Description = "Verify the ability to add to cart")]
        [AllureSeverity(Allure.Commons.Model.SeverityLevel.Minor)]
        [AllureLink("http://automationpractice.com/")]
        [AllureOwner("Alexander Senkevich")]
        [AllureSubSuite("Add card")]

        public void CardAddTest()
        {
            #region Pages
            var header = PageGenerator.Header;
            var loginPage = PageGenerator.LoginPage;
            var myAccountPage = PageGenerator.MyAccountPage;
            var productPage = PageGenerator.ProductPage;
            var topSellersBlock = PageGenerator.TopSellersBlock;
            var cartMenu = PageGenerator.CartMenu;
            var shoppingCartPage = PageGenerator.ShoppingCartPage;
            #endregion

            loginPage.OpenLoginPage();

            header.ClickAccount();
            myAccountPage.ClickMyWishlists();

            topSellersBlock.ClickFirstTopSellersProduct();
            productPage.ClickAddToCardButton();
            productPage.ClickContinueShoppingButton();
            var firstProductPrice = productPage.GetProductPrice();
            Browser.ReturnToPreviousPage();

            topSellersBlock.ClickSecondTopSellersProduct();
            productPage.ClickAddToCardButton();
            productPage.ClickContinueShoppingButton();
            var secondProductPrice = productPage.GetProductPrice();
            Browser.ReturnToPreviousPage();

            topSellersBlock.ClickThirdTopSellersProduct();
            productPage.ClickAddToCardButton();
            productPage.ClickContinueShoppingButton();
            var thirdProductPrice = productPage.GetProductPrice();
            var allProductsPrice = firstProductPrice + secondProductPrice + thirdProductPrice;

            cartMenu.ClickShoppingCartMennu();
            var allAddedInCartProductsSum = shoppingCartPage.GetSumFromProductsPrice();

            Assert.IsTrue(allProductsPrice == allAddedInCartProductsSum &&
                shoppingCartPage.IsPriceOfTheProductEqual(), "Products are added to the card and prices are the same");
        }


        [OneTimeTearDown]
        public void AfterTests()
        {
            _reportHelper.MakeScreenshorAfterTestIsFailed();
            Browser.Quit();
        }
    }
}