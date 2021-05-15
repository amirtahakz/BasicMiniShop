namespace myshop.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<myshop.Models.db>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "myshop.Models.db";
        }

        protected override void Seed(myshop.Models.db context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
