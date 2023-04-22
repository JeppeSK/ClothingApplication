namespace ClothingApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clothes",
                c => new
                    {
                        _id = c.Int(nullable: false, identity: true),
                        _color = c.String(),
                        _fabric = c.String(),
                        _price = c.Double(nullable: false),
                        _inventory = c.Int(nullable: false),
                        _hasHood = c.Boolean(),
                        _size = c.String(),
                        _size1 = c.String(),
                        _waistSize = c.Int(),
                        _size2 = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        _brand_brandId = c.Int(),
                    })
                .PrimaryKey(t => t._id)
                .ForeignKey("dbo.Brands", t => t._brand_brandId)
                .Index(t => t._brand_brandId);
            
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        brandId = c.Int(nullable: false, identity: true),
                        _brandName = c.String(),
                        _country = c.String(),
                        _logo = c.String(),
                    })
                .PrimaryKey(t => t.brandId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clothes", "_brand_brandId", "dbo.Brands");
            DropIndex("dbo.Clothes", new[] { "_brand_brandId" });
            DropTable("dbo.Brands");
            DropTable("dbo.Clothes");
        }
    }
}
