using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SignalRChat
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] != null)
            {
                Response.Redirect("Chat.aspx");
            }
        }
        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            Session["UserId"] = Convert.ToBase64String(Guid.NewGuid().ToByteArray()) + DateTime.Now.Ticks;
            Session["UserExist"] = false;
            Session["UserName"] = txtUserName.Value;
            Response.Redirect("Chat.aspx");
        }

    }
}