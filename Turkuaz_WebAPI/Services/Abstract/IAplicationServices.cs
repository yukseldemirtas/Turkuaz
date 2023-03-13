using Turkuaz_WebAPI.Models;

namespace Turkuaz_WebAPI.Services.Abstract
{
	public interface IAplicationServices
	{

		string RemoveComments(RemoveCommentsDTO commentsDTO);
		string FindTheDifference(FindTheDifferenceDTO differenceDTO);


	}
}
