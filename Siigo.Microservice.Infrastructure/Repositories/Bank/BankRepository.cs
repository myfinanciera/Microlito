using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Siigo.Microservice.Domain.Aggregates.Bank.Interfaces;
using Siigo.Microservice.Domain.Aggregates.ServiceEmail;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Siigo.Microservice.Infrastructure.Repositories.Bank;

public sealed class BankRepository : IBankRepository<Domain.Aggregates.Bank.Entities.Bank>
{
    
    private readonly ILogger<BankRepository> _logger;
    private readonly IConfiguration _configuration;

    public BankRepository(ILogger<BankRepository> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public async Task CreateAsync(Domain.Aggregates.Bank.Entities.Bank bank)
    {
        await SendOrderEmailToCustomer(bank);
    }


    public Task<bool> SendOrderEmailToCustomer(Domain.Aggregates.Bank.Entities.Bank orderData)
    {
        bool result = false;
        try
        {
            if (string.IsNullOrEmpty(orderData.Order.email) && string.IsNullOrEmpty(orderData.Order.idcustomer))
            {
                throw new System.Exception(_configuration["AppParams:CustomerWithoutEmailError"]);
            }
            else
            {
                string body = GetDataBody(orderData);
                MailSenderRequest request = new()
                {
                    Body = body,
                    From = new UserMail
                    {
                        Name = _configuration["AppParams:SenderName"],
                        Email = _configuration["AppParams:FromEmail"],
                    },
                    Subject = _configuration["AppParams:SubjectEmail"],
                    To = new List<UserMail>()
                        {
                            new UserMail
                            {
                                Email = orderData.Order.email,
                                Name = orderData.Order.idcustomer
                            }
                        }
                };
                SendEmail(request);
            }
            result = true;
        }
        catch (Exception ex)
        {
            _logger.LogDebug("Error en envío de correo: " + ex.Message);
        }

        return Task.FromResult(result);
    }

    private async void SendEmail(MailSenderRequest request)
    {
        try
        {
            using HttpClientHandler handler = new();
            using HttpClient client = new(handler);
            client.DefaultRequestHeaders.Accept.Clear();

            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(request));

            HttpResponseMessage response = await client.PostAsync(_configuration["AppParams:MailSenderApiUrl"], httpContent);

            string resultInResponse = response.Content.ReadAsStringAsync().Result;

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    MailSenderResponse result = JsonConvert.DeserializeObject<MailSenderResponse>(resultInResponse);

                }
                catch (System.Exception ex)
                {
                    throw new System.Exception($"Error deserializando respuesta de {_configuration["AppParams:MailSenderApiUrl"]}: {ex.Message}");
                }
            }

        }
        catch (Exception ex)
        {
            throw new System.Exception($"Error en requet hacia API MailProvider: {ex.Message}");
        }

    }

    private string GetDataBody(Domain.Aggregates.Bank.Entities.Bank orderData)
    {
        string state = orderData.Order.state == true ? "Activo" : "Inactivo";
        string result = "<!doctype html> <html> <head> <meta name=\"viewport\" content=\"width = device - width, initial - scale = 1.0\"> <meta http-equiv=\"Content - Type\" content=\"text / html; charset = UTF - 8\"> <title>Simple Transactional Email</title> <style> @media only screen and (max-width: 620px) { table.body h1 { font-size: 28px !important; margin-bottom: 10px !important; } table.body p, table.body ul, table.body ol, table.body td, table.body span, table.body a { font-size: 16px !important; } table.body .wrapper, table.body .article { padding: 10px !important; } table.body .content { padding: 0 !important; } table.body .container { padding: 0 !important; width: 100% !important; } table.body .main { border-left-width: 0 !important; border-radius: 0 !important; border-right-width: 0 !important; } table.body .btn table { width: 100% !important; } table.body .btn a { width: 100% !important; } table.body .img-responsive { height: auto !important; max-width: 100% !important; width: auto !important; } } @media all { .ExternalClass { width: 100%; } .ExternalClass, .ExternalClass p, .ExternalClass span, .ExternalClass font, .ExternalClass td, .ExternalClass div { line-height: 100%; } .apple-link a { color: inherit !important; font-family: inherit !important; font-size: inherit !important; font-weight: inherit !important; line-height: inherit !important; text-decoration: none !important; } #MessageViewBody a { color: inherit; text-decoration: none; font-size: inherit; font-family: inherit; font-weight: inherit; line-height: inherit; } .btn-primary table td:hover { background-color: #34495e !important; } .btn-primary a:hover { background-color: #34495e !important; border-color: #34495e !important; } } </style> </head> <body style=\"background - color: #f6f6f6; font-family: sans-serif; -webkit-font-smoothing: antialiased; font-size: 14px; line-height: 1.4; margin: 0; padding: 0; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;\"> <span class=\"preheader\" style=\"color: transparent; display: none; height: 0; max-height: 0; max-width: 0; opacity: 0; overflow: hidden; mso-hide: all; visibility: hidden; width: 0;\">This is preheader text. Some clients will show this text as a preview.</span> <table role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"body\" style=\"border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; background-color: #f6f6f6; width: 100%;\" width=\"100%\" bgcolor=\"#f6f6f6\"> <tr> <td style=\"font-family: sans-serif; font-size: 14px; vertical-align: top;\" valign=\"top\">&nbsp;</td> <td class=\"container\" style=\"font-family: sans-serif; font-size: 14px; vertical-align: top; display: block; max-width: 580px; padding: 10px; width: 580px; margin: 0 auto;\" width=\"580\" valign=\"top\"> <div class=\"content\" style=\"box-sizing: border-box; display: block; margin: 0 auto; max-width: 580px; padding: 10px;\"> <table role=\"presentation\" class=\"main\" style=\"border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; background: #ffffff; border-radius: 3px; width: 100%;\" width=\"100%\"> <tr> <td class=\"wrapper\" style=\"font-family: sans-serif; font-size: 14px; vertical-align: top; box-sizing: border-box; padding: 20px;\" valign=\"top\"> <table role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%;\" width=\"100%\"> <tr> <td style=\"font-family: sans-serif; font-size: 14px; vertical-align: top;\" valign=\"top\"> <p style=\"font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; margin-bottom: 15px;\"><b>Hola como estas</p> <p style=\"font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; margin-bottom: 15px;\"><b>Los datos de tu pedido son:</p> <p style=\"font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; margin-bottom: 15px;\">Orden: [[orderData.Order.number]]</p> <p style=\"font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; margin-bottom: 15px;\">Estado de la Orden: [[state]]</p> </td> </tr> <table border:\"1\"> <tr> <th style=\"background-color: #80ced6\">Productos comprados</th> </tr>";
        
        foreach (string product in orderData.Order.product)
        {
            result = result + "<tr><td>" + product + "</td></tr>";
        }
        result = result + "</table> <br> <table role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" class=\"btn btn-primary\" style=\"border - collapse: separate; mso - table - lspace: 0pt; mso - table - rspace: 0pt; box - sizing: border - box; width: 100 %; \" width=\"100 % \"> <tbody> <tr> <td align=\"left\" style=\"font - family: sans - serif; font - size: 14px; vertical - align: top; padding - bottom: 15px; \" valign=\"top\"> <table role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"border - collapse: separate; mso - table - lspace: 0pt; mso - table - rspace: 0pt; width: auto; \"> <tbody> <tr> <td style=\"font - family: sans - serif; font - size: 14px; vertical - align: top; border - radius: 5px; text - align: center; background - color: #3498db;\" valign=\"top\" align=\"center\" bgcolor=\"#3498db\"> <a href=\"https://www.siigo.com/\" target=\"_blank\" style=\"border: solid 1px #3498db; border-radius: 5px; box-sizing: border-box; cursor: pointer; display: inline-block; font-size: 14px; font-weight: bold; margin: 0; padding: 12px 25px; text-decoration: none; text-transform: capitalize; background-color: #3498db; border-color: #3498db; color: #ffffff;\">Ingresar a SIIGO</a> </td> </tr> </tbody> </table> </td> </tr> </tbody> </table> </table> </td> </tr> </table> <!-- START FOOTER --> <div class=\"footer\" style=\"clear: both; margin-top: 10px; text-align: center; width: 100%;\"> <table role=\"presentation\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%;\" width=\"100%\"> <tr> <td class=\"content-block\" style=\"font-family: sans-serif; vertical-align: top; padding-bottom: 10px; padding-top: 10px; color: #999999; font-size: 12px; text-align: center;\" valign=\"top\" align=\"center\"> <span class=\"apple-link\" style=\"color: #999999; font-size: 12px; text-align: center;\">Correo enviado desde mini CRM por Wilmar Martinez</span> <br> Todos los derechos reservados </td> </tr> <tr> <td class=\"content-block powered-by\" style=\"font-family: sans-serif; vertical-align: top; padding-bottom: 10px; padding-top: 10px; color: #999999; font-size: 12px; text-align: center;\" valign=\"top\" align=\"center\"> Mini CRM Pedidos </td> </tr> </table> </div> <!-- END FOOTER --> </div> </td> <td style=\"font-family: sans-serif; font-size: 14px; vertical-align: top;\" valign=\"top\">&nbsp;</td> </tr> </table> </body> </html>";

        result = result.Replace("[[orderData.Order.number]]", orderData.Order.number.ToString());
        result = result.Replace("[[state]]", state);
        return result;
    }


    public Task UpdateAsync(Domain.Aggregates.Bank.Entities.Bank bank)
    {
        throw new System.NotImplementedException();
    }
}