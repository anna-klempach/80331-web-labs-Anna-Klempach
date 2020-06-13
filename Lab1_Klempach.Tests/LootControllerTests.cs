using WebLabs_Klempach.Controllers;
using System;
using Xunit;
using WebLabs_Klempach.DAL.Entities;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebLabs_Klempach.Models;

namespace WebLabs_Klempach.Tests
{
    public class LootControllerTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void ControllerGetsProperPage(int currentPage, int itemsQuantity, int firstItemId)
        {
            var controller = new LootController();
            controller._lootList = GetLootList();

            var result = controller.Index(category: null, currentPage) as ViewResult;
            var model = result.Model as List<Loot>;

            Assert.NotNull(model);
            Assert.Equal(itemsQuantity, model.Count);
            Assert.Equal(firstItemId, model[0].LootId);
        }
        [Theory]
        [InlineData(1, 3, 0)]
        [InlineData(2, 2, 3)]
        public void ControllerSelectsProperItems(int categoryId, int itemsQuantity, int index)
        {
            var controller = new LootController();
            controller._lootList = GetLootList();

            var result = controller.Index(categoryId, 1) as ViewResult;
            var model = result.Model as List<Loot>;

            Assert.NotNull(model);
            Assert.Equal(itemsQuantity, model.Count);
            Assert.Equal(GetLootList()[index],
                model[0],
                Comparer<Loot>.GetComparer((loot1, loot2) => loot1.LootCategoryId == loot2.LootCategoryId));
        }

        [Theory]
        [MemberData(memberName:nameof(Data))]
        public void ListNewModelGetsCorrectPagesCount(int currentPage, int itemsQuantity, int firstItemId)
        {
            var model = ListViewModel<Loot>.GetModel(GetLootList(), currentPage, 3);
            Assert.Equal(2, model.NumberOfPages);
        }

        [Theory]
        [MemberData(memberName: nameof(Data))]
        public void ListNewModelGetsCorrectLootList(int currentPage, int itemsQuantity, int firstItemId)
        {
            var model = ListViewModel<Loot>.GetModel(GetLootList(), currentPage, 3);
            Assert.Equal(firstItemId, model[0].LootId);
        }

        [Theory]
        [MemberData(memberName: nameof(Data))]
        public void ListNewModelGetsCorrectQuantity(int currentPage, int itemsQuantity, int firstItemId)
        {
            var model = ListViewModel<Loot>.GetModel(GetLootList(), currentPage, itemsQuantity);
            Assert.Equal(itemsQuantity, model.Count);
        }

        public static IEnumerable<object[]> Data()
        {
            yield return new object[] { 1, 3, 1 };
            yield return new object[] { 2, 2, 4 };
        }

        private List<Loot> GetLootList()
        {
            return new List<Loot>
                {
                    new Loot { LootId = 1, LootCategoryId = 1 },
                    new Loot { LootId = 2, LootCategoryId = 1 },
                    new Loot { LootId = 3, LootCategoryId = 1 },
                    new Loot { LootId = 4, LootCategoryId = 2 },
                    new Loot { LootId = 5, LootCategoryId = 2 },
                };
        }
    }
}
