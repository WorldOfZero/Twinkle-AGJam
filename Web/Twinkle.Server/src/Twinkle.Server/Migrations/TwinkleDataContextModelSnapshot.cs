using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Twinkle.Server.Models;

namespace Twinkle.Server.Migrations
{
    [DbContext(typeof(TwinkleDataContext))]
    partial class TwinkleDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Twinkle.Server.Models.WorldModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DataBlob");

                    b.Property<string>("WorldId")
                        .IsRequired();

                    b.HasKey("Id");
                });
        }
    }
}
