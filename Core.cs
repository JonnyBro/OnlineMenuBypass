using MelonLoader;
using UnityEngine;
using UnityEngine.SceneManagement;

[assembly: MelonInfo(typeof(OnlineMenuBypass.Core), "OnlineMenuBypass", "1.0.0", "Jonny_Bro", null)]
[assembly: MelonGame("Monkey-With-a-Bomb", "CONVRGENCE")]

namespace OnlineMenuBypass
{
	public class Core : MelonMod
	{
		private bool didBypass = false;

		public override void OnUpdate()
		{
			if (didBypass) return;

			Scene activeScene = SceneManager.GetActiveScene();
			if (activeScene.name != "MainMenu") return;

			GameObject onlineWindow = GameObject.Find("OnlineWindow");
			if (onlineWindow == null) return;

			MelonLogger.Msg("[Online Check Bypass] OnlineWindow found, skipping...");
			onlineWindow.SetActive(false);

			GameObject welcomeScreen = GameObject.Find("WelcomeScreen");
			if (welcomeScreen != null)
			{
				MelonLogger.Msg("[Online Check Bypass] WelcomeScreen found, skipping...");
				welcomeScreen.SetActive(false);
			}

			Transform mainMenu = null;
			foreach (Transform t in Resources.FindObjectsOfTypeAll<Transform>())
			{
				if (t.name == "MainMenu" && t.gameObject.scene.IsValid())
				{
					mainMenu = t;
					break;
				}
			}

			if (mainMenu != null)
			{
				MelonLogger.Msg("[Online Check Bypass] MainMenu found, enabling...");
				mainMenu.gameObject.SetActive(true);
				didBypass = true;
			}
			else
			{
				MelonLogger.Warning("[Online Check Bypass] ERROR! No MainMenu found! Possible candidates:");
				foreach (Transform t in Resources.FindObjectsOfTypeAll<Transform>())
				{
					if (t.name.ToLower().Contains("menu") && t.gameObject.scene.IsValid())
						MelonLogger.Warning($"  - '{t.name}' (parent: '{t.parent?.name ?? "<none>"}')");
				}
			}
		}
	}
}
