using BusinessLogicLayer;
using CommunicationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace etEcom
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void generatePassword(string userId)
        {
            MemberBLL memberBLL = new MemberBLL();
            MemberCL memberCL = memberBLL.getMember().Where(e=>e.email ==userId).FirstOrDefault();
            if (memberCL != null)
            {
                
                string password = memberCL.name.Substring(0, 3);
                Random rand = new Random();
                int randomNo = rand.Next(7777);
                password = password + randomNo;

                MemberCL memberUpdated = memberBLL.updateMember(new MemberCL()
                   {
                       addressId = memberCL.addressId,
                       password = password,
                       name=memberCL.name,
                       gender=memberCL.gender,
                       mobNo=memberCL.mobNo,
                       isGuest=memberCL.isGuest,
                      isDeleted=memberCL.isDeleted
                   });

                //Email the content of new password 
                //SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);

                //smtpClient.Credentials = new System.Net.NetworkCredential("anandbookcorner@gmail.com", "defaultpassword");
                //smtpClient.UseDefaultCredentials = true;
                //smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtpClient.EnableSsl = true;
                //MailMessage mail = new MailMessage();

                ////Setting From , To and CC
                //mail.From = new MailAddress("info@MyWebsiteDomainName", "MyWeb Site");
                //mail.To.Add(new MailAddress(memberCL.email));
                //mail.Body = "Your new password for www.MyWebsiteDomainName.com is" + password;

                //smtpClient.Send(mail);
                //memberUpdated.password;
            }
            else
            {
                lblAlert.Text = ("This Email Id does not exist!!");
            }
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            MemberBLL memberBLL = new MemberBLL();
            MemberCL memberCL = new MemberCL();
            bool chkEmailId=memberBLL.chkUserName((txtUserName.Text.ToLower()));
            
            if (chkEmailId)
            {
                generatePassword(memberBLL.getMemberByUserName(txtUserName.Text.ToLower()).id.ToString());
            }
            else 
            {
                lblAlert.Text = ("This email id does not exist !!");
            }

        }
    }
}