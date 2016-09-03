using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Twinkle.Server.Models;

namespace Twinkle.Server.Migrations
{
    [DbContext(typeof(TwinkleDataContext))]
    [Migration("20160903015525_InitialDatabaseMigration")]
    partial class InitialDatabaseMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Twinkle.Server.Models.WorldModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DataBlob");

                    b.HasKey("Id");
                });
        }
    }
}
