using Microsoft.AspNetCore.Mvc;

namespace StockWeb.Business.ToastMessage
{
    public class ToastMessageSender
    {
        public static void ShowMessage(Controller controller, string type, string data)
        {
            string title = null;
            if (type == "success")
            {
                title = "İşlem Başarılı";
            }

            if (type == "warning")
            {
                title = "Uyarı";
            }

            if (type == "danger")
            {
                title = "Hata Oluştu";
            }

            if (type == "info")
            {
                title = "Bilgilendirme";
            }

            controller.TempData["message-title"] = title;
            controller.TempData["message-data"] = data;
            controller.TempData["message-type"] = type;
        }
    }
}
