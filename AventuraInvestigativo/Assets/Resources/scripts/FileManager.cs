using UnityEngine;
using System;
using System.Collections;
using System.IO;
using UnityEditor;
using System.Text;
using System.Security.Cryptography;

/// <summary>
/// Classe responsavel pelo gerenciamento de arquivos e diretorios.
/// Implementado baseado no exemplo em: 
/// http://www.fizixstudios.com/labs/do/view/id/unity-file-management-and-xml
/// </summary>

public class FileManager {

	private static FileManager instance;
	private string path;

	public static FileManager Instance {

		get {
			if (instance == null) {
				instance = new FileManager();
			}
			return instance;
		}
	}

	public void OnApplicationQuit() {
		destroyInstance();
	}

	public void destroyInstance() {
		instance = null;
	}

	public void initialize() {
		path = Application.dataPath;
		if (!checkDirectory("GameData")) {
			createDirectory("GameData");
		}
	}

	public bool checkDirectory(string dir) {
		return Directory.Exists(this.path+'/'+dir);
	}

	public void createDirectory(string dir) {
		if (!checkDirectory(this.path+'/'+dir)) {
			Directory.CreateDirectory(this.path+'/'+dir);
		}
	}

	public void deleteDirectory(string dir) {
		if (checkDirectory(this.path+'/'+dir)) {
			Directory.Delete(this.path+'/'+dir, true);
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

	public void createFile(string dir, string filename, string ext) {
		if (checkDirectory(this.path+'/'+dir)) {
			if (!checkFile(dir, filename, ext)) {
				if (ext == "") {
					File.Create(this.path+'/'+dir+'/'+filename);
				}
				else {
					File.Create(this.path+'/'+dir+'/'+filename+'.'+ext);
				}
			}
		}
	}

	public void deleteFile(string filePath) {
		if (checkFile(filePath)) {
			File.Delete(this.path+'/'+filePath);
		}
	}

	public void deleteFile(string dir, string filename, string ext) {
		if (checkFile(dir, filename, ext)) {
			if (ext == "") {
				File.Delete(this.path+'/'+dir+'/'+filename);
			}
			else {
				File.Delete(this.path+'/'+dir+'/'+filename+'.'+ext);
			}
		}
	}

	public string[] listSubDirectories(string dir) {
		if (checkDirectory(this.path+'/'+dir)) {
			return Directory.GetDirectories(this.path+'/'+dir);
		}
		else {
			return null;
		}
	}

	public string[] listFiles(string dir) {
		if (checkDirectory(this.path+'/'+dir)) {
			return Directory.GetFiles(this.path+'/'+dir);
		}
		else {
			return null;
		}
	}

	public string ReadFile(string filePath) {
		if (checkFile(filePath)) {
			return File.ReadAllText(filePath);
		}
		else {
			return null;
		}
	}

	public string ReadFile(string dir, string filename, string ext, bool isEncryptedFile) {
		if (checkFile(dir, filename, ext)) {
			string data;
			if (ext == "") {
				data = File.ReadAllText(this.path+'/'+dir+'/'+filename);
			}
			else {
				data = File.ReadAllText(this.path+'/'+dir+'/'+filename+'.'+ext);
			}

			if (isEncryptedFile) {
				return Decrypt(data);
			}
			else {
				return data;
			}
		}
		else {
			return null;
		}
	}

	public void WriteFile(string filePath, string data, string mode, bool encryptFile) {
		if (checkFile(filePath)) {
			string data_to_write = data;
			if (encryptFile) {
				data_to_write = Encrypt(data);
			}

			if (mode == "replace") {
				File.WriteAllText(filePath, data_to_write);
			}
			else if (mode == "append") {
				File.AppendAllText(filePath, data_to_write);
			}
		}
	}

	public void WriteFile(string dir, string filename, string ext, string data, string mode, bool encryptFile) {
		if (checkFile(dir, filename, ext)) {
			string filePath = this.path+'/'+dir+'/'+filename;
			if (ext != "") {
				filePath = filePath+'.'+ext;
			}

			string data_to_write = data;
			if (encryptFile) {
				data_to_write = Encrypt(data);
			}

			if (mode == "replace") {
				File.WriteAllText(filePath, data_to_write);
			}
			else if (mode == "append") {
				File.AppendAllText(filePath, data_to_write);
			}
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
		return Convert.ToBase64String (resultArray, 0, resultArray.Length);
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
}