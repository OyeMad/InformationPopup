using Madhur.SO.PopUp;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Madhur.InfoPopup
{
	public class InfoHandler : MonoBehaviour
	{
		[SerializeField]
		float       m_maxTimeForPopup = 1.5f;

		float       m_currentTime = 0.0f;

		[SerializeField]
		SliderDataRunTimeSet    runtimeList= null;

		[SerializeField]
		TMP_Text    m_Text = null;

		[SerializeField]
		Image      m_Sprite = null;

		[SerializeField]
		bool        m_DrawIcon = true;

		void Start ()
		{
			messageComplete = true;
			runtimeList.Clear ( );
			offset =  m_Text.rectTransform.offsetMin;
		}
		Vector2 offset = Vector2.zero;

		public void ShowPopUp(string a_Message , PopUpType a_type ) 
		{
			SliderData newData = new SliderData();
			newData.Message = a_Message;
			newData.PopUpSetting = a_type;

			runtimeList.Add ( newData );
		}

		// Update is called once per frame
		void Update ()
		{
			if( runtimeList.GetCount() > 0 && messageComplete )
			{
				m_currentTime -= Time.deltaTime;

				if( m_currentTime <= 0.0f)
				{
					m_currentTime = m_maxTimeForPopup;

					SliderData sd = runtimeList.Items[0];
					m_Text.text = sd.Message;

					Vector2 t =  m_Text.rectTransform.offsetMin;
					if ( m_DrawIcon )
					{
						m_Sprite.sprite = sd.PopUpSetting.Image;
						m_Sprite.gameObject.SetActive ( true );

						t = offset;
						m_Text.rectTransform.offsetMin = t;
					}
					else
					{
						m_Sprite.gameObject.SetActive ( false );
						t.x = 5;
						m_Text.rectTransform.offsetMin = t;
					}

					// other customizations
					m_Text.fontStyle = sd.PopUpSetting.Style;

					SlideIn ( );
					
				}

				
			}


		}

		[SerializeField]
		float   m_SlideInY		= 0f;

		[SerializeField]
		float   m_SlideOutY       = 0f;

		[SerializeField]
		float       m_delayExitTime = 1.0f;


		bool messageComplete = false;


		void SlideIn()
		{
			messageComplete = false;
			runtimeList.RemoveAt( 0 );
			iTween.MoveTo ( gameObject , iTween.Hash ( "y" , m_SlideInY , "easeType" , "easeInOutExpo"  , "time" , 1.0f , "oncomplete" , "SlideOut" ) );
		}

		void SlideOut()
		{
			iTween.MoveTo ( gameObject , iTween.Hash ( "y" , m_SlideOutY , "easeType" , "easeInOutExpo" , "time" , 0.1f , "delay" , m_delayExitTime ) );
			messageComplete = true;
		}


	}

}