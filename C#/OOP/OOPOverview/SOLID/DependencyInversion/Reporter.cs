using System.Threading.Channels;

namespace DependencyInversion;
public class Reporter {
    //private readonly MailSender mailSender;

    //public Reporter(MailSender mailSender) {
    //    this.mailSender = mailSender;
    //}

    //public MailSender MailSender { get; set; } // Bu şekilde de alınabilir

    // Sadece bu metotda kullanacaksa parametre olarak MailSender gönderilebilir.
    //public void SendReport() {
    //    this.mailSender.Send();
    //}

    private readonly ISender sender;

    public Reporter(ISender sender) {
        this.sender = sender;
    }

    public void SendReport() {
        this.sender.Send();
    }
}

public interface ISender {
    public void Send();
}

public class MailSender : ISender {
    public void Send() {
        Console.WriteLine("Mail ile gönderildi");
    }
}

public class WhatsappSender : ISender {
    public void Send() {
        Console.WriteLine("Whatsapp ile gönderildi");
    }
}

public class TelegramSender : ISender {
    public void Send() {
        Console.WriteLine("Telegram ile gönderildi");
    }
}