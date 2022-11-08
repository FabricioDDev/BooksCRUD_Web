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
            CampFilterCharge();
        }
        private void CampFilterCharge()
        {
            DdlCampo.Items.Add("Category");
            DdlCampo.Items.Add("Genre");
            DdlCampo.Items.Add("Public");
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

        protected void CbxAdvancedFilter_CheckedChanged(object sender, EventArgs e)
        {
            if (CbxAdvancedFilter.Checked)
            {
                LblCriterion.Visible = true;
                DdlCriterion.Visible = true;
                LblCamp.Visible = true;
                DdlCampo.Visible = true;
                btnApply.Visible = true;
                BtnDeleteFilter.Visible = true;
                TxtSearch.Enabled = true;
            }
            else
            {
                TxtSearch.Enabled = false;
                LblCriterion.Visible = false;
                DdlCriterion.Visible = false;
                LblCamp.Visible = false;
                DdlCampo.Visible = false;
                btnApply.Visible = false;
                BtnDeleteFilter.Visible = false;
            }
        }

        protected void DdlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DdlCampo.SelectedItem.ToString() == "Category")
            {
                
                DdlCriterion.Items.Clear();
                CategoryData CategoryD = new CategoryData();
                DdlCriterion.DataSource = CategoryD.Listing();
                DdlCriterion.DataBind();
            }
            else if (DdlCampo.SelectedItem.ToString() == "Genre")
            {
                DdlCriterion.Items.Clear();
                GenreData GenreD = new GenreData();
                DdlCriterion.DataSource = GenreD.Listing();
                DdlCriterion.DataBind();
            }
            else if (DdlCampo.SelectedItem.ToString() == "Public")
            {
                DdlCriterion.Items.Clear();
                PublicData PublicD = new PublicData();
                DdlCriterion.DataSource = PublicD.Listing();
                DdlCriterion.DataBind();
            }
            
        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            string Camp = DdlCampo.SelectedItem.ToString();
            string Criterion = DdlCriterion.SelectedItem.Value.ToString();
            BookData BookD = new BookData();
            GvBookCharge(BookD.FilterList(Camp, Criterion));
        }

        protected void BtnDeleteFilter_Click(object sender, EventArgs e)
        {
            GvBookCharge();
        }

      

        protected void GvBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            var Id = GvBook.SelectedDataKey.Value.ToString();
            Response.Redirect("FrmBookRegister.aspx?Id=" + Id);
        }
    }
}