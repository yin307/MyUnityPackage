using System;
using System.Collections;
using System.Collections.Generic;

namespace YPackage
{
	public class Achievement
	{		
		public string user_code;
		public string ach_id;
		public int score;

		public Achievement ()
		{
		}

		public Achievement(string user_code, string ach_id, int score){			
			this.user_code = user_code;
			this.ach_id = ach_id;
			this.score = score;
		}
			
	}
}

