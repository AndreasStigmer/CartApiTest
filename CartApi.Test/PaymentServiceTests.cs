using CartApi.Controllers;
using CartApi.Models;
using CartApi.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartApi.Test
{
    [TestFixture]
    public class CartControllerTests
    {
        private CartController controller;
        Mock<IPaymentService> paymentMock;
        Mock<ICartService> cartMock;
        Mock<IShipmentService> shipmentMock;
        Mock<IAddressInfo> addressMock;
        
        [SetUp]
        public void Config()
        {
            shipmentMock = new Mock<IShipmentService>();
            paymentMock=new Mock<IPaymentService>();
            cartMock = new Mock<ICartService>();
            addressMock = new Mock<IAddressInfo>();

            controller = new CartController(cartMock.Object, paymentMock.Object, shipmentMock.Object);
        }

        [Test]
        public void Checkout_WhenCalled_ReturnsAsCharged()
        {
            cartMock.Setup(c=>c.Items()).Returns(new List<CartItem>());
            var card = new Mock<ICard>();
            paymentMock.Setup(k => k.Charge(It.IsAny<double>(), card.Object)).Returns(true);
            var items=new List<CartItem>();
            var result = controller.CheckOut(card.Object, addressMock.Object);

            shipmentMock.Verify((d) => d.Ship(addressMock.Object,items.AsEnumerable()), Times.Once);
           
            Assert.That(result, Is.EqualTo("charged"));

        }


    }
}
