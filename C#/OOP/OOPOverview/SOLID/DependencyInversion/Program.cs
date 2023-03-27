// Dependency -> Bağımlılık
// Dependency: Bir nesnenin varlığının başka nesneye bağlı olması durumu
// Matkap; ucu olmadan çalışmaz.

// Inversion: Büyük sistem; bağımlısı olduğu nesneyi oluşturmamalı. Dışarıdan almalıdır.

using DependencyInversion;

Reporter reporter = new(new MailSender());
reporter.SendReport();

Reporter reporter2 = new(new WhatsappSender());
reporter2.SendReport();

Reporter reporter3 = new(new TelegramSender());
reporter3.SendReport();
