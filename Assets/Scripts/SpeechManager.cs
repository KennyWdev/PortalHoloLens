using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class SpeechManager : MonoBehaviour
{
	KeywordRecognizer keywordRecognizer = null;
	Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

	// Use this for initialization
	void Start() {
		keywords.Add("Reset", () => {
				// Reset the scene
				GameManager.Instance.OnReset();
			});
		keywords.Add("Restart", () => {
				// Reset the scene
				GameManager.Instance.OnReset();
			});

		keywords.Add("Cube", () => {
				// Reset the cube
				GameManager.Instance.PortalObjectSelect();
			});
		
		// Tell the KeywordRecognizer about our keywords.
		keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

		// Register a callback for the KeywordRecognizer and start recognizing!
		keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
		keywordRecognizer.Start();
	}

	private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args) {
		System.Action keywordAction;
		if (keywords.TryGetValue(args.text, out keywordAction)) {
			keywordAction.Invoke();
		}
	}
}
