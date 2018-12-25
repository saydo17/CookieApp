using System;
using System.Collections.Generic;
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
    public class TroopTests
    {
        private Troop _troop;
        private readonly Mock<IUnitOfWork> _unitOfWork = new Mock<IUnitOfWork>();

        [SetUp]
        public void Initialize()
        {
            _troop = new Troop()
            {
                Id = 1,
                Name = "Troop 1191",
                Inventory = new TroopCookieInventory()
            };

        }

        [Test]
        public void AddGirlScout_Succeeds()
        {
            _unitOfWork.Setup(f => f.Get<Troop>(It.IsAny<int>())).Returns(_troop);

            var command = new AddGirlScoutCommand("Addelleigh", "Cupp", "Danielle", "Cupp", "(619) 995-8257", 1);
            var handler = new AddGirlScoutCommandHandler(_unitOfWork.Object);
            var result = handler.Handle(command);
            result.IsSuccess.Should().BeTrue();
            _troop.GirlScouts.Count.Should().Be(1);
            _troop.GirlScouts.First().Inventory.Stacks.Count.Should().Be(8);

        }

        [Test]
        public void AddGirlScout_Fails()
        {
            _unitOfWork.Setup(f => f.Get<Troop>(It.IsAny<int>())).Returns(default(Troop));

            var command = new AddGirlScoutCommand("Addelleigh", "Cupp", "Danielle", "Cupp", "(619) 995-8257", 1);
            var handler = new AddGirlScoutCommandHandler(_unitOfWork.Object);
            var result = handler.Handle(command);
            result.IsFailure.Should().BeTrue();
            _troop.GirlScouts.Count.Should().Be(0);
        }

        

    }
}