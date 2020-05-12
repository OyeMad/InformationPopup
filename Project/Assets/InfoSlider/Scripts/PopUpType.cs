using UnityEngine;

namespace Madhur.SO.PopUp
{
	[CreateAssetMenu ( fileName = "Popup-Type-" , menuName = "InfoPopup/Popup Type" )]
	public class PopUpType : ScriptableObject
	{
		[Header("Icon")]
		public  Sprite				Image;

		[Header("Customizations")]
		public  TMPro.FontStyles    Style;

		// If there is any other customization you want to add, 
		// ADD BELOW 

	}

}