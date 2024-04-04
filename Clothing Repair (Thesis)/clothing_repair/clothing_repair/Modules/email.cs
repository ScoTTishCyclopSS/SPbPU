using System.Linq;
using System.Windows;
using MailKit.Net.Smtp;
using MimeKit;

namespace clothing_repair
{
    internal class email
    {
        public static void send_email(clothing_repairEntities1 db, order o, string org_name, string email_from,
            string mail_login, string mail_pass)
        {
            var done = db.order.FirstOrDefault(x => x.id == o.id);
            if (done != null)
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress(org_name, email_from)); //fed.timushev@gmail.com
                message.To.Add(new MailboxAddress(done.customer.mail));
                message.Subject = "Заказ из ателье!";
                var builder = new BodyBuilder();
                builder.TextBody = "Ваш заказ №" + done.id + " готов к выдаче.\n----------------------------\n" +
                                   "С уважением, ателье Строчкин.";
                message.Body = builder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    try
                    {
                        client.ServerCertificateValidationCallback = (s, c, h, a) => true;
                        client.Connect("smtp.mail.ru", 587, false); //smtp.gmail.com
                        client.Authenticate(mail_login, mail_pass); //"fed.timushev@gmail.com", "F8e7d6y5A4"
                        client.Send(message);
                        client.Disconnect(true);
                    }
                    catch
                    {
                        MessageBox.Show(
                            "Ошибка отправки оповещения!\nЭто может быть связано с вашими настройками сети или отсутсвием ответа от сервера электронной почты.\nРекомендуем связаться с клиентом по телефону!");
                    }
                }
            }
        }
    }
}