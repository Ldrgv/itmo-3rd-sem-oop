using FluentMigrator;

namespace DataAccess.Migrations;

[Migration(1702583087)]
public class Initial : Migration
{
    public override void Up()
    {
        Create.Table("accounts")
            .WithColumn("id").AsInt32().PrimaryKey()
            .WithColumn("pin").AsString().NotNullable()
            .WithColumn("balance").AsInt32().WithDefaultValue(0);

        Create.Table("operations")
            .WithColumn("time").AsDateTime().PrimaryKey()
            .WithColumn("account_id").AsInt32().NotNullable()
            .WithColumn("operation_type").AsString().NotNullable()
            .WithColumn("amount").AsInt32().NotNullable();
    }

    public override void Down()
    {
        Delete.Table("accounts");
        Delete.Table("operations");
    }
}