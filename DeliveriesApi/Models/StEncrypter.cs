using System.Security.Cryptography;
using System.IO;
using System.Text;
using System;
using System.Web;

public class StEncrypter
{
    public StEncrypter() { }

    /****************************************************************************
     ATT: next 2 keys must match the keys in the same class in www.Tenders.co.il
     ****************************************************************************/
    private static string StrChave = "DeliveriesApiEncryption";
    private static string StrIV = "9876543210123456";

    private static byte[] GerarChave()
    {
        if (StrChave.Length >= 16)
            StrChave = StrChave.Substring(0, 16);
        else
        {
            for (int x = StrChave.Length + 1; x < 17; x++)
            {
                StrChave += "9";
            }
        }

        return Encoding.UTF8.GetBytes(StrChave);
    }

    public static string Criptografar(string vText)
    {
        MemoryStream objMSEntada = new MemoryStream();
        objMSEntada.Write(Encoding.UTF8.GetBytes(vText), 0, Encoding.UTF8.GetBytes(vText).Length);
        objMSEntada.Position = 0;

        MemoryStream objMSSaida = new MemoryStream();
        byte[] buf = new byte[2048] ;
        SymmetricAlgorithm objRijndael = SymmetricAlgorithm.Create("Rijndael");

        objRijndael.IV = Encoding.UTF8.GetBytes(StrIV);
        objRijndael.Key = GerarChave();

        ICryptoTransform objCT = objRijndael.CreateEncryptor();
        CryptoStream objCS = new CryptoStream(objMSSaida, objCT, CryptoStreamMode.Write);
        int nTamanho = objMSEntada.Read(buf, 0, buf.Length);

        while (nTamanho > 0)
        {
            objCS.Write(buf, 0, nTamanho);
            nTamanho = objMSEntada.Read(buf, 0, buf.Length);
        }

        objCS.FlushFinalBlock();

        objCS.Close();
        objMSEntada.Close();

        
        return Convert.ToBase64String(objMSSaida.ToArray());
    }

    public static string Descriptografar(string vText)
    {
        
        MemoryStream objMSEntada = new MemoryStream();

        objMSEntada.Write(Convert.FromBase64String(vText), 0, Convert.FromBase64String(vText).Length);
        objMSEntada.Position = 0;

        MemoryStream objMSSaida = new MemoryStream();
        byte[] buf = new Byte[2048] ;
        SymmetricAlgorithm objRijndael = SymmetricAlgorithm.Create("Rijndael");

        objRijndael.IV = Encoding.UTF8.GetBytes(StrIV);
        objRijndael.Key = GerarChave();

        ICryptoTransform objCT = objRijndael.CreateDecryptor();
        CryptoStream objCS = new CryptoStream(objMSEntada, objCT, CryptoStreamMode.Read);
        int nTamanho = objCS.Read(buf, 0, buf.Length);

        while (nTamanho > 0)
        {
            objMSSaida.Write(buf, 0, nTamanho);
            nTamanho = objCS.Read(buf, 0, buf.Length);
        }
        objMSEntada.Close();
        objMSSaida.Close();

        return Encoding.UTF8.GetString(objMSSaida.ToArray());
    }

    public static string Encrypt4Web(string itemID)
    {
        string ret = Criptografar(itemID.ToString());
        ret = ret.Replace("+", "_PLUS_").Replace("=","_EQU_").Replace("/","_SLA_");
        //ret = HttpUtility.UrlEncode(ret);

        return ret;
    }

    public static string Decrypt4Web(string itemID)
    {
        string sFixed = itemID;
        sFixed = sFixed.Replace("_PLUS_", "+").Replace("_EQU_", "=").Replace("_SLA_", "/");  

        return Descriptografar(sFixed);
    }
}

