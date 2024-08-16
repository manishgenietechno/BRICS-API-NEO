using AutoMapper;
using BRICS_API_NEO.Services.Interface;
using System.Security.Cryptography;
using DataService.DBModels;
using BRICS_API_NEO.Models;
using Newtonsoft.Json;
using BRICS_API_Neo.Models;
using BRICS_API_NEO.HelperMethods;
using BRICS_API_NEO.DTOs;

namespace BRICS_API_NEO.Services
{
    public class IciciImplementation : IIciciInterface
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly BricsrecosystemContext _dbcontext;

        public IciciImplementation(IConfiguration configuration, IMapper mapper, BricsrecosystemContext dbcontext)
        {
            _configuration = configuration;
            _dbcontext = dbcontext;
            _mapper = mapper;
        }

        public string alertNotification(string request)
        {
            string result = string.Empty;
            Icicilog _log = new Icicilog();
            List<Icicialertnotification> addedNotifications = new List<Icicialertnotification>();
            ConfigurationModel configurationModel = StaticClass.GetConfigCreadential();
            byte[] secreatKey = Convert.FromBase64String(configurationModel.SecreatKey);
            string publicKeyPath = _configuration["keyPath:iciciPublicKey"];
            EncryptedRequest encryptedRequest = new EncryptedRequest();
            IciciAlertResponse alertResponse = new IciciAlertResponse();

            if (request != null)
            {
                try
                {
                    _log.RequestId = Guid.NewGuid().ToString();
                    _log.Sourceapi = "iciciInstaAlert";
                    _log.Encryptedrequest = request;
                    StaticClass.Log(_log);

                    //decryptBody
                    var decryptBody = DecryptedResponseBody(request, secreatKey);
                    _log.Response = decryptBody;
                    StaticClass.Log(_log);

                    var response = JsonConvert.DeserializeObject<IciciAlertNotificationResponse>(decryptBody);

                    if (response != null && response.GenericCorporateAlertRequest != null)
                    {
                        // Map the response to AlertNotificationDTOs
                        var alertNotificationDTOs = _mapper.Map<List<AlertNotificationDTOs>>(response.GenericCorporateAlertRequest);

                        // Map the DTOs to the entity
                        addedNotifications = _mapper.Map<List<Icicialertnotification>>(alertNotificationDTOs);

                        //save
                        _dbcontext.Icicialertnotifications.AddRange(addedNotifications);
                        _dbcontext.SaveChanges();

                        //encrypt reponseBody
                        alertResponse = new IciciAlertResponse
                        {
                            Status = "200",
                            Remark = "Success"
                        };
                    }
                    else
                    {
                        alertResponse = new IciciAlertResponse
                        {
                            Status = "400",
                            Remark = "reject"
                        };
                    }

                    _log.Encryptedresponse = JsonConvert.SerializeObject(alertResponse);
                    StaticClass.Log(_log);

                    var jsonResponse = JsonConvert.SerializeObject(result);

                    result = encryptedRequest.EncryptedRequestBody(jsonResponse, publicKeyPath);
                }
                catch (Exception ex)
                {
                    throw new Exception();
                }
            }
            return null;
        }

        private string DecryptedResponseBody(string base64EncryptedData, byte[] key)
        {
            // Extract the IV
            byte[] iv = StaticClass.ExtractIV(base64EncryptedData);

            // Base64 decode the combined data
            byte[] combinedData = Convert.FromBase64String(base64EncryptedData);

            // Extract encrypted data (excluding the IV part)
            byte[] encryptedData = new byte[combinedData.Length - iv.Length];
            Array.Copy(combinedData, iv.Length, encryptedData, 0, encryptedData.Length);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.Mode = CipherMode.CBC;
                aesAlg.Padding = PaddingMode.PKCS7;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, iv);

                using (MemoryStream msDecrypt = new MemoryStream(encryptedData))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

    }
}
