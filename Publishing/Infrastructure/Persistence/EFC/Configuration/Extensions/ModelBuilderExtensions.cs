using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregate;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace ACME.LearningCenterPlatform.API.Publishing.Infrastructure.Persistence.EFC.Configuration.Extensions;

public static class ModelBuilderExtensions
{
    public static void ApplyPublishingConfiguration(this ModelBuilder builder)
    {
        // Publishing Context
        builder.Entity<Category>().HasKey(c => c.Id);
        builder.Entity<Category>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(30);
    
        builder.Entity<Tutorial>().HasKey(t => t.Id);
        builder.Entity<Tutorial>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Tutorial>().Property(t => t.Title).IsRequired().HasMaxLength(50);
        builder.Entity<Tutorial>().Property(t => t.Summary).IsRequired().HasMaxLength(240);
    
        builder.Entity<Asset>().HasDiscriminator(a => a.Type);
        builder.Entity<Asset>().HasKey(a => a.Id);
        builder.Entity<Asset>().HasDiscriminator<string>("asset_type")
            .HasValue<Asset>("asset_base")
            .HasValue<ImageAsset>("asset_image")
            .HasValue<VideoAsset>("asset_video")
            .HasValue<ReadableContentAsset>("asset_readable_content");
    
        builder.Entity<Asset>().OwnsOne(i => i.AssetIdentifier, ai =>
        {
            ai.WithOwner().HasForeignKey("Id");
            ai.Property(p => p.Identifier).HasColumnName("AssetIdentifier");
        });
        builder.Entity<ImageAsset>().Property(p => p.ImageUri).IsRequired();
        builder.Entity<VideoAsset>().Property(p => p.VideoUri).IsRequired();

        builder.Entity<Tutorial>().HasMany(t => t.Assets);

        /////////////////////////////////////////////////////////////////////
        // Property
        builder.Entity<Property>().HasKey(p => p.Id);
        builder.Entity<Property>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Property>().Property(p => p.Name).IsRequired().HasMaxLength(80);
        builder.Entity<Property>().Property(p => p.Location).HasMaxLength(120);
        builder.Entity<Property>().Property(p => p.Description).HasMaxLength(300);
        builder.Entity<Property>().Property(p => p.BasePrice).HasColumnType("decimal(10,2)");
        builder.Entity<Property>().Property(p => p.Type).HasMaxLength(40);

        // Amenity
        builder.Entity<Amenity>().HasKey(a => a.Id);
        builder.Entity<Amenity>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Amenity>().Property(a => a.Name).IsRequired().HasMaxLength(50);

        // PropertyAmenity (N–N)
        builder.Entity<PropertyAmenity>()
            .HasKey(pa => new { pa.PropertyId, pa.AmenityId });

        builder.Entity<PropertyAmenity>()
            .HasOne(pa => pa.Property)
            .WithMany(p => p.PropertyAmenities)
            .HasForeignKey(pa => pa.PropertyId);

        builder.Entity<PropertyAmenity>()
            .HasOne(pa => pa.Amenity)
            .WithMany(a => a.PropertyAmenities)
            .HasForeignKey(pa => pa.AmenityId);
    
    }
}