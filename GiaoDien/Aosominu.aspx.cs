using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class GiaoDien_Aosominu : System.Web.UI.Page
{
    DataClassesDataContext db = new DataClassesDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var a = from p in db.Products where p.ProductGroup.ProductGroupID == 10 select new { p.ProductID, p.ProductName, p.Price, p.Images };
            //var a = from c in db.Products where c.ProductID.StartsWith("A")&& c.ProductID.Contains("snu")select new {c.ProductID, c.ProductName, c.Price, c.Images, c.Manufacture.ManufactureName, c.ManufactureID, c.ProductGroupID, c.ProductGroup.ProductGroupName,c.Color,c.Date,c.Size,c.Status,c.Number };
            dlAosominu.DataSource = a;
            dlAosominu.DataBind();
        }
    }
    protected void dlAosominu_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void dlAosominu_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "Them")
        {

            ShoppingCart gio = (ShoppingCart)Session["GioHang"];
            Label ma = (Label)e.Item.FindControl("lbMaSP");
            Label ten = (Label)e.Item.FindControl("lbTenSP");
            Label gia = (Label)e.Item.FindControl("lbGia");
            int sl = 1;
            gio.ADD(ma.Text, ten.Text, sl, long.Parse(gia.Text));
            Response.Redirect("GioHang.aspx");
        }
    }
}