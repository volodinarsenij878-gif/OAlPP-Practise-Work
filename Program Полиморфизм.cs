using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Program12
{
    namespace NotificationGatewayDemo
    {
        // =========================================================
        // 1. Абстрактный базовый класс NotificationChannel
        // =========================================================
        public abstract class NotificationChannel
        {
            protected string ChannelName;
            public int DeliveredCount { get; protected set; }

            public abstract bool IsOnline { get; }

            public NotificationChannel(string name)
            {
                ChannelName = name;
                DeliveredCount = 0;
            }

            public abstract bool Deliver(string recipient, string message);

            public virtual string FormatPayload(string rawMessage)
            {
                return $"[{ChannelName}] {rawMessage}";
            }

            public void PrintAudit()
            {
                string status = IsOnline ? "онлайн" : "офлайн";
                Console.WriteLine($"Канал: {ChannelName} | Статус: {status} | Доставлено: {DeliveredCount}");
            }
        }

        // =========================================================
        // 2. EmailChannel: override FormatPayload, валидация адреса
        // =========================================================
        public class EmailChannel : NotificationChannel
        {
            private bool _isSmtpAvailable;

            public override bool IsOnline => _isSmtpAvailable;

            public EmailChannel(string name, bool smtpAvailable = true)
                : base(name)
            {
                _isSmtpAvailable = smtpAvailable;
            }

            public override string FormatPayload(string rawMessage)
            {
                string baseFormatted = base.FormatPayload(rawMessage);
                return baseFormatted + "\n---\nС уважением, Почтовый Сервис";
            }

            public override bool Deliver(string recipient, string message)
            {
                if (!_isSmtpAvailable)
                {
                    Console.WriteLine($"[Email] Канал офлайн. Отправка на {recipient} невозможна.");
                    return false;
                }

                if (string.IsNullOrWhiteSpace(recipient) || !recipient.Contains("@"))
                {
                    Console.WriteLine($"[Email] Недопустимый адрес получателя: {recipient}");
                    return false;
                }

                DeliveredCount++;
                string payload = FormatPayload(message);
                Console.WriteLine($"[Email] Отправлено на {recipient}:\n{payload}\n");
                return true;
            }
        }

        // =========================================================
        // 3. TelegramChannel: override Deliver, проверка длины и префикса
        // =========================================================
        public class TelegramChannel : NotificationChannel
        {
            public override bool IsOnline => true;

            public TelegramChannel(string name, string botToken)
                : base(name)
            {
                // Токен хранится, но в рамках задания не используется для реальной отправки
            }

            public override bool Deliver(string recipient, string message)
            {
                if (string.IsNullOrWhiteSpace(recipient))
                {
                    Console.WriteLine("[Telegram] Пустой получатель.");
                    return false;
                }

                if (!recipient.StartsWith("@"))
                {
                    Console.WriteLine($"[Telegram] Получатель должен начинаться с '@': {recipient}");
                    return false;
                }

                if (message.Length > 100)
                {
                    Console.WriteLine($"[Telegram] Сообщение слишком длинное: {message.Length} символов (макс. 100).");
                    return false;
                }

                DeliveredCount++;
                string payload = FormatPayload(message);
                Console.WriteLine($"[Telegram] Отправлено пользователю {recipient}:\n{payload}\n");
                return true;
            }
        }
        // =========================================================
        // 4. SirenAlarmChannel: new FormatPayload (сокрытие), игнорирование получателя
        // =========================================================
        public class SirenAlarmChannel : NotificationChannel
        {
            private int _relayLevel;
            private const int CriticalThreshold = 50;

            public override bool IsOnline => _relayLevel > CriticalThreshold;

            public SirenAlarmChannel(int relayLevel = 75)
                : base("Звуковая Сирена")
            {
                _relayLevel = relayLevel;
            }

            // Сокрытие (new) — поведение меняется только при ссылке типа SirenAlarmChannel
            public new string FormatPayload(string rawMessage)
            {
                return "[ТРЕВОГА МЧС]: " + rawMessage.ToUpper();
            }
            public override bool Deliver(string recipient, string message)
            {
                if (!IsOnline)
                {
                    Console.WriteLine("[Сирена] Канал офлайн: реле ниже критического порога.");
                    return false;
                }

                // Имитация звукового сигнала
                Console.Beep(800, 300);
                Console.Write("[Сирена]  ТРЕВОГА! ");

                DeliveredCount++;

                // Здесь сработает версия с new, если ссылка типа SirenAlarmChannel.
                // Но в полиморфном массиве у нас ссылка NotificationChannel, поэтому
                // при вызове через неё будет работать базовый FormatPayload.
                string payload = this.FormatPayload(message);
                Console.WriteLine(payload + "\n");
                return true;
            }
        }
        class Program
        {
            static void Main()
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.WriteLine("=== МУЛЬТИКАНАЛЬНЫЙ ШЛЮЗ УВЕДОМЛЕНИЙ И ТРЕВОГ ===\n");

                NotificationChannel[] channels = new NotificationChannel[3];

                channels[0] = new EmailChannel("SMTP-Основной", smtpAvailable: true);
                channels[1] = new TelegramChannel("TG-Бот-Оповещения", botToken: "secret-token-123");
                channels[2] = new SirenAlarmChannel(relayLevel: 75);

                string commonMessage = "Внимание: регламентные технические работы в серверной!";

                // --- Полиморфная отправка через массив ---
                Console.WriteLine("--- Отправка уведомлений через полиморфный массив ---\n");
                foreach (var channel in channels)
                {
                    string recipient = GetRecipientForChannel(channel);
                    channel.Deliver(recipient, commonMessage);
                }

                // --- Демонстрация override vs new на примере FormatPayload ---
                Console.WriteLine("--- Сравнение override и new (FormatPayload) ---\n");

                var sirenBaseRef = channels[2];                          // Ссылка типа NotificationChannel
                var sirenDirectRef = (SirenAlarmChannel)channels[2];      // Ссылка типа SirenAlarmChannel

                string testRaw = "Произошло критическое событие";

                // Через базовую ссылку — сработает виртуальный метод (базовая логика)
                string viaBase = sirenBaseRef.FormatPayload(testRaw);
                Console.WriteLine("Через ссылку базового типа:");
                Console.WriteLine(viaBase);
                Console.WriteLine();

                // Через прямую ссылку — сработает сокрытие (new)
                string viaDirect = sirenDirectRef.FormatPayload(testRaw);
                Console.WriteLine("Через прямую ссылку типа SirenAlarmChannel:");
                Console.WriteLine(viaDirect);
                Console.WriteLine();

                // --- Полиморфный аудит ---
                Console.WriteLine("--- Аудит каналов (PrintAudit) ---\n");
                foreach (var channel in channels)
                {
                    channel.PrintAudit();
                }
            }

            static string GetRecipientForChannel(NotificationChannel channel)
            {
                if (channel is EmailChannel) return "admin@example.com";
                if (channel is TelegramChannel) return "@tech_support_bot";
                return "ALL"; // Для сирены получатель не важен
            }
        }
    }
}