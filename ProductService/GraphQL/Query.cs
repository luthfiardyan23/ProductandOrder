
using System.Linq;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.AspNetCore.Authorization;

using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using ProductService.Models;

namespace ProductService.GraphQL
{
    public class Query
    {
        public IQueryable<Product> GetProducts([Service] ProductQLContext context) =>
            context.Products;

    
    }
}
