/*
 * Created by SharpDevelop.
 * User: Narudon
 * Date: 9/11/2556
 * Time: 10:40
 */
using System;

namespace MCback
{
	/// <summary>
	/// base singleton class.
	/// </summary>
	public class Singleton
	{
		private static Singleton instance;
		public Singleton(){}
		public static Singleton Instance
	   	{
	      	get 
	      	{
		         if (instance == null)
		         {
		            instance = new Singleton();
		         }
		         return instance;
	      	}
	   	}
	}
}

