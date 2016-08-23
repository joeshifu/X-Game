using UnityEngine;
using System.Security.Cryptography;

public class RSACrypto
{
    public string m_privateKey { get; set; }
    public string m_publickey { get; set; }

    private static RSACrypto m_inst;
    public static RSACrypto Inst
    {
        get
        {
            if (m_inst == null)
            {
                m_inst = new RSACrypto();
            }
            return m_inst;
        }
    }

    public void GenKey()
    {
        using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
        {
            this.m_privateKey = RSA.ToXmlString(true);//私钥
            this.m_publickey = RSA.ToXmlString(false);//公钥
        }
    }

    /// <summary>
    /// 用公钥加密
    /// </summary>
    /// <param name="dataBytes"></param>
    /// <param name="publicKey"></param>
    /// <param name="DoOAEPPadding"></param>
    /// <returns></returns>
    public byte[] RSAEncrypt(byte[] dataBytes, string publicKey, bool DoOAEPPadding)
    {
        try
        {
            byte[] encryptedData;
            //Create a new instance of RSACryptoServiceProvider.
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {

                RSA.FromXmlString(publicKey);

                //Encrypt the passed byte array and specify OAEP padding.  
                //OAEP padding is only available on Microsoft Windows XP or
                //later.  
                encryptedData = RSA.Encrypt(dataBytes, DoOAEPPadding);
            }
            return encryptedData;
        }
        catch (CryptographicException e)
        {
            Debug.LogError(e.Message);
            return null;
        }
    }

    /// <summary>
    /// 用私钥解密
    /// </summary>
    /// <param name="dataBytes"></param>
    /// <param name="privateKey"></param>
    /// <param name="DoOAEPPadding"></param>
    /// <returns></returns>
    public byte[] RSADecrypt(byte[] dataBytes, string privateKey, bool DoOAEPPadding)
    {
        try
        {
            byte[] decryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(privateKey);

                decryptedData = RSA.Decrypt(dataBytes, DoOAEPPadding);
            }
            return decryptedData;
        }
        catch (CryptographicException e)
        {
            Debug.LogError(e.Message);
            return null;
        }
    }
}
