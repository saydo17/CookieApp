using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CookieApp.ApplicationServices.CommandHandlers;
using CookieApp.Core.AppServices;
using CookieApp.Core.Inventory;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace CookieApp.Core.Tests
{
    [ExcludeFromCodeCoverage]
    [TestFixture]
    public class TroopInventoryTests
    {
        private TroopCookieInventory _troopInventory;
        private readonly Mock<IUnitOfWork> _unitOfWork = new Mock<IUnitOfWork>();
        private GirlScoutCookieInventory _girlInventory;

        [SetUp]
        public void Initialize()
        {
            _troopInventory = new TroopCookieInventory() {Id = 1};
            _girlInventory = new GirlScoutCookieInventory() {Id = 2};
        }

        [Test]
        public void EmptyTroopInventory_HasAllCookieTypes_ZeroQuantity_ZeroBalance()
        {
            _troopInventory.Stacks.Count().Should().Be(8);
            _troopInventory.Stacks.Select(c=>c.CookieQuantity.Cookie.Variety).Distinct().Count().Should().Be(8);
            _troopInventory.Stacks.Sum(c => c.CookieQuantity.Quantity).Should().Be(0);
            _troopInventory.Balance.Should().Be(0);
        }

        [Test]
        public void AddCookiesFromCupboard_Succeeds()
        {
            var command = new AddCookiesFromCupboardCommand(new[]
            {
                new CookieQuantity(10, Cookie.DosiSo),
                new CookieQuantity(15, Cookie.Samoas),
            }, DateTime.UtcNow, 1);

            _unitOfWork.Setup(f => f.Get<TroopCookieInventory>(It.Is<int>(id => id == 1))).Returns(_troopInventory);

            var handler = new AddCookiesFromCupboardCommandHandler(_unitOfWork.Object);
            var result = handler.Handle(command);

            result.IsSuccess.Should().BeTrue();

            _troopInventory.Stacks.Count.Should().Be(8);
            _troopInventory.Stacks.Sum(s => s.CookieQuantity.TotalAmount).Should().Be(125);
        }

        [Test]
        public void TransferFromTroopInventory_ToGirlInventory_Succeeds()
        {
            AddCookiesFromCupboard_Succeeds();


            _unitOfWork.Setup(f => f.Get<CookieInventory>(It.Is<int>(id => id == 1))).Returns(_troopInventory);
            _unitOfWork.Setup(f => f.Get<CookieInventory>(It.Is<int>(id => id == 2))).Returns(_girlInventory);

            var command = new TransferCookiesCommand(1, 2,
                new[] {new CookieQuantity(5, Cookie.DosiSo)}, DateTime.UtcNow);

            var handler = new TransferCookiesCommandHandler(_unitOfWork.Object);
            var result = handler.Handle(command);

            result.IsSuccess.Should().BeTrue();

            _troopInventory.Balance.Should().Be(100);
            _troopInventory.Stacks.Sum(c => c.CookieQuantity.Quantity).Should().Be(20);
            _girlInventory.Balance.Should().Be(25);
            _girlInventory.Stacks.Sum(c => c.CookieQuantity.Quantity).Should().Be(5);
        }

        [Test]
        public void TransferToTroopInventory_FromGirlInventory_Succeeds()
        {
            TransferFromTroopInventory_ToGirlInventory_Succeeds();

            _unitOfWork.Setup(f => f.Get<CookieInventory>(It.Is<int>(id => id == 1))).Returns(_troopInventory);
            _unitOfWork.Setup(f => f.Get<CookieInventory>(It.Is<int>(id => id == 2))).Returns(_girlInventory);

            var command = new TransferCookiesCommand(2, 1,
                new[] { new CookieQuantity(5, Cookie.DosiSo) }, DateTime.UtcNow);

            var handler = new TransferCookiesCommandHandler(_unitOfWork.Object);
            var result = handler.Handle(command);

            result.IsSuccess.Should().BeTrue();

            _troopInventory.Balance.Should().Be(125);
            _troopInventory.Stacks.Sum(c => c.CookieQuantity.Quantity).Should().Be(25);
            _girlInventory.Balance.Should().Be(0);
            _girlInventory.Stacks.Sum(c => c.CookieQuantity.Quantity).Should().Be(0);

        }


    }
}