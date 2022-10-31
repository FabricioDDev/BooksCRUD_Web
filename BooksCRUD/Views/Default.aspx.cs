using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DomainModel;
using DataModel;

namespace BooksCRUD.Views
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            GvBookCharge();
        }
        private void GvBookCharge()
        {
            BookData BookD = new BookData();
            GvBook.DataSource = BookD.ListingSP();
            GvBook.DataBind();
        }
    }
}