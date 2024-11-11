using FluentMigrator;

namespace NotesApplication.Migrations;

[Migration(1)]
public class InitialMigration : Migration
{
    public override void Up()
    {
        Create.Table("Users")
            .WithColumn("Id").AsGuid().PrimaryKey()
            .WithColumn("Name").AsString(100).NotNullable()
            .WithColumn("Email").AsString(255).NotNullable().Unique();

        Create.Table("Notes")
            .WithColumn("Id").AsGuid().PrimaryKey()
            .WithColumn("Title").AsString(100).NotNullable()
            .WithColumn("Content").AsString(int.MaxValue).NotNullable()
            .WithColumn("CreatedAt").AsDateTime().WithDefault(SystemMethods.CurrentUTCDateTime)
            .WithColumn("ModifiedAt").AsDateTime().Nullable()
            .WithColumn("UserId").AsGuid().NotNullable();
    }

    public override void Down()
    {
        
    }
}