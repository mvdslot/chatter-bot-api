using System;
using System.Speech.Synthesis;

using ChatterBotAPI;

/*
	ChatterBotAPI
	Copyright (C) 2011 pierredavidbelanger@gmail.com
 
	This program is free software: you can redistribute it and/or modify
	it under the terms of the GNU Lesser General Public License as published by
	the Free Software Foundation, either version 3 of the License, or
	(at your option) any later version.

	This program is distributed in the hope that it will be useful,
	but WITHOUT ANY WARRANTY; without even the implied warranty of
	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
	GNU Lesser General Public License for more details.

	You should have received a copy of the GNU Lesser General Public License
	along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
namespace ChatterBotAPITest {
	static class MainClass {
		
		public static void Main(string[] args) {
			ChatterBotFactory factory = new ChatterBotFactory();
			
			ChatterBot bot1 = factory.Create(ChatterBotType.CLEVERBOT);
			ChatterBotSession bot1session = bot1.CreateSession();

			ChatterBot bot2 = factory.Create(ChatterBotType.PANDORABOTS, "b0dafd24ee35a477");
			ChatterBotSession bot2session = bot2.CreateSession();

			var f = new SpeechSynthesizer();
			f.SelectVoiceByHints(VoiceGender.Female);

			var m = new SpeechSynthesizer();
			m.SelectVoiceByHints(VoiceGender.Male);

			string s = "Hi";
			while (true) {
				
				Console.WriteLine("bot1> " + s);
				m.Speak(s);

				s = bot2session.Think(s);
				Console.WriteLine("bot2> " + s);
				f.Speak(s);

				s = bot1session.Think(s);
			}
		}
	}
}
