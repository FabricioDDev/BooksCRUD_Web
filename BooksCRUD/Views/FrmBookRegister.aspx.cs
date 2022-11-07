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
	public partial class FrmBookRegister : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			ChargeDdlGroup();
			TxtId.Visible = false;
			if(Request.QueryString["Id"] != null && !IsPostBack)
            {
				ChargeBook(int.Parse(Request.QueryString["Id"]));
				TxtId.Visible = true;
				TxtId.Enabled = true;
			}
		}
		private void ChargeDdlGroup()
		{
			CategoryData categoryD = new CategoryData();
			GenreData genreData = new GenreData();
			PublicData publicData = new PublicData();

			DdlCategory.DataSource = categoryD.Listing();
			DdlCategory.DataTextField = "Name";
			DdlCategory.DataValueField = "Id";
			DdlCategory.DataBind();

			DdlGenre.DataSource = genreData.Listing();
			DdlGenre.DataTextField = "Name";
			DdlGenre.DataValueField = "Id";
			DdlGenre.DataBind();

			DdlPublic.DataSource = publicData.Listing();
			DdlPublic.DataTextField = "Name";
			DdlPublic.DataValueField = "Id";
			DdlPublic.DataBind();
		}
		
		private void ChargeBook(int Id)
        {
			BookData bookData = new BookData();
			Book book = bookData.ListingSP().Find(x => x.Id == Id);
			TxtId.Text = book.Id.ToString();
			TxtTitle.Text = book.Title;
			TxtDescription.Text = book.Description;
			TxtAuthor.Text = book.Author;
			TxtUrl.Text = book.Url;
			TxtCover.Text = book.Cover;
			TxtYear.Text = book.Year.ToString();
			DdlCategory.SelectedValue = book.Category.Id.ToString();
            DdlGenre.SelectedValue = book.Genre.Id.ToString();
			DdlPublic.SelectedValue = book.Public.Id.ToString();
        }

		protected void BtnFinish_Click(object sender, EventArgs e)
		{
			BookData bookData = new BookData();
			Book newBook = new Book();

			if (Request.QueryString["Id"] != null)
				newBook.Id = int.Parse(TxtId.Text);

			newBook.Title = TxtTitle.Text;
			newBook.Description = TxtDescription.Text;
			newBook.Author = TxtAuthor.Text;
			newBook.Url = TxtUrl.Text;
			newBook.Cover = TxtCover.Text;
			newBook.Year = int.Parse(TxtYear.Text);
			newBook.Category = new Category();
			newBook.Category.Id = int.Parse(DdlCategory.SelectedValue);
			newBook.Genre = new Genre();
			newBook.Genre.Id = int.Parse(DdlGenre.SelectedValue);
			newBook.Public = new Public();
			newBook.Public.Id = int.Parse(DdlPublic.SelectedValue);
			

			if (Request.QueryString["Id"] != null)
				bookData.UpdateSP(newBook);
			else
				bookData.InsertSP(newBook);

			Response.Redirect("Default.aspx");
        }
    }
}