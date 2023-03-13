using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Turkuaz_WebAPI.Models;
using Turkuaz_WebAPI.Services.Abstract;

namespace Turkuaz_WebAPI.Services.Concrete
{
	public class AplicationServices : IAplicationServices
	{
	
		public string FindTheDifference(FindTheDifferenceDTO differenceDTO)
		{
			List<string> diff;

			var set1 = differenceDTO.FirstArea.Select(x => x.ToString()).ToList();
			var set2 = differenceDTO.SecondArea.Select(x => x.ToString()).ToList();

			if (set2.Count() > set1.Count())
			{
				diff = set2.Except(set1).ToList();
			}
			else
			{
				diff = set1.Except(set2).ToList();
			}
			return JsonConvert.SerializeObject(diff);
		}

		public string RemoveComments(RemoveCommentsDTO commentsDTO)
		{
			List<string> source = JsonConvert.DeserializeObject<List<string>>(commentsDTO.Source);
			List<string> output = new List<string>();
			bool isComment = false;
			foreach (string line in source)
			{
				string cleanedLine = line;

				if (line.Trim().StartsWith("/*"))
				{
					isComment = true;
				}
				if (!isComment && line.Contains("//"))
				{
					cleanedLine = Regex.Replace(line, @"//.*", "");
				}

				if (!isComment && !line.Contains("/*"))
				{
					output.Add(cleanedLine.Trim());
				}
				if (line.Trim().EndsWith("*/"))
				{
					isComment = false;
				}

			}
			var data = JsonConvert.SerializeObject(output);

			return data;
		}
	}
}
