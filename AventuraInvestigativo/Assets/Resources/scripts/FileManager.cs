using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

/// <summary>
/// Classe responsavel pelo gerenciamento de arquivos e diretorios.
/// Implementado baseado no exemplo em: 
/// http://www.fizixstudios.com/labs/do/view/id/unity-file-management-and-xml
/// </summary>

public class FileManager {

	private static FileManager instance;
	private string path;

	public static FileManager getInstance() {
		if (instance == null) {
			instance = new FileManager();
		}
		return instance;
	}

	private FileManager() {
		this.path = Application.dataPath;
	}

	public void OnApplicationQuit() {
		destroyInstance();
	}

	public void destroyInstance() {
		instance = null;
	}

	public string gamedirectory {
		get {
			return this.path;
		}
	}

	public bool checkDirectory(string dir) {
		return Directory.Exists(this.path+'/'+dir);
	}

	public void createDirectory(string dir) {
		if (!checkDirectory(dir)) {
			Directory.CreateDirectory(this.path+'/'+dir);
		}
		else {
			string dirname = '/'+dir;
			throw new System.InvalidOperationException("Cannot create directory '"+dirname+"' because it already exists");
		}
	}

	public void deleteDirectory(string dir) {
		if (checkDirectory(dir)) {
			Directory.Delete(this.path+'/'+dir, true);
		}
		else {
			string dirname = '/'+dir;
			throw new System.InvalidOperationException("Cannot delete directory '"+dirname+"' because it not exists");
		}
	}

	public bool checkFile(string filePath) {
		return File.Exists(this.path+'/'+filePath);
	}

	public bool checkFile(string dir, string filename, string ext) {
		if (ext == "") {
			return File.Exists(this.path+'/'+dir+'/'+filename);
		}
		else {
			return File.Exists(this.path+'/'+dir+'/'+filename+'.'+ext);
		}
	}

	public void createFile(string filePath) {
		if (!checkFile(filePath)) {
			FileStream f = File.Create(this.path+'/'+filePath);
			f.Close();
		}
		else {
			string dirname = '/'+filePath;
			throw new System.InvalidOperationException("Cannot create file '"+dirname+"' because it already exists");
		}
	}

	public void createFile(string dir, string filename, string ext) {
		if (checkDirectory(dir)) {
			if (!checkFile(dir, filename, ext)) {
				FileStream f;
				if (ext == "") {
					f = File.Create(this.path+'/'+dir+'/'+filename);
				}
				else {
					f = File.Create(this.path+'/'+dir+'/'+filename+'.'+ext);
				}
				f.Close();
			}
			else {
				string cdir = '/'+dir;
				string cfile = filename;
				if (ext != "") {
					cfile = cfile+'.'+ext;
				}
				throw new System.InvalidOperationException("Cannot create file '"+cfile+"' in directory '"+cdir+"' because it already exists a file with that name");
			}
		}
		else {
			string dirname = '/'+dir;
			throw new System.IO.DirectoryNotFoundException("Cannot access '"+dirname+"' because it not exists");
		}
	}

	public void deleteFile(string filePath) {
		if (checkFile(filePath)) {
			File.Delete(this.path+'/'+filePath);
		}
		else {
			string dirname = '/'+filePath;
			throw new System.IO.FileNotFoundException("Cannot delete file '"+dirname+"' because it not exists");
		}
	}

	public void deleteFile(string dir, string filename, string ext) {
		if (checkDirectory(dir)) {
			if (checkFile(dir, filename, ext)) {
				if (ext == "") {
					File.Delete(this.path+'/'+dir+'/'+filename);
				}
				else {
					File.Delete(this.path+'/'+dir+'/'+filename+'.'+ext);
				}
			}
			else {
				string cfile = this.path+'/'+dir+'/'+filename;
				if (ext != "") {
					cfile = cfile+'.'+ext;
				}
				throw new System.IO.FileNotFoundException("Cannot delete file '"+cfile+"' because it not exists");
			}
		}
		else {
			string dirname = '/'+dir;
			throw new System.IO.DirectoryNotFoundException("Cannot access '"+dirname+"' because it not exists");
		}
	}

	public string[] listSubDirectories(string dir) {
		if (checkDirectory(dir)) {
			return Directory.GetDirectories(this.path+'/'+dir);
		}
		else {
			string dirname = '/'+dir;
			throw new System.IO.DirectoryNotFoundException("Cannot list sub-directories from '"+dirname+"' because it not exists");
		}
	}

	public string[] listFiles(string dir) {
		if (checkDirectory(dir)) {
			return Directory.GetFiles(this.path+'/'+dir);
		}
		else {
			string dirname = '/'+dir;
			throw new System.IO.DirectoryNotFoundException("Cannot list files from '"+dirname+"' because it not exists");
		}
	}

	public string ReadTextFile(string filePath, bool isEncryptedFile) {
		if (checkFile(filePath)) {
			string data;
			if (isEncryptedFile) {
				createFile(filePath+"._temp_");
				DecryptFile(this.path+'/'+filePath, this.path+'/'+filePath+"._temp_", "ROero|YZhMuSUIae");
				using (StreamReader TxtReader = new StreamReader(File.Open(this.path+'/'+filePath+"._temp_", FileMode.Open))) {
					data = TxtReader.ReadToEnd();
				}
				deleteFile(filePath+"._temp_");
			}
			else {
				using (StreamReader TxtReader = new StreamReader(File.Open(this.path+'/'+filePath, FileMode.Open))) {
					data = TxtReader.ReadToEnd();
				}
			}
			return data;
		}
		else {
			string dirname = '/'+filePath;
			throw new System.IO.FileNotFoundException("Cannot read file '"+dirname+"' because it not exists");
		}
	}

	public string ReadTextFile(string dir, string filename, string ext, bool isEncryptedFile) {
		if (checkDirectory(dir)) {
			string filePath = dir+'/'+filename;
			if (ext != "") {
				filePath = filePath+'.'+ext;
			}
			return ReadTextFile(filePath, isEncryptedFile);
		}
		else {
			string dirname = '/'+dir;
			throw new System.IO.DirectoryNotFoundException("Cannot access '"+dirname+"' because it not exists");
		}
	}

	public void WriteTextFile(string filePath, string data, bool encryptFile) {
		if (checkFile(filePath)) {
			string data_to_write = data;
			if (encryptFile) {
				createFile(filePath+"._temp_");
				using (StreamWriter TxtWriter = new StreamWriter(File.Open(this.path+'/'+filePath+"._temp_", FileMode.Open))) {
					TxtWriter.Write(data_to_write);
				}
				EncryptFile(this.path+'/'+filePath+"._temp_", this.path+'/'+filePath, "ROero|YZhMuSUIae");
				deleteFile(filePath+"._temp_");
			}
			else {
				using (StreamWriter TxtWriter = new StreamWriter(File.Open(this.path+'/'+filePath, FileMode.Open))) {
					TxtWriter.Write(data_to_write);
				}
			}
		}
		else {
			string dirname = '/'+filePath;
			throw new System.IO.FileNotFoundException("Cannot write in file '"+dirname+"' because it not exists");
		}
	}

	public void WriteTextFile(string dir, string filename, string ext, string data, bool encryptFile) {
		if (checkDirectory(dir)) {
			string filePath = dir+'/'+filename;
			if (ext != "") {
				filePath = filePath+'.'+ext;
			}
			WriteTextFile(filePath, data, encryptFile);
		}
		else {
			string dirname = '/'+dir;
			throw new System.IO.DirectoryNotFoundException("Cannot access '"+dirname+"' because it not exists");
		}
	}

	public object ReadBinaryFile(string filePath) {
		if (checkFile(filePath)) {
			Stream arq = File.Open(this.path+'/'+filePath, FileMode.Open);
			BinaryFormatter bform = new BinaryFormatter();
			object data = bform.Deserialize(arq);
			arq.Close();
			return data;
		}
		else {
			string dirname = '/'+filePath;
			throw new System.IO.FileNotFoundException("Cannot read file '"+dirname+"' because it not exists");
		}
	}

	public object ReadBinaryFile(string dir, string filename, string ext) {
		if (checkDirectory(dir)) {
			string filePath = dir+'/'+filename;
			if (ext != "") {
				filePath = filePath+'.'+ext;
			}
			return ReadBinaryFile(filePath);
		}
		else {
			string dirname = '/'+dir;
			throw new System.IO.DirectoryNotFoundException("Cannot access '"+dirname+"' because it not exists");
		}
	}

	public void WriteBinaryFile(string filePath, object data) {
		if (checkFile(filePath)) {
			Stream arq = File.Open(this.path+'/'+filePath, FileMode.Open);
			BinaryFormatter bform = new BinaryFormatter();
			bform.Serialize(arq, data); 
			arq.Close();
		}
		else {
			string dirname = '/'+filePath;
			throw new System.IO.FileNotFoundException("Cannot write in file '"+dirname+"' because it not exists");
		}
	}

	public void WriteBinaryFile(string dir, string filename, string ext, object data) {
		if (checkDirectory(dir)) {
			string filePath = dir+'/'+filename;
			if (ext != "") {
				filePath = filePath+'.'+ext;
			}
			WriteBinaryFile(filePath, data);
		}
		else {
			string dirname = '/'+dir;
			throw new System.IO.DirectoryNotFoundException("Cannot access '"+dirname+"' because it not exists");
		}
	}

	/// <summary>
	/// Encripta a string toEncrypt.
	/// 
	/// Code from: http://unitynoobs.blogspot.co.uk/2012/01/xml-encrypting.html
	/// </summary>
	/// <param name="toEncrypt">To encrypt.</param>
	public static string Encrypt(string toEncrypt) {
		byte[] keyArray = UTF8Encoding.UTF8.GetBytes ("12345678901234567890123456789012");
		// 256-AES key
		byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes (toEncrypt);
		RijndaelManaged rDel = new RijndaelManaged ();
		rDel.Key = keyArray;
		rDel.Mode = CipherMode.ECB;
		// http://msdn.microsoft.com/en-us/library/system.security.cryptography.ciphermode.aspx
		rDel.Padding = PaddingMode.PKCS7;
		// better lang support
		ICryptoTransform cTransform = rDel.CreateEncryptor ();
		byte[] resultArray = cTransform.TransformFinalBlock (toEncryptArray, 0, toEncryptArray.Length);
		return Convert.ToBase64String(resultArray, 0, resultArray.Length);
	}

	/// <summary>
	/// Decripta a string toDecrypt.
	/// 
	/// Code from: http://unitynoobs.blogspot.co.uk/2012/01/xml-encrypting.html
	/// </summary>
	/// <param name="toDecrypt">To decrypt.</param>
	public static string Decrypt(string toDecrypt) {
		byte[] keyArray = UTF8Encoding.UTF8.GetBytes ("12345678901234567890123456789012");
		// AES-256 key
		byte[] toEncryptArray = Convert.FromBase64String (toDecrypt);
		RijndaelManaged rDel = new RijndaelManaged ();
		rDel.Key = keyArray;
		rDel.Mode = CipherMode.ECB;
		// http://msdn.microsoft.com/en-us/library/system.security.cryptography.ciphermode.aspx
		rDel.Padding = PaddingMode.PKCS7;
		// better lang support
		ICryptoTransform cTransform = rDel.CreateDecryptor ();
		byte[] resultArray = cTransform.TransformFinalBlock (toEncryptArray, 0, toEncryptArray.Length);
		return UTF8Encoding.UTF8.GetString (resultArray);
	}

	/// <summary>
	/// Encrypts the file.
	/// Code from: http://www.fluxbytes.com/csharp/encrypt-and-decrypt-files-in-c/
	/// </summary>
	/// <param name="inputFile">Input file.</param>
	/// <param name="outputFile">Output file.</param>
	/// <param name="skey">Skey.</param>
	private static void EncryptFile(string inputFile, string outputFile, string skey) {
		try {
			using (RijndaelManaged aes = new RijndaelManaged()) {
				byte[] key = ASCIIEncoding.UTF8.GetBytes(skey);

				/* This is for demostrating purposes only. 
                 * Ideally you will want the IV key to be different from your key and 
                 * you should always generate a new one for each encryption in other 
                 * to achieve maximum security*/
				byte[] IV = ASCIIEncoding.UTF8.GetBytes(skey);

				//using (FileStream fsCrypt = new FileStream(outputFile, FileMode.OpenOrCreate)) {
				using (FileStream fsCrypt = File.Open(outputFile, FileMode.Open)) {
					using (ICryptoTransform encryptor = aes.CreateEncryptor(key, IV)) {
						using (CryptoStream cs = new CryptoStream(fsCrypt, encryptor, CryptoStreamMode.Write)) {
							//using (FileStream fsIn = new FileStream(inputFile, FileMode.Open)) {
							using (FileStream fsIn = File.Open(inputFile, FileMode.Open)) {
								int data;
								while ((data = fsIn.ReadByte()) != -1) {
									cs.WriteByte((byte)data);
								}
							}
						}
					}
				}
			}
		}
		catch (Exception ex) {
			throw new System.ApplicationException(ex.Message);
		}
	}

	private static void DecryptFile(string inputFile, string outputFile, string skey) {
		try {
			using (RijndaelManaged aes = new RijndaelManaged()) {
				byte[] key = ASCIIEncoding.UTF8.GetBytes(skey);
				
				/* This is for demostrating purposes only. 
                 * Ideally you will want the IV key to be different from your key and 
                 * you should always generate a new one for each encryption in other 
                 * to achieve maximum security*/
				byte[] IV = ASCIIEncoding.UTF8.GetBytes(skey);

				//using (FileStream fsCrypt = new FileStream(inputFile, FileMode.OpenOrCreate)) {
				using (FileStream fsCrypt = File.Open(inputFile, FileMode.Open)) {
					//using (FileStream fsOut = new FileStream(outputFile, FileMode.Create)) {
					using (FileStream fsOut = File.Open(outputFile, FileMode.Open)) {
						using (ICryptoTransform decryptor = aes.CreateDecryptor(key, IV)) {
							using (CryptoStream cs = new CryptoStream(fsCrypt, decryptor, CryptoStreamMode.Read)) {
								int data;
								while ((data = cs.ReadByte()) != -1) {
									fsOut.WriteByte((byte)data);
								}
							}
						}
					}
				}
			}
		}
		catch (Exception ex) {
			throw new System.ApplicationException(ex.Message);
		}
	}
}