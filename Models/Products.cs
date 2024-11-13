using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;
using TestDOT.Models;

namespace TestDOT.Models
{
    [Table("t_produk", Schema = "v1")]
    public class Products
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Column("nama")]
        public string Nama { get; set; }
        [Column("jumlah")]
        public string Jumlah { get; set; }
        [Column("created_at")]
        public DateTime? CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
        [Column("deleted_at")]
        public DateTime? DeletedAt { get; set; }
    }


public static class ProductsEndpoints
{
	public static void MapProductsEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Products").WithTags(nameof(Products));

        group.MapGet("/", async (EntityContext db) =>
        {
            return await db.Products.ToListAsync();
        })
        .WithName("GetAllProducts")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Products>, NotFound>> (Guid id, EntityContext db) =>
        {
            return await db.Products.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Products model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetProductsById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (Guid id, Products products, EntityContext db) =>
        {
            var affected = await db.Products
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, products.Id)
                  .SetProperty(m => m.Nama, products.Nama)
                  .SetProperty(m => m.Jumlah, products.Jumlah)
                  .SetProperty(m => m.CreatedAt, products.CreatedAt)
                  .SetProperty(m => m.UpdatedAt, products.UpdatedAt)
                  .SetProperty(m => m.DeletedAt, products.DeletedAt)
                  );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateProducts")
        .WithOpenApi();

        group.MapPost("/", async (Products products, EntityContext db) =>
        {
            db.Products.Add(products);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Products/{products.Id}",products);
        })
        .WithName("CreateProducts")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (Guid id, EntityContext db) =>
        {
            var affected = await db.Products
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteProducts")
        .WithOpenApi();
    }
}}
