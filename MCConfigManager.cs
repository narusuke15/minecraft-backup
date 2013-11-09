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
		private MCConfig _currentConfig;
		public MCConfig currentConfig{
	      	get{
				if(_currentConfig != null){
		    		return _currentConfig;
				}else{
					//default data
					Debug.Write("config not founded. use default config");
					_currentConfig = new MCConfig();
					_currentConfig.sourcePath = "C:/";
					_currentConfig.destinationPath = "C:/";
					_currentConfig.saveFolderName = "wolrdBak";
					_currentConfig.lastBackupFolder = "";
					return _currentConfig;
				}
	      	}
	   	}
		
		private bool _isHiddenConfigFile;  
			
		private const string DEFUALT_CONFIG_FILENAME = ".config";
		
		#endregion
		
		
		//config
		public void SaveConfig (string fileName, MCConfig config) {
			UpdateConfig(config);
			string json = JsonConvert.SerializeObject(config);
			WriteFile(fileName, json);
		}
		
		
		public MCConfig LoadConfig (string json) {
			MCConfig config = JsonConvert.DeserializeObject<MCConfig>(json);
			UpdateConfig(config);
			return config;
		}
		
		public void UpdateConfig (MCConfig config) {
			_currentConfig = config;
		}
		
		//text file 
		
		public void WriteFile (string fileName, string text) {
			StreamWriter st = File.CreateText(fileName);
			st.WriteLine(text);
			st.Close();
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
				Debug.Write("file found to read");
				return text;
			}else{
				Debug.Write("files noit found");
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
	}
}
