/*
 * Created by SharpDevelop.
 * User: Narudon
 * Date: 9/11/2556
 * Time: 10:43
 * 
 */
 
using System;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;

namespace MCback
{
	/// <summary>
	/// Description of MCConfigManager.
	/// </summary>
	public class MCConfigManager
	{
		private static MCConfigManager _instance;
		public static MCConfigManager instance
	   	{
	      	get 
	      	{
		         if (_instance == null)
		         {
		            _instance = new MCConfigManager();
		         }
		         return _instance;
	      	}
	   	}
		
		#region data
		//default
		private readonly string DEFAULT_SOURCEPATH = "C:/";
		private readonly string DEFAULT_DESTINATIONPATH = "C:/";
		private readonly string DEFAULT_LASTBACKUPFOLDER = "NONE";
		private readonly string DEFAULT_SAVEFOLDERNAME = "backup";
		
		private MCConfig _currentConfig;
		public MCConfig currentConfig{
	      	get{
				if(_currentConfig != null){
		    		return _currentConfig;
				}else{
					return null;
				}
	      	}
	   	}
		
		private bool _isHiddenConfigFile;  
			
		private const string DEFUALT_CONFIG_FILENAME = ".config";
		
		#endregion		
		
		#region Config
		public void SaveConfig (string fileName, MCConfig config) {
			UpdateConfig(config);
			string json = JsonConvert.SerializeObject(config);
			WriteFile(fileName, json);
		}
		
		public void SaveConfig (MCConfig config) {
			SaveConfig(DEFUALT_CONFIG_FILENAME, config);
		}
		
		public MCConfig LoadConfig (string json) {
			
			try {
				MCConfig config = JsonConvert.DeserializeObject<MCConfig>(json);
				UpdateConfig(config);
				return config;
			}catch{
				Debug.WriteLine("cannot load MCconfig");
				return LoadDefaultConfig();
			}
		}
		
		public MCConfig LoadConfig () {
			string json;
			json = ReadFile();
			return LoadConfig(json);
		}
		
		public MCConfig LoadDefaultConfig () {
			
			Debug.WriteLine("load deafult config (mcmanager)");
			MCConfig config = new MCConfig();
			config.sourcePath = DEFAULT_SOURCEPATH;
			config.destinationPath = DEFAULT_DESTINATIONPATH;
			config.saveFolderName = DEFAULT_SAVEFOLDERNAME;
			config.lastBackupFolder = DEFAULT_LASTBACKUPFOLDER;
			_currentConfig = config;
			return config;
		}
		
		public void UpdateConfig (MCConfig config) {
			_currentConfig = config;
		}
		
		#endregion
		
		#region file 
		
		public void WriteFile (string fileName, string text) {
			StreamWriter st = File.CreateText(fileName);
			st.WriteLine(text);
			st.Close();
			File.SetAttributes(fileName, FileAttributes.Hidden);
		}
		
		public void WriteFile (string text) {
			WriteFile(DEFUALT_CONFIG_FILENAME, text);
		}
		
		public string ReadFile (string path, string fileName) {		
			//try open files in current path
			string filePath = path +"/"+ fileName;
			if(File.Exists(filePath)){
				StreamReader stReader = new StreamReader(filePath);
				string text = stReader.ReadLine();
				stReader.Close();
				Debug.WriteLine("file found to read : " + text);
				return text;
			}else{
				Debug.WriteLine("files noit found");
				return null;
			}
		}
		
		public string ReadFile () {
			
			return ReadFile(Directory.GetCurrentDirectory(), DEFUALT_CONFIG_FILENAME);
		}
		
		//
		public void HiddenFile (string directory, string fileName) {
			string path = directory +"/"+ fileName;
			File.SetAttributes(path, File.GetAttributes(path) | FileAttributes.Hidden);
		}
		public void HiddenFile () {
			HiddenFile(Directory.GetCurrentDirectory(), DEFUALT_CONFIG_FILENAME);
		}
		
		#endregion
	}
}
