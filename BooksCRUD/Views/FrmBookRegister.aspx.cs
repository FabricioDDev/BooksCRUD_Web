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
	}
}