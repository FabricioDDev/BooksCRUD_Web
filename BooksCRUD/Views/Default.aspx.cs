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
            if(!IsPostBack)
                GvBookCharge();
        }
        private void GvBookCharge(List<Book>List)
        {
            if(List == null)
            {
                BookData BookD = new BookData();
                GvBook.DataSource = BookD.ListingSP();
                GvBook.DataBind();
                return;
            }
            GvBook.DataSource = List;
            DataBind(); 
        }
        private void GvBookCharge()
        {
            BookData BookD = new BookData();
            GvBook.DataSource = BookD.ListingSP();
            GvBook.DataBind();
        }

        

        protected void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            BookData BookD = new BookData();
            GvBookCharge(BookD.FilterList(TxtSearch.Text));
            if (TxtSearch.Text != "")
                GvBookCharge(BookD.FilterList(TxtSearch.Text));
            else
                GvBookCharge();
        }
    }
}