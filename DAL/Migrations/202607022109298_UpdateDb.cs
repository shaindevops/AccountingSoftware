namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountBooks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        Time = c.String(),
                        Description = c.String(),
                        Price = c.Int(nullable: false),
                        AccountName = c.String(),
                        PersonName = c.String(),
                        CostGroupName = c.String(),
                        Delstatus = c.Boolean(nullable: false),
                        AccountId_id = c.Int(),
                        CostGroupId_id = c.Int(),
                        PeopleId_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Accounts", t => t.AccountId_id)
                .ForeignKey("dbo.CostGroups", t => t.CostGroupId_id)
                .ForeignKey("dbo.People", t => t.PeopleId_id)
                .Index(t => t.AccountId_id)
                .Index(t => t.CostGroupId_id)
                .Index(t => t.PeopleId_id);
            
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        AccountName = c.String(),
                        AccountNumber = c.String(),
                        AccountPerson = c.String(),
                        AccountType = c.Boolean(nullable: false),
                        Regdate = c.String(),
                        Delstatus = c.Boolean(nullable: false),
                        People_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.People", t => t.People_id)
                .Index(t => t.People_id);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Date1 = c.String(),
                        Date2 = c.String(),
                        Number = c.String(),
                        Description = c.String(),
                        Price = c.Int(nullable: false),
                        Ok = c.Boolean(nullable: false),
                        Delstatus = c.Boolean(nullable: false),
                        Accounts_id = c.Int(),
                        CostGroup_id = c.Int(),
                        People_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Accounts", t => t.Accounts_id)
                .ForeignKey("dbo.CostGroups", t => t.CostGroup_id)
                .ForeignKey("dbo.People", t => t.People_id)
                .Index(t => t.Accounts_id)
                .Index(t => t.CostGroup_id)
                .Index(t => t.People_id);
            
            CreateTable(
                "dbo.CostGroups",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Type = c.Boolean(nullable: false),
                        Static = c.Boolean(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        Regdate = c.String(),
                        Delstatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Name = c.String(),
                        Tel = c.String(),
                        Mobile = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        Description = c.String(),
                        Debtor = c.Int(nullable: false),
                        Creditor = c.Int(nullable: false),
                        Regdate = c.String(),
                        Delstatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Factors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FactorType = c.Boolean(nullable: false),
                        FactorNumber = c.String(),
                        FactorDate = c.String(),
                        FactorPrice = c.Int(nullable: false),
                        FactorDefaultTax = c.Double(nullable: false),
                        FactorTaxPrice = c.Int(nullable: false),
                        FactorServicePrice = c.Int(nullable: false),
                        FactorDiscountPrice = c.Int(nullable: false),
                        FactorSumPrice = c.Int(nullable: false),
                        PersonId = c.Int(nullable: false),
                        DelStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
            CreateTable(
                "dbo.Details",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        DetailValue1 = c.Double(nullable: false),
                        DetailValue2 = c.Int(nullable: false),
                        DefaultPrice = c.Int(nullable: false),
                        DetailPrice = c.Int(nullable: false),
                        DetailExit = c.Boolean(nullable: false),
                        FactorId = c.Int(nullable: false),
                        DepotId = c.Int(),
                        ProductId = c.Int(nullable: false),
                        Delstatus = c.Boolean(nullable: false),
                        Factors_id = c.Int(),
                        Depots_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Factors", t => t.Factors_id)
                .ForeignKey("dbo.Depots", t => t.Depots_id)
                .Index(t => t.ProductId)
                .Index(t => t.Factors_id)
                .Index(t => t.Depots_id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Image = c.String(),
                        Code = c.String(),
                        Name = c.String(),
                        Size = c.Double(nullable: false),
                        DefaultPrice = c.Int(nullable: false),
                        Description = c.String(),
                        Alarm = c.Int(nullable: false),
                        Regdate = c.String(),
                        DelStatus = c.Boolean(nullable: false),
                        GroupName = c.String(),
                        Group_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Groups", t => t.Group_id)
                .Index(t => t.Group_id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Unit1 = c.String(),
                        Unit2 = c.String(),
                        Regdate = c.String(),
                        DelStatuse = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        DetailValue1 = c.Double(nullable: false),
                        DetailValue2 = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        Product_id = c.Int(),
                        Orders_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Products", t => t.Product_id)
                .ForeignKey("dbo.Orders", t => t.Orders_id)
                .Index(t => t.Product_id)
                .Index(t => t.Orders_id);
            
            CreateTable(
                "dbo.Stocks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        RegDate = c.String(),
                        Description = c.String(),
                        StockIn = c.Int(nullable: false),
                        StockOut = c.Int(nullable: false),
                        FactorId = c.Int(),
                        DepotId = c.Int(),
                        ProductId = c.Int(nullable: false),
                        DelStatus = c.Boolean(nullable: false),
                        Depots_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Depots", t => t.Depots_id)
                .Index(t => t.ProductId)
                .Index(t => t.Depots_id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        OrderDate = c.String(),
                        OrderNumber = c.String(),
                        OrderDescription = c.String(),
                        StatusType = c.String(),
                        People_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.People", t => t.People_id)
                .Index(t => t.People_id);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        TaskDate = c.DateTime(nullable: false),
                        TaskTime = c.DateTime(nullable: false),
                        TaskAlarmDate = c.DateTime(nullable: false),
                        TaskAlarmTime = c.DateTime(nullable: false),
                        IsDone = c.Boolean(nullable: false),
                        Alarm = c.Boolean(nullable: false),
                        TaskGroup_id = c.Int(),
                        Users_id = c.Int(),
                        People_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.TaskGroups", t => t.TaskGroup_id)
                .ForeignKey("dbo.Users", t => t.Users_id)
                .ForeignKey("dbo.People", t => t.People_id)
                .Index(t => t.TaskGroup_id)
                .Index(t => t.Users_id)
                .Index(t => t.People_id);
            
            CreateTable(
                "dbo.TaskGroups",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Fullname = c.String(),
                        PhoneNo = c.String(),
                        NationalID = c.String(),
                        Email = c.String(),
                        Username = c.String(),
                        password = c.String(),
                        pic = c.String(),
                        Regdate = c.DateTime(nullable: false),
                        DelStatus = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Usergroup_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Usergroups", t => t.Usergroup_id)
                .Index(t => t.Usergroup_id);
            
            CreateTable(
                "dbo.Usergroups",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Userroles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        section = c.String(),
                        canenter = c.Boolean(nullable: false),
                        cancreate = c.Boolean(nullable: false),
                        canedit = c.Boolean(nullable: false),
                        candelete = c.Boolean(nullable: false),
                        Usergroup_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Usergroups", t => t.Usergroup_id)
                .Index(t => t.Usergroup_id);
            
            CreateTable(
                "dbo.UserLogs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        LogIn = c.String(),
                        LogOut = c.String(),
                        Username = c.String(),
                        Delstatus = c.Boolean(nullable: false),
                        User_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.User_id)
                .Index(t => t.User_id);
            
            CreateTable(
                "dbo.Depots",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Regdate = c.String(),
                        DelStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.EmailPanels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        EmailSender = c.String(),
                        Password = c.String(),
                        Regdate = c.String(),
                        Delstatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        MessageText = c.String(),
                        Delstatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.PosDevices",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        DeviceName = c.String(),
                        DeviceType = c.String(),
                        PortName = c.String(),
                        BaudRate = c.Int(nullable: false),
                        IsDefault = c.Boolean(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.SendEmails",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        From = c.String(),
                        Password = c.String(),
                        DisplayName = c.String(),
                        To = c.String(),
                        Subject = c.String(),
                        Body = c.String(),
                        File = c.String(),
                        Regdate = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.SendSMS",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        PanelName = c.String(),
                        SID = c.String(),
                        AuthKey = c.String(),
                        SenderNumber = c.String(),
                        Tonumber = c.String(),
                        SmsBody = c.String(),
                        Status = c.String(),
                        SendDate = c.String(),
                        SmsId = c.String(),
                        SmsPanel_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.SmsPanels", t => t.SmsPanel_id)
                .Index(t => t.SmsPanel_id);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        factoraddress = c.String(),
                        factortel = c.String(),
                        depotaddress = c.String(),
                        depottel = c.String(),
                        SMSpaneluser = c.String(),
                        SMSpanelpassword = c.String(),
                        Smssendernumber = c.String(),
                        alarm1 = c.Int(nullable: false),
                        alarm2 = c.Int(nullable: false),
                        Banksend = c.Boolean(nullable: false),
                        Factorsend = c.Boolean(nullable: false),
                        regdate = c.DateTime(nullable: false),
                        comname = c.String(),
                        company_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Tbl_Company", t => t.company_id)
                .Index(t => t.company_id);
            
            CreateTable(
                "dbo.Tbl_Company",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        code = c.String(),
                        Comname = c.String(),
                        Comowner = c.String(),
                        Comcurrency = c.String(),
                        Comeconimiccode = c.String(),
                        Comregnumber = c.String(),
                        Comphone = c.String(),
                        Comemail = c.String(),
                        Comzipcode = c.String(),
                        Comprovince = c.String(),
                        Comcity = c.String(),
                        Comaddress = c.String(),
                        Comlogo = c.String(),
                        Comsysregdate = c.DateTime(nullable: false),
                        Comsysregtime = c.DateTime(nullable: false),
                        Comstatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.SmsPanels",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        PanelName = c.String(),
                        PanelSID = c.String(),
                        PanelAuthKey = c.String(),
                        PanelNumber = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Taxes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        TaxBuy = c.Double(nullable: false),
                        TaxSale = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SendSMS", "SmsPanel_id", "dbo.SmsPanels");
            DropForeignKey("dbo.Settings", "company_id", "dbo.Tbl_Company");
            DropForeignKey("dbo.Stocks", "Depots_id", "dbo.Depots");
            DropForeignKey("dbo.Details", "Depots_id", "dbo.Depots");
            DropForeignKey("dbo.Tasks", "People_id", "dbo.People");
            DropForeignKey("dbo.Tasks", "Users_id", "dbo.Users");
            DropForeignKey("dbo.UserLogs", "User_id", "dbo.Users");
            DropForeignKey("dbo.Users", "Usergroup_id", "dbo.Usergroups");
            DropForeignKey("dbo.Userroles", "Usergroup_id", "dbo.Usergroups");
            DropForeignKey("dbo.Tasks", "TaskGroup_id", "dbo.TaskGroups");
            DropForeignKey("dbo.Orders", "People_id", "dbo.People");
            DropForeignKey("dbo.OrderDetails", "Orders_id", "dbo.Orders");
            DropForeignKey("dbo.Factors", "PersonId", "dbo.People");
            DropForeignKey("dbo.Details", "Factors_id", "dbo.Factors");
            DropForeignKey("dbo.Stocks", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderDetails", "Product_id", "dbo.Products");
            DropForeignKey("dbo.Products", "Group_id", "dbo.Groups");
            DropForeignKey("dbo.Details", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Documents", "People_id", "dbo.People");
            DropForeignKey("dbo.Accounts", "People_id", "dbo.People");
            DropForeignKey("dbo.AccountBooks", "PeopleId_id", "dbo.People");
            DropForeignKey("dbo.Documents", "CostGroup_id", "dbo.CostGroups");
            DropForeignKey("dbo.AccountBooks", "CostGroupId_id", "dbo.CostGroups");
            DropForeignKey("dbo.Documents", "Accounts_id", "dbo.Accounts");
            DropForeignKey("dbo.AccountBooks", "AccountId_id", "dbo.Accounts");
            DropIndex("dbo.Settings", new[] { "company_id" });
            DropIndex("dbo.SendSMS", new[] { "SmsPanel_id" });
            DropIndex("dbo.UserLogs", new[] { "User_id" });
            DropIndex("dbo.Userroles", new[] { "Usergroup_id" });
            DropIndex("dbo.Users", new[] { "Usergroup_id" });
            DropIndex("dbo.Tasks", new[] { "People_id" });
            DropIndex("dbo.Tasks", new[] { "Users_id" });
            DropIndex("dbo.Tasks", new[] { "TaskGroup_id" });
            DropIndex("dbo.Orders", new[] { "People_id" });
            DropIndex("dbo.Stocks", new[] { "Depots_id" });
            DropIndex("dbo.Stocks", new[] { "ProductId" });
            DropIndex("dbo.OrderDetails", new[] { "Orders_id" });
            DropIndex("dbo.OrderDetails", new[] { "Product_id" });
            DropIndex("dbo.Products", new[] { "Group_id" });
            DropIndex("dbo.Details", new[] { "Depots_id" });
            DropIndex("dbo.Details", new[] { "Factors_id" });
            DropIndex("dbo.Details", new[] { "ProductId" });
            DropIndex("dbo.Factors", new[] { "PersonId" });
            DropIndex("dbo.Documents", new[] { "People_id" });
            DropIndex("dbo.Documents", new[] { "CostGroup_id" });
            DropIndex("dbo.Documents", new[] { "Accounts_id" });
            DropIndex("dbo.Accounts", new[] { "People_id" });
            DropIndex("dbo.AccountBooks", new[] { "PeopleId_id" });
            DropIndex("dbo.AccountBooks", new[] { "CostGroupId_id" });
            DropIndex("dbo.AccountBooks", new[] { "AccountId_id" });
            DropTable("dbo.Taxes");
            DropTable("dbo.SmsPanels");
            DropTable("dbo.Tbl_Company");
            DropTable("dbo.Settings");
            DropTable("dbo.SendSMS");
            DropTable("dbo.SendEmails");
            DropTable("dbo.PosDevices");
            DropTable("dbo.Messages");
            DropTable("dbo.EmailPanels");
            DropTable("dbo.Depots");
            DropTable("dbo.UserLogs");
            DropTable("dbo.Userroles");
            DropTable("dbo.Usergroups");
            DropTable("dbo.Users");
            DropTable("dbo.TaskGroups");
            DropTable("dbo.Tasks");
            DropTable("dbo.Orders");
            DropTable("dbo.Stocks");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.Groups");
            DropTable("dbo.Products");
            DropTable("dbo.Details");
            DropTable("dbo.Factors");
            DropTable("dbo.People");
            DropTable("dbo.CostGroups");
            DropTable("dbo.Documents");
            DropTable("dbo.Accounts");
            DropTable("dbo.AccountBooks");
        }
    }
}
