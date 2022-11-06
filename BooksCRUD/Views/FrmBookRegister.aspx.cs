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
			
			ChargeBook(7);
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


    }
}