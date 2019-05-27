using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Northwind.Models;
using Northwind.Repositories;

namespace Northwind.Desktop
{
    public partial class frmOrders : Form
    {
        NorthwindEntities _db = null;

        public frmOrders()
        {
            _db = new NorthwindEntities();

            InitializeComponent();

            OrdersRepository r = new OrdersRepository(_db);
            orderViewModelDataGridView.DataSource = r.GetViewModels();

        }
    }
}
