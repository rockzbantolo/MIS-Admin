using MIS_Admin.Core;
using Next.Clients.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS_Admin.Repository
{
    internal class InventoryRepository
    {
        private readonly MySqlDb Db;
        public InventoryRepository() {
            Db = Database.Instance;
        }

    }
}
