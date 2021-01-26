namespace CoronaTest.Core.Contracts
{
    public interface ISmsService
    {
        /// <summary>
        /// sendet eine sms
        /// </summary>
        /// <param name="to">Handynummer des Empfängers</param>
        /// <param name="message">Nachricht</param>
        /// <returns>oB erfolgreich versendet wurde</returns>
        bool SendSms(string to, string message);
    }
}
