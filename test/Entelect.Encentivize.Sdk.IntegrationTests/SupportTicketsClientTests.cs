using System;
using System.Linq;
using Entelect.Encentivize.Sdk.SupportTickets;
using Entelect.Encentivize.Sdk.SupportTickets.Categories;
using Entelect.Encentivize.Sdk.SupportTickets.Types;
using NUnit.Framework;

namespace Entelect.Encentivize.Sdk.IntegrationTests
{
    [TestFixture]
    public class SupportTicketsClientTests : SdkTestBase
    {
        [Test]
        public void Search()
        {
            var searchResult = SupportTicketsClient.Search(new SupportTicketSearchCriteria());
            Assert.NotNull(searchResult);
            Assert.Greater(searchResult.Data.Count, 0);
        }

        [Test]
        public void GetById()
        {
            var item = SupportTicketsClient.Get(SupportTicketsClient.Search(new SupportTicketSearchCriteria()).Data.First().SupportTicketId);
            Assert.NotNull(item);
        }

        [Test]
        public void Create()
        {
            var guidString = Guid.NewGuid().ToString();
            var createdItem = CreateSomeEntity(guidString);
            Assert.NotNull(createdItem);
            Assert.Greater(createdItem.SupportTicketId, 0);
        }

        [Test]
        public void Update()
        {
            var guid = Guid.NewGuid().ToString();
            var updated = SupportTicketsClient.Update(GetSomeEntity().SupportTicketId, new EditSupportTicketInput
            {
                IsResolved = false,
                NewComment = guid
            });
            Assert.NotNull(updated);
        }

        public SupportTicket GetSomeEntity()
        {
            var pagedItems = SupportTicketsClient.Search(new SupportTicketSearchCriteria());
            var firstItem = pagedItems.Data.FirstOrDefault();
            if (firstItem == null)
            {
                firstItem = CreateSomeEntity(Guid.NewGuid().ToString());
            }
            return firstItem;
        }

        public SupportTicket CreateSomeEntity(string guidString)
        {
            var itemToCreate = GetSomeInput(guidString);
            var createdItem = SupportTicketsClient.Create(itemToCreate);
            return createdItem;
        }

        public SupportTicketInput GetSomeInput(string guidString)
        {
            
            var itemToCreate = new SupportTicketInput
            {
                Comment = guidString,
                Subject = guidString,
                SupportTicketCategoryId = SupportTicketCategoriesClient.Search(new SupportTicketCategorySearchCriteria()).Data.First().SupportTicketCategoryId,
                SupportTicketTypeId = SupportTicketTypesClient.Search(new SupportTicketTypeSearchCriteria()).Data.First().SupportTicketTypeId,
                SupportTicketPriorityId = 2
                
            };
            return itemToCreate;
        }
    }
}