using System;
using System.Collections.Generic;
using System.Text;
using BestStudentsResults.IntegrationTests.Xunit.Fixtures;
using Xunit;

namespace BestStudentsResults.IntegrationTests.Xunit.Collections
{
    [CollectionDefinition(nameof(IntegrationCollection))]
    public class IntegrationCollection:ICollectionFixture<IntegrationFixture>, ICollectionFixture<DbFixture>
    {
    }
}
