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
	public class MCConfigManager : Singleton
	{
		#region data
		private MCConfig _currentConfig;
		public MCConfig currentConfig
	   	{
	      	get 
	      	{
		         return _currentConfig;
	      	}
	   	}
		
		private const string DEFUALT_CONFIG_FILENAME = ".config";
		
		#endregion
		
		
		public MCConfigManager()
		{
		}
		
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
		
		void WriteFile (string fileName, string text = DEFUALT_CONFIG_FILENAME) {
			StreamWriter st = File.CreateText(fileName);
			st.WriteLine(text);
			st.Close();
		}
		
		string ReadFile (string path, string fileName = DEFUALT_CONFIG_FILENAME) {		
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
	}
}
